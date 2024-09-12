using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerSliderDisplay : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        
    }
    void Update()
    {
        DialogueLua.SetVariable("AngerWaitTime", DialogueLua.GetVariable("Anger").AsFloat * DialogueLua.GetVariable("Timeout").AsFloat);

        Debug.Log("Wait TIme:" + DialogueLua.GetVariable("AngerWaitTime").AsFloat);
        float anger =  1 - DialogueLua.GetVariable("Anger").AsFloat;

        float finalX = slider.value - anger;

        finalX = Mathf.Clamp(finalX, 0, 1);

        GetComponent<RectTransform>().localScale = new Vector3(finalX, GetComponent<RectTransform>().localScale.y);
    }
}
