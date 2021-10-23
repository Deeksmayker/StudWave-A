using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Quests
{
    public class QuestUpdater : MonoBehaviour
    {
        [SerializeField] private List<Text> _questTexts;

        void Update()
        {
            CheckTakenQuests();
            CheckCompletedQuests();
        }

        private void CheckTakenQuests()
        {
            if (StateBus.QuestsTaken.Value != null)
            {
                var takenQuest = QuestsRepository.GetQuestById(StateBus.QuestsTaken);
                takenQuest.UpdateQuestStatus(Quest.EventStatus.Current);
                foreach (var questText in _questTexts)
                {
                    if (questText != null)
                    {
                        questText.text = takenQuest.Name;
                        break;
                    }
                }
            }
        }

        private void CheckCompletedQuests()
        {
            if (StateBus.QuestsComplete.Value != null)
            {
                var completedQuest = QuestsRepository.GetQuestById(StateBus.QuestsComplete);
                completedQuest.UpdateQuestStatus(Quest.EventStatus.Done);
                completedQuest.EffectOnGoalComplete();
                if (completedQuest.NextQuest != null)
                    StateBus.QuestsTaken += completedQuest.NextQuest.Id;
                foreach (var questText in _questTexts)
                {
                    if (questText.text == QuestsRepository.GetQuestById(StateBus.QuestsComplete).Name)
                    {
                        questText.text = "";
                        break;
                    }
                }
            }
        }
    }
}
