using UnityEngine;
using System.Collections;
using System;

public class StatsSign : MonoBehaviour
{
    [SerializeField]
    SignMessage message;

    public string numStars;

    void Start()
    {
        if( string.IsNullOrEmpty( numStars ) )
            numStars = GameObject.FindObjectsOfType<Star>().Length.ToString();
    }

    void OnTriggerEnter2D( Collider2D coll )
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
        string timeText = string.Format("{0:D2}:{1:D2}:{2:D3}", 
            timeSpan.Hours*60+timeSpan.Minutes, 
            timeSpan.Seconds,
            timeSpan.Milliseconds            );

        message.message = 
            "STATS:\n" 
            + Score.stars + "/" + numStars +" stars collected\n" 
            + Score.deaths + " deaths\n"
            + timeText+"\n";
    }
}
