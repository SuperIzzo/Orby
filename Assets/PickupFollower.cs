using UnityEngine;
using System.Collections;

public class PickupFollower : MonoBehaviour
{
    public float speed;

    GameObject target;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
	    if( target )
        {
            Vector3 targetPos = target.transform.position;
            Vector3 pos = transform.position;

            Vector2 move = new Vector2( targetPos.x - pos.x, targetPos.y - pos.y );

            // the greater the distance is the faster it will travel
            float distFactor = Mathf.Clamp( move.sqrMagnitude, 1, 10 );
            move = move.normalized * distFactor * speed * Time.fixedDeltaTime;

            pos.x += move.x;
            pos.y += move.y;

            transform.position = pos;
        }
	}

    void OnTriggerEnter2D( Collider2D coll )
    {
        if( coll.tag == "Player" )
        {
            target = coll.gameObject;
        }
    }
}
