using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerSetter : MonoBehaviour
{
    Image image;
    private void Awake()
    {
     image = GetComponent<Image>();

    }

    void Update()
    {
        DialogueLua.SetVariable("AngerWaitTime", DialogueLua.GetVariable("Anger").AsFloat * DialogueLua.GetVariable("Timeout").AsFloat);

        var startColor = image.color;

        image.color = new Vector4(image.color.r, image.color.g, image.color.b, DialogueLua.GetVariable("Anger").AsFloat);
        
    }
}
