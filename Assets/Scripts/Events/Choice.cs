using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public Choice(string text, string successText, string failText, Func<bool> successCriteria = null,
        Action<bool> effectOnPlayer = null)
    {
        Text = text;
        SuccessText = successText;
        FailText = failText;
        SuccessCriteria = successCriteria;
        EffectOnPlayer = effectOnPlayer;
    }

    public string Text { get; }
    public string SuccessText {get;}
    public string FailText { get; }

    public Func<bool> SuccessCriteria {get;}
    public Action<bool> EffectOnPlayer {get;}
}
