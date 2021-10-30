using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Quests
{
    public class QuestUpdater : MonoBehaviour
    {
        [SerializeField] private List<Text> _questTexts;
        [SerializeField] private DateTimeInfo _dateTimeInfo;
        [SerializeField] private GameObject _dayEndPanel;

        void Update()
        {
            CheckTakenQuests();
            CheckCompletedQuests();
            CheckDayCompleted();
        }

        private void CheckTakenQuests()
        {
            if (StateBus.QuestsTaken.Value != null)
            {
                var takenQuest = QuestsRepository.GetQuestById(StateBus.QuestsTaken);
                takenQuest.UpdateQuestStatus(Quest.EventStatus.Current);
                UpdateQuestLog();
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
                UpdateQuestLog();
            }
        }

        private void CheckDayCompleted()
        {
            if (StateBus.DayCompleted)
            {
                foreach (var quest in QuestsRepository.GetCurrentQuests())
                {
                    if (quest.DeadlineWeek == _dateTimeInfo.Week)
                    {
                        quest.UpdateQuestStatus(Quest.EventStatus.Overdue);
                    }
                }
                ShowDayEndPanel();
                UpdateQuestLog();
            }
        }

        async void ShowDayEndPanel()
        {
            _dayEndPanel.SetActive(true);
            var sleep = new Task(() => Thread.Sleep(3000));
            sleep.Start();
            await sleep;
            _dayEndPanel.SetActive(false);
        }

        private void UpdateQuestLog()
        {
            var currentQuests = QuestsRepository.GetCurrentQuests();
            for (var i = 0; i < _questTexts.Count; i++)
            {
                _questTexts[i].text = i >= currentQuests.Length ? "" : currentQuests[i].Name;
            }
        }
    }
}
