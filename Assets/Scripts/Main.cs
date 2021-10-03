using System.Collections;
using System.Collections.Generic;
//using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private Text dateTimeText;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        QualitySettings.antiAliasing = 0;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        //dateTimeText.text = DateTimeInfo.Instance.GetDateTime();
    }
}