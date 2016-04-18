using UnityEngine;
using System.Collections;

public class SFXUtility : MonoBehaviour
{
    static SFXUtility instance;

    public AudioSource sfxType;

	// Use this for initialization
	void Start ()
    {
        if( !instance )
            instance = this;
	}
    

	// Update is called once per frame
	void Update () {
	
	}


    public static void PlaySFX( AudioClip clip )
    {
        AudioSource source = GameObject.Instantiate( instance.sfxType );
        source.clip = clip;
        source.Play();
    }
}
