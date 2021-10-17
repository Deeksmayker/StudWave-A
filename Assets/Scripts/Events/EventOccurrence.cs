using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventOccurrence : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _intermediatePanel;
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
            var currentButton = buttons[i];
            var choice = currentEvent.Choices[i];
            
            currentButton.onClick.AddListener(() =>
            {
                choice.Effect(choice.SuccessCriteria());
                _intermediatePanel.GetComponentInChildren<Text>().text =
                    choice.SuccessCriteria() ? choice.SuccessText : choice.FailText;
                _panel.gameObject.SetActive(false);
                _intermediatePanel.gameObject.SetActive(true);
            });

            currentButton.GetComponentInChildren<Text>().text = choice.Text;
            currentButton.gameObject.SetActive(true);
        }
    }

    private Event GetEventByKey(string key)
    {
        return EventsRepository.GetEvents()[_key][0];
    }
}
