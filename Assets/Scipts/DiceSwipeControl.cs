using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DiceSwipeControl : MonoBehaviour
{
    // Static Instance of the Dice
    public static DiceSwipeControl Instance;

    // Orignal Dice
    public GameObject originalDice;
    // Dice resultant number
    public int diceCount;
    // Dice play view camera
    public Camera dicePlayCam;
    // Can Throw Dice
    public bool isDiceThrowable = false; // Start with dice not throwable
    public Text gui;
    public Transform diceCarrom;

    private GameObject diceClone;
    private Vector3 initPos;
    private float initXpose;
    private float timeRate;
    private Vector3 currentCampPos;
    internal float diceThrowInit;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        generateDice();
    }

    // Method to throw the dice
    public void ThrowDice()
    {
        if (!isDiceThrowable)
        {
            return; // Exit if dice is not throwable
        }

        StartCoroutine(ThrowDiceCoroutine());
    }

    IEnumerator ThrowDiceCoroutine()
    {
        initPos = Input.mousePosition;
        initXpose = dicePlayCam.ScreenToViewportPoint(Input.mousePosition).x;

        Vector3 currentPos = Input.mousePosition;
        currentPos.z = 25f;
        Vector3 newPos = dicePlayCam.ScreenToWorldPoint(new Vector3(currentPos.x, currentPos.y, Mathf.Clamp(currentPos.y / 10, 5, 70)));
        newPos.y = Mathf.Clamp(newPos.y, -114.5f, 100);
        newPos = dicePlayCam.ScreenToWorldPoint(currentPos);

        initPos = dicePlayCam.ScreenToWorldPoint(initPos);
        enableTheDice();
        addForce(newPos);
        isDiceThrowable = false;

        yield return StartCoroutine(getDiceCount());
    }

    void addForce(Vector3 lastPos)
    {
        diceClone.GetComponent<Rigidbody>().AddTorque(Vector3.Cross(lastPos, initPos) * 1000, ForceMode.Impulse);
        lastPos.y += 12;
        diceClone.GetComponent<Rigidbody>().AddForce(((lastPos - initPos).normalized) * (Vector3.Distance(lastPos, initPos)) * 30 * diceClone.GetComponent<Rigidbody>().mass);
    }

    void enableTheDice()
    {
        diceClone.transform.rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        diceThrowInit = 0;
    }

    void generateDice()
    {
        diceClone = Instantiate(originalDice, dicePlayCam.transform.position, Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180))) as GameObject;
    }

    IEnumerator getDiceCount()
    {
        currentCampPos = dicePlayCam.transform.position;
        yield return new WaitForSeconds(1.0f);
        while (diceClone.GetComponent<Rigidbody>().velocity.magnitude > 0.05f)
        {
            yield return null;
        }

        Time.timeScale = 0.2f;
        float startTime = Time.time;
        Vector3 risePos = dicePlayCam.transform.position;
        Vector3 setPos = new Vector3(diceCarrom.position.x, diceClone.transform.position.y + 25f, diceCarrom.position.z);
        float speed = 0.18f;
        float fracComplete = 0;

        while (Vector3.Distance(dicePlayCam.transform.position, setPos) > 0.5f)
        {
            Vector3 center = (risePos + setPos) * 0.5f;
            center -= new Vector3(0, 2, -1);
            Vector3 riseRelCenter = risePos - center;
            Vector3 setRelCenter = setPos - center;

            if (fracComplete > 0.85f && fracComplete < 1f)
            {
                speed += Time.deltaTime * 0.3f;
                Time.timeScale -= Time.deltaTime * 4f;
            }
            dicePlayCam.transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            dicePlayCam.transform.position += center;
            dicePlayCam.transform.LookAt(diceCarrom);
            fracComplete = (Time.time - startTime) / speed;
            yield return null;
        }

        Time.timeScale = 1.0f;
        gui.text = "Dice Count : " + diceCount;
        yield return new WaitForSeconds(5f);

        diceCount = 0;
        gui.text = "Dice Count : " + diceCount;
        diceClone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Application.LoadLevel(0);
    }
}
