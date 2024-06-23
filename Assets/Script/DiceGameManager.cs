using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public Rigidbody diceRigidbody;
    private bool rolling = false;

    void Update()
    {
        if (rolling && diceRigidbody.IsSleeping())
        {
            rolling = false;
            int result = GetDiceResult();
            Debug.Log("Dice Result: " + result);
        }
    }

    public void RollDice()
    {
        if (!rolling)
        {
            rolling = true;
            diceRigidbody.velocity = Vector3.zero;
            diceRigidbody.angularVelocity = Vector3.zero;
            diceRigidbody.AddForce(new Vector3(Random.Range(-5, 5), 10, Random.Range(-5, 5)), ForceMode.Impulse);
            diceRigidbody.AddTorque(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode.Impulse);
        }
    }

    private int GetDiceResult()
    {
        // Implement logic to determine the dice face value.
        return Random.Range(1, 7);
    }
}
