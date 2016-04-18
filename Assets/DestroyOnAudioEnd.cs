using UnityEngine;
using System.Collections;

public class DestroyOnAudioEnd : MonoBehaviour
{

    AudioSource audio;

	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if( !audio.isPlaying )
            Destroy( gameObject );
	}
}
