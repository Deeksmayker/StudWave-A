using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event 
{
    public Event(string text)
    {
        Text = text;

        Choices = new List<Choice>();
    }

    public string Text { get; }

    public List<Choice> Choices { get; set; }

    public void AddChoice(Choice choice)
    {
        Choices.Add(choice);
    }
}
