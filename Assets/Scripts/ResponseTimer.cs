using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ResponseTimer : MonoBehaviour {
    public void StartConversationWithTimer() {
        // Start the conversation and register a callback to check the current dialogue node.
        //DialogueManager.StartConversation("MyConversation", null, null, OnConversationUpdated);
    }

    private void OnConversationUpdated(Transform actor) {
        // Get the current dialogue entry.
        var currentDialogueEntry = DialogueManager.currentConversationState.subtitle.dialogueEntry;

        // Retrieve the 'TimerNum' field from the current dialogue entry.
        string timerNumValue = Field.LookupValue(currentDialogueEntry.fields, "TimerNum");

        if (!string.IsNullOrEmpty(timerNumValue)) {
            // Convert TimerNum to a float or int if needed
            float timerNum = float.Parse(timerNumValue);
            Debug.Log("TimerNum value: " + timerNum);

            // You can now use this timerNum value for your logic, such as setting a response timeout.
            SetResponseTimeout(timerNum);
        }
    }

    public void ResponseTimerStart() {
        // Get the current dialogue entry.
        var currentDialogueEntryTest = DialogueManager.currentConversationState;
        Debug.Log("currentDialogueEntryTest = " + currentDialogueEntryTest);

        var currentDialogueEntry = DialogueManager.currentConversationState.subtitle.dialogueEntry;


        // Retrieve the 'TimerNum' field from the current dialogue entry.
        string timerNumValue = Field.LookupValue(currentDialogueEntry.fields, "TimerNum");
        Debug.Log("TimerNum value before convert: " + timerNumValue);


        if (!string.IsNullOrEmpty(timerNumValue)) {
            // Convert TimerNum to a float or int if needed
            float timerNum = float.Parse(timerNumValue);
            Debug.Log("TimerNum value: " + timerNum);

            // You can now use this timerNum value for your logic, such as setting a response timeout.
            SetResponseTimeout(timerNum);
        }
        else {
            //Default
            SetResponseTimeout(1);

        }
    }

    private void SetResponseTimeout(float timeoutDuration) {
        // Set the response timeout duration using the TimerNum value.
        DialogueManager.displaySettings.inputSettings.responseTimeout = timeoutDuration;
    }
}