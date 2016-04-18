using UnityEngine;
using System.Collections;

public class StatsSign : MonoBehaviour
{
    [SerializeField]
    SignMessage message;
    

    void OnTriggerEnter2D( Collider2D coll )
    {
        message.message = "STATS:\n" + Score.stars + "/64 stars collected\n" + Score.deaths +
            " deaths\n";
    }
}
