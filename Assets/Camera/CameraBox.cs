using UnityEngine;
using System.Collections;

public class CameraBox : MonoBehaviour
{

    [SerializeField]
    Vector2 min;

    [SerializeField]
    Vector2 max;
	
	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 newPos = transform.position;

	    if( newPos.x < min.x )
            newPos.x = min.x;

        if( newPos.y < min.y )
            newPos.y = min.y;

        if( newPos.x > max.x )
            newPos.x = max.x;

        if( newPos.y > max.y )
            newPos.y = max.y;

        transform.position = newPos;
    }
}
