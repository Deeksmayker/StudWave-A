using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKeyHandler : MonoBehaviour
{
    [SerializeField] private PlaceInteractionOccurrence _interactionOccurrence;
    [SerializeField] private string _key;

    void OnTriggerEnter()
    {
        Debug.Log("Вошел в триггер " + _key);
        _interactionOccurrence.SetPanelButtons(_key);
    }
}
