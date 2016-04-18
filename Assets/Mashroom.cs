using UnityEngine;
using System.Collections;

public class Mashroom : Entity
{
    public float squashTime;
    public CircleCollider2D hatCollider;
    public GameObject damageArea;
    bool squashed { get { return squash_timer > 0; } }

    float squash_timer;    

    protected override void Update()
    {
        base.Update();

        if( squash_timer > 0 )
            squash_timer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        animator.SetBool( "squashed", squashed );

        damageArea.SetActive( !squashed );

        if( !squashed )
        {
            rigidBody2D.velocity = 
                new Vector2( (float) direction * 3, rigidBody2D.velocity.y );
        }
    }

    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.tag == "Player" )
        {
            if( coll.transform.position.y - 0.1 >=
                transform.position.y + hatCollider.radius + hatCollider.offset.y )
            {
                squash_timer = squashTime;

                coll.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2( 0, 15 );

                Hero hero = coll.gameObject.GetComponent<Hero>();

                if( hero )
                    hero.Land();
            }
        }
        else
        {
            // Horizontal collision
            if( Mathf.Abs( coll.contacts[0].normal.x ) > Mathf.Abs( coll.contacts[0].normal.y ) )
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

