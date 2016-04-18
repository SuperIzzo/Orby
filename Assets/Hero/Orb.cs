using UnityEngine;
using System.Collections;

public class Orb : MonoBehaviour
{
    Rigidbody2D rigidBody2D;

    [SerializeField]
    float orbTime = 3;

    [SerializeField]
    GameObject hero;

    float timer;

	// Use this for initialization
	void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        timer = orbTime;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if( Input.GetButtonUp("Action") || timer<=0 )
        {
            timer = orbTime;
            hero.SetActive( true );
            hero.transform.position = transform.position;
            hero.GetComponent<Rigidbody2D>().velocity = rigidBody2D.velocity;
            gameObject.SetActive( false );
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rigidBody2D.AddForce( new Vector2(
            Input.GetAxis( "Horizontal" ),
            Input.GetAxis( "Vertical" ) )  * 8 );
	}
}
