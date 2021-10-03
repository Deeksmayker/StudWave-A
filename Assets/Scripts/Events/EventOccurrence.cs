using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOccurrence : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    void OnTriggerEnter()
    {
        var button = _panel.AddComponent<Button>();
    }
}
