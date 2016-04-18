using UnityEngine;
using System.Collections;
using System;

public class Hero : Entity
{
    [SerializeField]
    float charSpeed = 5;

    [SerializeField]
    float jumpPower = 6;    
    

    [SerializeField]
    GameObject orb;   
    

    float speed = 0;
    
    bool jumpButtonDown;
    bool orbed = false;

    public AudioClip jumpSFX;
    public AudioClip dieSFX;
    public GameObject shatter;

    public Respawner respawner;

    private Vector3 lastSavePos;

    private float shifting;
    private float unshifting = 1;
    private float orbRadius = 0.4f;
    



    // Use this for initialization
    protected override void Start ()
    {
        base.Start();        
    }
	

    protected void OnEnable()
    {
        unshifting = orbRadius;
    }

    protected override void Update()
    {
        if( Input.GetButtonDown( "Action" ) && !orbed )
        {
            shifting = unshifting;
            orbed = true;
        }
        else if( Input.GetButtonUp( "Action" ) && shifting > orbRadius )
        {
            unshifting = shifting;
            shifting = orbRadius;            
        }


        if( shifting>orbRadius)
        {
            shifting -= Time.deltaTime * 6;

            transform.localScale = new Vector3( (int)direction * shifting, shifting, 1);

            if( shifting<= orbRadius )
            {
                orb.SetActive( true );
                orb.transform.position = transform.position;
                orb.GetComponent<Rigidbody2D>().velocity = rigidBody2D.velocity;
                gameObject.SetActive( false );
            }

            return;
        }
        else if ( unshifting <1 )
        {
            unshifting += Time.deltaTime * 6;

            if( unshifting > 1 )
                unshifting = 1;

            transform.localScale = new Vector3( (int) direction * unshifting, unshifting, 1 );
        }

        base.Update();

        jumpButtonDown |= Input.GetButtonDown("Jump");
        jumpButtonDown &= !Input.GetButtonUp( "Jump" );                
    }


	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector2 velocity = rigidBody2D.velocity;
        
        if( grounded )
        {
            Land();

            if( jumpButtonDown )
            {
                jumpButtonDown = false;
                velocity.y += jumpPower;
                PlayJumpSound();
            }
        }

        float move = Input.GetAxis( "Horizontal" );
        speed = Mathf.Abs( move );

        if( move > 0 )
            direction = Direction.Right;
        else if( move < 0 )
            direction = Direction.Left;                

        velocity.x = move * charSpeed;
        rigidBody2D.velocity = velocity;

        animator.SetFloat( "speed", speed );
        animator.SetBool( "grounded", grounded );
        animator.SetFloat( "v_speed", velocity.y );
    }


    public void Land()
    {
        orbed = false;
        lastSavePos = transform.position;
    }


    private void PlayJumpSound()
    {
        SFXUtility.PlaySFX( jumpSFX );   
    }

    public void Die()
    {
        GameObject.Instantiate( shatter, transform.position, Quaternion.identity );

        Vector3 checkPoint = Checkpoint.touchedCheckpoint.transform.position;
        transform.position =  new Vector3( checkPoint.x, checkPoint.y+1);
        respawner.Respawn( gameObject, 1 );

        Score.deaths++;

        SFXUtility.PlaySFX( dieSFX );

        gameObject.SetActive( false );        

        //Destroy( gameObject );
    }
}
