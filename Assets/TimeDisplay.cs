using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class TimeDisplay : MonoBehaviour
{
    Text text;


    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);

        text.text =
            string.Format( "{0:D2}:{1:D2}:{2:D3}",
                timeSpan.Hours * 60 + timeSpan.Minutes,
                timeSpan.Seconds,
                timeSpan.Milliseconds );
    }
}
