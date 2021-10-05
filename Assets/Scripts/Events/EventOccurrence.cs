using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOccurrence : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private EventsRepository _events;
    [SerializeField] private string _key;

    [SerializeField] private ButtonsKeeper _buttonsKeeper;

    void OnTriggerEnter()
    {
        Debug.Log(_key + " trigger");

        var currentEvent = GetEventByKey(_key);
        var buttons = _buttonsKeeper.GetEventButtons();

        _panel.SetActive(true);

        _panel.GetComponentInChildren<Text>().text = currentEvent.Text;

        for (var i = 0; i < currentEvent.Choices.Count; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = currentEvent.Choices[i].Text;
            buttons[i].gameObject.SetActive(true);
        }
    }

    private Event GetEventByKey(string key)
    {
        return _events.GetEvents()[_key][0];
    }
}
