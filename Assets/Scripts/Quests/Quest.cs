using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Quests
{
    public class Quest
    {
        public enum EventStatus
        {
            Waiting,
            Current,
            Done
        }

        public Quest(string name, string description, string id, Func<bool> goal = null, Action effectOnGoalComplete = null)
        {
            Name = name;
            Description = description;
            Id = id;
            Goal = goal;
            EffectOnGoalComplete = effectOnGoalComplete;
            Status = EventStatus.Waiting;
        }

        public EventStatus Status { get; private set; }
        public Quest NextQuest { get; private set; }
        public string Name { get; }
        public string Description { get; }
        public string Id { get; }

        public Func<bool> Goal { get; }
        public Action EffectOnGoalComplete { get; }

        public void UpdateQuestStatus(EventStatus updatedStatus)
        {
            Status = updatedStatus;
        }

        public void SetNextQuest(Quest nextQuest)
        {
            NextQuest = nextQuest;
        }
    }
}
