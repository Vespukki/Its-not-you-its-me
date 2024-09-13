using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerSetter : MonoBehaviour
{
    void Update()
    {
        DialogueLua.SetVariable("AngerWaitTime", DialogueLua.GetVariable("Anger").AsFloat * DialogueLua.GetVariable("Timeout").AsFloat);

    }
}
