using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PlaceInteraction
{
    public class Interaction
    {
        public Interaction(string text, Func<bool> appearanceCriteria, Action effect, string textAfterChoice)
        {
            Text = text;
            AppearanceCriteria = appearanceCriteria;
            Effect = effect;
            TextAfterChoice = textAfterChoice;
        }

        public string Text { get; }
        public string TextAfterChoice { get; }
        public Func<bool> AppearanceCriteria { get; }
        public Action Effect { get; }
    }
}
