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

        private static Dictionary<string, QuestChain> _questChainsDictionary = new Dictionary<string, QuestChain>();
        [SerializeField] private PlayerStats _playerStats;

        private void FillRepository()
        {
            var test1 = new QuestChain(QuestChainIds.Test1, new Quest[]
            {
                new Quest(
                    "Отнести бумагулю",
                    "Нужно отнести бумагулю в уник",
                    QuestIds.PaperCourier,
                    2,
                  //  () => StateBus.QuestCompleted == QuestChainIds.Test1,
                    () => _playerStats.Mood += 20),

                new Quest(
                    "Помоги бабульке",
                    "Нужно помочь бабульке на улице",
                    QuestIds.HelpBabka,
                    2,
                   // () => StateBus.QuestCompleted == QuestChainIds.Test2,
                    () => _playerStats.Health += 30)
            });

            var aboba = new QuestChain(QuestChainIds.Aboba, new Quest[]
            {
                new Quest(
                    "Сходи ка к абобе к шарашке за углом",
                    "fas",
                    QuestIds.AskAboba,
                    2,
                    () => _playerStats.Mood -= 10),
                new Quest(
                    "Дуй ка в студсовет выпрашивать подачки для абобы",
                    "SD",
                    QuestIds.TellStudPermission,
                    2,
                    () => _playerStats.Mood -= 10),
                new Quest(
                    "Обратно к абобе, срочно",
                    "SD",
                    QuestIds.ReturnToAboba,
                    2,
                    () => _playerStats.Mood += 30)
            });
            

            _questChainsDictionary.Add(QuestChainIds.Test1, test1);
            _questChainsDictionary.Add(QuestChainIds.Aboba, aboba);
        }

        public static QuestChain GetQuestChainById(string id)
        {
            return _questChainsDictionary[id];
        }

        public static Quest[] GetCurrentQuests()
        {
            return _questChainsDictionary.Values.ToList()
                .FindAll(qc => qc.GetCurrentQuest() != null)
                .Select(qc => qc.GetCurrentQuest())
                .ToArray();
        }
    }
}
