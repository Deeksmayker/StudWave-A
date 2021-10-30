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
                    () => QuestsRepository.GetQuestById(QuestIds.Test1).Status == Quest.EventStatus.Current,
                    () => StateBus.QuestsComplete += QuestIds.Test1,
                    "Квест может и выполнен, но на выходе к тебе подходит старичок и говорит что его бабушка застряла на дороге, иди ка помоги, паря")
            };

            _interactions.Add(TriggerPlaces.University, UNIInteractions);
        }
    }
}
