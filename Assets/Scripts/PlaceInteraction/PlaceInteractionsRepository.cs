using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Quests;
using UnityEngine;

namespace Assets.Scripts.PlaceInteraction
{
    public class PlaceInteractionsRepository : MonoBehaviour
    {
        [SerializeField] private DateTimeInfo _dateTimeInfo;
        [SerializeField] private PlayerStats _player;

        private Dictionary<string, List<Interaction>> _interactions = new Dictionary<string, List<Interaction>>();

        void Start()
        {
            FillRepository();
        }

        public List<Interaction> GetInteractionsByKey(string key)
        {
            return _interactions[key];
        }

        public void FillRepository()
        {
            var UNIInteractions = new List<Interaction>()
            {
                new Interaction("Сходить в столовку",
                    () => _dateTimeInfo.Hour >= 8 && _dateTimeInfo.Hour <= 18,
                    () =>
                    {
                        _player.Money -= 500;
                        _player.Hunger += 20;
                    },
                    "Поел, попил и теперь доволен"),

                new Interaction("[ДЕБАГ] Скипнуть 6 часов",
                    () => true,
                    () => _dateTimeInfo.Hour +=6,
                    "Ты обязательно справишься...."),

                new Interaction("[КВЕСТ] Отнести бумагулю",
                    () => QuestsRepository.GetQuestChainById(QuestChainIds.Test1).GetCurrentQuest()?.Id == QuestIds.PaperCourier,
                    () => StateBus.QuestCompleted += QuestChainIds.Test1,
                    "Квест может и выполнен, но на выходе к тебе подходит старичок и говорит что его бабушка застряла на дороге, иди ка помоги, паря"),

                new Interaction("[КВЕСТ] Поручение от студсовета",
                    () => _dateTimeInfo.Month == 9 && _dateTimeInfo.Week == 1 && QuestsRepository.GetQuestChainById(QuestChainIds.Aboba).GetFirstWaitingQuest()?.Id == QuestIds.AskAboba,
                    () => StateBus.QuestChainTaken += QuestChainIds.Aboba,
                    "Тебе нужно найти абобу у шарашки и попросить помощи"),

                new Interaction("[КВЕСТ] Сказать условия абобы",
                    () => QuestsRepository.GetQuestChainById(QuestChainIds.Aboba).GetCurrentQuest()?.Id == QuestIds.TellStudPermission,
                    () =>
                    {
                        StateBus.QuestCompleted += QuestChainIds.Aboba;
                        StateBus.NextEvent += "Сбор пекусов в начале октября";
                        StateBus.NextEventRequirements += "Влияние: 3 \n Участников: 3";
                    },
                    "Ну они согласны с условиями абобы, так что дуй к нему обратно, паря. Также тебе сказали что следующий большоу эвент будет........ Сбор пекусов. Надо бы подготовиться.")
            };

            _interactions.Add(TriggerPlaces.University, UNIInteractions);
        }
    }
}
