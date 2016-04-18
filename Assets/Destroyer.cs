using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D( Collider2D coll )
    {
        Hero hero = coll.GetComponent<Hero>();

        if( hero )
        {
            hero.Die();
        }
    }
}
