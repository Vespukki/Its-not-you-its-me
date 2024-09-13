using PixelCrushers.DialogueSystem;
using UnityEngine;

public class AngerUtils : MonoBehaviour {
    
    public static void IncrementAnger(float amount)
    {
        float anger = DialogueLua.GetVariable("Anger").asFloat;
        DialogueLua.SetVariable("Anger", anger + amount);
    }

}