

using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using System.Threading;
using PixelCrushers.DialogueSystem.ChatMapper;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    public class SequencerCommandEnableResponse : SequencerCommand
    {

        public void Awake()
        {
            int objectToEnable = GetParameterAsInt(0) - 1;

            var dialogueManager = GameObjectUtility.FindFirstObjectByType<DialogueSystemController>();

            Lua.Result canRefreshVar = DialogueLua.GetVariable("CanRefresh");
            bool canRefresh = canRefreshVar.AsBool;
            Debug.Log("CanRefresh variable is: " + canRefresh);

            StandardUIMenuPanel test2 = DialogueManager.instance.GetComponentInChildren<StandardUIMenuPanel>();

            int currentIndex = 3;

            Response currentResponse = DialogueManager.instance.conversationController.GetCurrentResponse();

            List<GameObject> buttons = DialogueManager.instance.GetComponentInChildren<StandardUIMenuPanel>().instantiatedButtons;
            for ( int i = 0; i < buttons.Count; i++ ) {
                StandardUIResponseButton test3 = buttons[i].GetComponent<StandardUIResponseButton>();
                if (test3.text == currentResponse.formattedText.text) {
                    currentIndex = i;
                }
            }
            //foreach (GameObject button in DialogueManager.instance.GetComponentInChildren<StandardUIMenuPanel>().instantiatedButtons) {
            //    StandardUIResponseButton test3 = button.GetComponent<StandardUIResponseButton>();
            //    if (test3.text == currentResponse.formattedText.text) {
            //        currentIndex = 0;
            //    }

            //    Debug.Log("test me");
            //}


            Debug.Log("Current Index is: " + currentIndex);


            // make sure it doesnt loop
            if (canRefresh) {
                StandardUITimer timer = DialogueManager.instance.GetComponentInChildren<StandardUITimer>();
                float currentTime = timer.GetTime();
                Debug.Log(currentTime);
                Debug.Log(timer.gameObject.name);

                DialogueManager.instance.conversationController.UpdateResponses();
                timer.SetTime(currentTime);

                Response newSelectedResponse = dialogueManager.currentConversationState.pcResponses[currentIndex];
                dialogueManager.conversationController.SetCurrentResponse(newSelectedResponse);

                
                StandardUIMenuPanel responseMenuPanel = DialogueManager.instance.GetComponentInChildren<StandardUIMenuPanel>();

                EventSystem eventSystem = UnityEngine.EventSystems.EventSystem.current;

                eventSystem.SetSelectedGameObject(responseMenuPanel.instantiatedButtons[currentIndex]);

                //DialogueManager.instance.conversationController.GotoCurrentResponse();

                DialogueLua.SetVariable("CanRefresh", false);

            }






            // IF THE OPTION IS GETTING SELCTED WHEN DISABLED ADD THIS BACK MAYBE
            //Response responseToEnable = dialogueManager.currentConversationState.pcResponses[objectToEnable];
            //Debug.Log("response " + responseToEnable.formattedText.text);

            //StandardUIMenuPanel responseMenuPanel = DialogueManager.instance.GetComponentInChildren<StandardUIMenuPanel>();
            //Debug.Log("responseMenuPanel " + responseMenuPanel.gameObject.name);

            //if (responseMenuPanel != null) {
            //    foreach(var button in responseMenuPanel.instantiatedButtons) {
            //        Debug.Log("button " + button);
            //    }
            //    responseMenuPanel.instantiatedButtons[objectToEnable].gameObject.SetActive(false);
            //}

            

            //responseToEnable.enabled = false;

            //DialogueManager.currentConversationState.pcResponses= dialogueManager.currentConversationState.


            Stop();
 
        }



    }

}


