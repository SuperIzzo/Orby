using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour
{
    public AudioSource bgm;
    float respawnTimer;
    GameObject respawnObj;
	
	// Update is called once per frame
	void Update ()
    {
	    if( respawnObj && respawnTimer >0 )
        {
            respawnTimer -= Time.deltaTime;

            if( respawnTimer <= 0)
            {
                bgm.Play();
                respawnObj.SetActive( true );
            }
        }
	}

    public void Respawn( GameObject obj, float delay )
    {
        respawnObj = obj;
        respawnTimer = delay;
        bgm.Stop();
    }
}
