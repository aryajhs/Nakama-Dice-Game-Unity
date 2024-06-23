using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class JoinGameButton : MonoBehaviour
{
    public NakamaManager nakamaManager; // Reference to your NakamaManager script
    public Text statusText; // UI text to display status messages
    public InputField matchIdInput; // Reference to the input field for match ID

    public void OnJoinGameButtonClicked()
    {
        string matchId = matchIdInput.text;

        // Call NakamaManager method to join a match
        Task.Run(async () =>
        {
            try
            {
                await nakamaManager.JoinMatch(matchId);
                statusText.text = "Joined match successfully!";
            }
            catch (Exception e)
            {
                Debug.LogError("Error joining match: " + e.Message);
                statusText.text = "Failed to join match.";
            }
        });
    }
}
