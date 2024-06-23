using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading.Tasks;

public class HostGameButton : MonoBehaviour
{
    public NakamaManager nakamaManager; // Reference to your NakamaManager script
    public Text statusText; // UI text to display status messages

    public void OnHostGameButtonClicked()
    {
        // Call NakamaManager method to create a match
        Task.Run(async () =>
        {
            try
            {
                await nakamaManager.CreateMatch();
                statusText.text = "Match created successfully!";
            }
            catch (Exception e)
            {
                Debug.LogError("Error creating match: " + e.Message);
                statusText.text = "Failed to create match.";
            }
        });
    }
}
