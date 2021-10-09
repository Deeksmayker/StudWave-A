using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlow : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DateTimeInfo _dateTimeInfo;

    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (!_rigidbody.IsSleeping())
        {
            _dateTimeInfo.MinuteF += Time.deltaTime;
        }
    }
}
