using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour
{
    public AudioSource bgm;
    float respawnTimer;
    GameObject respawnObj;

    float audioDelay = 1f;
    float audioTimer = 0; 

	// Update is called once per frame
	void Update ()
    {
	    if( respawnObj && respawnTimer >0 )
        {
            respawnTimer -= Time.deltaTime;

            if( respawnTimer <= 0)
            {
                audioTimer = audioDelay;
                respawnObj.SetActive( true );
            }
        }

        if( audioTimer > 0 )
        {
            audioTimer -= Time.deltaTime;

            if( audioTimer <= audioDelay*0.75f )
            {
                if( !bgm.isPlaying )
                {
                    bgm.volume = 0;
                }
                else
                {                    
                    bgm.volume = Mathf.Clamp01( 1 - audioTimer / audioDelay / 0.75f );
                }
            }
            
        }
    }

    public void Respawn( GameObject obj, float delay )
    {
        respawnObj = obj;
        respawnTimer = delay;
        //bgm.Pause();
        bgm.volume = 0;
    }
}
