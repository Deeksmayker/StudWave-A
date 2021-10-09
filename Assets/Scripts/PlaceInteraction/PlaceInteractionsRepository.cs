using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PlaceInteraction
{
    public class PlaceInteractionsRepository : MonoBehaviour
    {
        private TriggerPlaces _places = new TriggerPlaces();
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
                    "Поел, попил и теперь доволен")
            };

            _interactions.Add(_places.University, UNIInteractions);
        }
    }
}
