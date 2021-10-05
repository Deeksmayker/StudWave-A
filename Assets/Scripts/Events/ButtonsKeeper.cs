using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsKeeper : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    public Button[] GetEventButtons()
    {
        return _buttons;
    }
}
