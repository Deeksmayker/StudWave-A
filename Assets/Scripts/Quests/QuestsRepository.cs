using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class QuestsRepository : MonoBehaviour
    {
        void Start()
        {
            FillRepository();
        }

        private static Dictionary<string, Quest> _questsDictionary = new Dictionary<string, Quest>();
        [SerializeField] private PlayerStats _playerStats;

        private void FillRepository()
        {
            var test1 = new Quest("Отнести бумагулю", "Нужно отнести бумагулю в уник", QuestIds.Test1,
                () => StateBus.QuestsComplete == QuestIds.Test1, () => _playerStats.Mood += 20);
            var test2 = new Quest("Помоги бабульке", "Нужно помочь бабульке на улице", QuestIds.Test2,
                () => StateBus.QuestsComplete == QuestIds.Test2, () => _playerStats.Health += 30);
            test1.SetNextQuest(test2);

            _questsDictionary.Add(QuestIds.Test1, test1);
            _questsDictionary.Add(QuestIds.Test2, test2);
        }

        public static Quest GetQuestById(string id)
        {
            return _questsDictionary[id];
        }
    }
}
