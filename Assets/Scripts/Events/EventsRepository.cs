using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Quests;
using UnityEngine;

public class EventsRepository : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private StudCouncil _studCouncil;

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
            new Event("�����?", () => true)
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
            new Event("Подбежал на улице чел и попросил отнести справку в вуз",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Test1).GetFirstWaitingQuest()?.Id == QuestIds.PaperCourier)
            {
                Choices =
                {
                    new Choice("Взять квест", "Квест получен", "", () => true,
                        b =>
                        {
                            StateBus.QuestChainTaken += QuestChainIds.Test1;
                        })
                }
            },
            new Event("Ну ты нашел эту бабку, реально застряла",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Test1).GetCurrentQuest()?.Id == QuestIds.HelpBabka)
            {
                Choices =
                {
                    new Choice("Ну пора бы помочь бабабульке", "Красава, бабка спасена от неотвратимости бытия", "",
                        () => true,
                        b => StateBus.QuestCompleted += QuestChainIds.Test1)
                }
            } 
        };

        var ABOBAlist = new List<Event>()
        {
            new Event(
                "Ну пришел ты к этому абобе и говоришь: Тоси боси, есть вопросики, пошли поможешь. Он, в свою очередь, был непреклонен и сказал: только за банку адреналин раша.",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Aboba).GetCurrentQuest()?.Id ==
                      QuestIds.AskAboba)
            {
                Choices =
                {
                    new Choice("ЛАдно, паря, схожу спрошу как у них с такими жесткими условиями обстоит вопрос",
                        "Ну и иди", "",
                        () => true,
                        b => StateBus.QuestCompleted += QuestChainIds.Aboba),
                    new Choice("Ты хуйни то не неси, давай отсюдова, нам такие хуйноносы не нужны", "Э", "",
                        () => true,
                        b => StateBus.QuestChainFailed += QuestChainIds.Aboba)
                }
            },

            new Event(
                "Абоба стоит и ждет хороших вестей",
                () => QuestsRepository.GetQuestChainById(QuestChainIds.Aboba).GetCurrentQuest()?.Id == QuestIds.ReturnToAboba)
            {
                Choices =
                {
                    new Choice("ХОрошие вести, абоба, будет тебе этот адреналин",
                        "Абоба очень рад и присоединяется к вашей хуйне", "",
                        () => true,
                        b =>
                        {
                            StateBus.QuestCompleted += QuestChainIds.Aboba;
                            _studCouncil.AddMembersCount();
                        })
                }
            }
        };

        _events.Add(TriggerPlaces.University, UNIlist);
        _events.Add(TriggerPlaces.Street, STREETlist);
        _events.Add(QuestChainIds.Aboba, ABOBAlist);
    }
}