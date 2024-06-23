using Nakama;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json; // Make sure to include this namespace
using System.Text;

public class DiceSyncManager : MonoBehaviour
{
    private NakamaManager nakamaManager;

    async void Start()
    {
        nakamaManager = FindObjectOfType<NakamaManager>();
        nakamaManager.socket.ReceivedMatchState += OnReceivedMatchState;

        // Join or create a match
        var match = await nakamaManager.socket.CreateMatchAsync();
        nakamaManager.matchId = match.Id;
    }

    public void RollDice()
    {
        // Trigger local dice roll
        int result = RollLocalDice();
        // Broadcast the dice roll result to the other player
        SendDiceResult(result);
    }

    private int RollLocalDice()
    {
        // Roll the dice locally and return the result
        int result = Random.Range(1, 7);
        ShowDiceResult(result); // Show the result locally
        return result;
    }

    private void SendDiceResult(int result)
    {
        var state = new Dictionary<string, int> { { "dice_result", result } };
        string jsonState = JsonConvert.SerializeObject(state);
        byte[] stateBytes = Encoding.UTF8.GetBytes(jsonState);
        nakamaManager.socket.SendMatchStateAsync(nakamaManager.matchId, 0, stateBytes);
    }

    private void OnReceivedMatchState(IMatchState state)
    {
        string jsonState = Encoding.UTF8.GetString(state.State);
        var resultState = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonState);
        int result = resultState["dice_result"];
        ShowDiceResult(result);
    }

    private void ShowDiceResult(int result)
    {
        // Display the dice result on both players' UI
        Debug.Log("Dice Result: " + result);
    }
}
