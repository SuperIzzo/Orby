using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Star : MonoBehaviour
{
    public  AudioClip pickupSFX;
    public List<Sprite> sprites;

    SpriteRenderer spRenderer;    


    // Use this for initialization
    void Start ()
    {
        spRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if( Random.value > 0.3f )
        {
            spRenderer.sprite = sprites[Random.Range( 0, sprites.Count )];
            transform.rotation = Quaternion.Euler( 0, 0, Random.Range( 0, 360.0f ) );
        }
    }

    void OnTriggerEnter2D( Collider2D coll )
    {
        if( coll.tag == "Player")
        {
            SFXUtility.PlaySFX( pickupSFX );
            Score.stars++;
            Destroy( gameObject );
        }
    }
}
