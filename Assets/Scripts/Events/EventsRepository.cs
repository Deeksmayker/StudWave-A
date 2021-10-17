using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Quests;
using UnityEngine;

public class EventsRepository : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    void Start()
    {
        FillRepository();
    }

    private static Dictionary<string, List<Event>> _events = new Dictionary<string, List<Event>>();

    public static Dictionary<string, List<Event>> GetEvents()
    {
        return _events;
    }

    private void FillRepository()
    {
        var UNIlist = new List<Event>()
        {
            new Event("�����?")
            {
                Choices =
                {
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                    new Choice("SDF", "SFDSDF", "EWQR", () => _playerStats.KnowledgeLevel >= 3, b => _playerStats.Mood += 20),
                }
            }
        };

        var STREETlist = new List<Event>()
        {
            new Event("Подбежал на улице чел и попросил отнести справку в вуз")
            {
                Choices =
                {
                    new Choice("Взять квест", "Квест получен", "", () => true,
                        b =>
                        {
                            StateBus.QuestsTaken += QuestIds.Test1;
                            QuestsRepository.GetQuestById(QuestIds.Test1).UpdateQuestStatus(Quest.EventStatus.Current);
                        })
                }
            }
        };

        _events.Add(TriggerPlaces.University, UNIlist);
        _events.Add(TriggerPlaces.Street, STREETlist);
    }
}