using UnityEngine;
using System.Collections;

public class Jumper : Entity
{
    BoxCollider2D boxCollider;

    bool squashed = false;

	// Use this for initialization
	protected override void Start ()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {                        
        animator.SetBool( "grounded", grounded );
        animator.SetBool( "squashed", squashed );

        if( grounded && !squashed)
        {
            rigidBody2D.velocity = new Vector2( (int) direction * 2, 8 );
        }
    }

    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.tag == "Player" )
        {
            if( coll.transform.position.y - 0.1 >=
                transform.position.y + boxCollider.size.y / 2 + boxCollider.offset.y )
            {
                squashed = true;
                coll.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2( 0, 15 );
                coll.gameObject.GetComponent<Hero>().Land();
                //boxCollider.enabled = false;
            }

            //coll.gameObject.SendMessage( "ApplyDamage", 10 );
        }
        else
        {            
            // Horizontal collision
            if( Mathf.Abs(coll.contacts[0].normal.x) > Mathf.Abs( coll.contacts[0].normal.y) )
            {
                if( direction == Direction.Left && coll.contacts[0].normal.x > 0 )
                {
                    direction = Direction.Right;
                }
                else if( direction == Direction.Right && coll.contacts[0].normal.x < 0 )
                {
                    direction = Direction.Left;
                }                
            }
        }

    }
    
}
