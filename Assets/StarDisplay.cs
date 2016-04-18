using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour
{
    private int displayStars = 0;

    Text text;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if( displayStars != Score.stars )
        {
            displayStars = Score.stars;
            text.text = "x" + displayStars;
        }
	}
}
