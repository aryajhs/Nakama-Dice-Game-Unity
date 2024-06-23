using UnityEngine;
using Nakama;
using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class NakamaManager : MonoBehaviour
{
    public static NakamaManager Instance;

    public ISocket socket;
    public IClient client;
    public ISession session;
    public string matchId;

    // Adjust these variables based on your Docker Compose configuration
    private const string scheme = "http"; // Change to "https" if using SSL/TLS
    private const string host = "localhost"; // Replace with your Docker host IP or domain name
    private const int port = 7350; // Make sure this matches your Nakama server configuration
    private const string serverKey = "defaultkey"; // Make sure this matches your Nakama server configuration

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    async void Start()
    {
        try
        {
            // Create Nakama client
            client = new Client(scheme, host, port, serverKey, UnityWebRequestAdapter.Instance);
            
            // Authenticate device (Unity's unique identifier can be used as the user ID)
            session = await client.AuthenticateDeviceAsync(SystemInfo.deviceUniqueIdentifier);
            
            // Create socket and connect
            socket = Nakama.Socket.From(client);
            await socket.ConnectAsync(session, true, 5000, "en");

            Debug.Log("Connected to Nakama server.");
        }
        catch (Exception e)
        {
            Debug.LogError("Error connecting to Nakama server: " + e.Message);
        }
    }

    public async Task CreateMatch()
    {
        try
        {
            var match = await socket.CreateMatchAsync();
            matchId = match.Id;
            Debug.Log("Match created with ID: " + matchId);
            // SceneManager.LoadScene("DiceThrow");
        }
        catch (Exception e)
        {
            Debug.LogError("Error creating match: " + e.Message);
        }
    }

    public async Task JoinMatch(string matchId)
    {
        try
        {
            await socket.JoinMatchAsync(matchId);
            Debug.Log("Joined match with ID: " + matchId);
            // SceneManager.LoadScene("DiceThrow");
        }
        catch (Exception e)
        {
            Debug.LogError("Error joining match: " + e.Message);
        }
    }
}
