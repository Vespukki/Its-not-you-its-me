using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    public class SequencerCommandAngerDelay : SequencerCommand
    { // Rename to SequencerCommand<YourCommand>

        public void Awake()
        {
            float timer = GetParameterAsFloat(0);
            Sequencer.PlayCommand("Delay", false, 0, string.Empty, "done", (DialogueLua.GetVariable("Anger").asFloat * timer).ToString());
            Stop();
        }

        public void Update()
        {
            // Add any update code here. When the command is done, call Stop().
            // If you've called stop above in Awake(), you can delete this method.
        }

        public void OnDestroy()
        {
            // Add your finalization code here. This is critical. If the sequence is cancelled and this
            // command is marked as "required", then only Awake() and OnDestroy() will be called.
            // Use it to clean up whatever needs cleaning at the end of the sequencer command.
            // If you don't need to do anything at the end, you can delete this method.
        }

    }

}


/**/
