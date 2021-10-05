using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsRepository : MonoBehaviour
{
    void Start()
    {
        FillRepository();
    }

    public Dictionary<string, List<Event>> Events { get; } = new Dictionary<string, List<Event>>();

    [SerializeField] private TriggerPlaces _places;

    public Dictionary<string, List<Event>> GetEvents()
    {
        return Events;
    }

    private void FillRepository()
    {
        var UNIlist = new List<Event>()
        {
            new Event("Абоба?")
            {
                Choices =
                {
                    new Choice("SDF", "SFDSDF", "EWQR"),
                    new Choice("SDF", "SFDSDF", "EWQR"),
                    new Choice("SDF", "SFDSDF", "EWQR"),
                    new Choice("SDF", "SFDSDF", "EWQR")
                    
                }
            }
        };

        Events.Add(_places.University, UNIlist);
    }
}