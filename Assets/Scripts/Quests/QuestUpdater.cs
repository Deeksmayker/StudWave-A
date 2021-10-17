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
            if (StateBus.QuestsTaken.Value != null)
            {
                foreach (var questText in _questTexts)
                {
                    if (questText != null)
                    {
                        questText.text = QuestsRepository.GetQuestById(StateBus.QuestsTaken).Name;
                        break;
                    }
                }
            }

            if (StateBus.QuestsComplete.Value != null)
            {
                QuestsRepository.GetQuestById(StateBus.QuestsComplete).EffectOnGoalComplete();
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
