using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint touchedCheckpoint;

    public bool starting = false;
    public Sprite checkedSprite;
    public Sprite uncheckedSprite;

    SpriteRenderer spRender;

    void Start()
    {
        if( starting )
            touchedCheckpoint = this;
         
        spRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
	    if( touchedCheckpoint==this )
        {
            spRender.sprite = checkedSprite;
        }
        else
        {
            spRender.sprite = uncheckedSprite;
        }
	}


    void OnTriggerEnter2D( Collider2D coll )
    {
        if( coll.tag == "Player" )
        {
            touchedCheckpoint = this;
        }
    }
}
