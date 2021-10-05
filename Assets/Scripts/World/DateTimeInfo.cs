using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeInfo : MonoBehaviour
{
    [SerializeField] private PlayerStats _player;

    public bool IsWentToPairs;

    #region EnumAndProperties

    public enum Months
    {
        ������ = 1,
        ������� = 2,
        ���� = 3,
        ������ = 4,
        ��� = 5,
        ���� = 6,
        ���� = 7,
        ������ = 8,
        �������� = 9,
        ������� = 10,
        ������ = 11,
        ������� = 12
    }

    private int year = 2020;

    public int Year
    {
        get => year;
    }

    private int month = 9;

    public int Month
    {
        get => month;
        set
        {
            if (value > 12)
            {
                value -= 12;
                year++;
            }

            if (value == 9)
                Course++;

            month = value;
        }
    }

    private int week = 1;

    public int Week
    {
        get => week;
        set
        {
            if (value > 4)
            {
                value -= 4;
                Month++;
            }

            week = value;
        }
    }

    private int hour = 8;

    public int Hour
    {
        get => hour;
        set
        {
            _player.Hunger -= (value - Hour) * 2;
            if (value >= 24)
            {
                value -= 24;
                Week++;
                if (IsWentToPairs)
                    _player.Study += 5;
                else
                    _player.Study -= 10;
                IsWentToPairs = false;
            }

            hour = value;
        }
    }

    private float minuteF = 0;

    public int Minute
    {
        get => (int)MinuteF;
    }

    public float MinuteF
    {
        get => minuteF;
        set
        {
            if (value >= 60)
            {
                value -= 60;
                Hour++;
            }

            minuteF = value;
        }
    }

    private int course = 1;

    public int Course
    {
        get => course;
        set => course = value < course ? throw new Exception("���� ���� ������, ���") : value;
    }

    #endregion

    public string GetDateTime()
    {
        var hourStr = Hour > 9 ? Hour.ToString() : "0" + Hour;
        var minuteStr = Minute > 9 ? Minute.ToString() : "0" + Minute;

        return String.Format("{0} \n������ {1} \n{2}:{3}", (Months)month, Week, hourStr, minuteStr);
    }
}
