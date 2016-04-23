using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Vector3 offset;

    public float zoom = 5;
    public float zoomDampTime = 0.15f;
    private float zoomVelocity;

    Camera camera;


    void Start()
    {
        camera = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        if( target && target.gameObject.activeInHierarchy )
        {
            Vector3 targetPos = target.position + offset;
            Vector3 point = camera.WorldToViewportPoint(targetPos);
            Vector3 delta = targetPos - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); 
            Vector3 destination = transform.position + delta;
            transform.position =
                Vector3.SmoothDamp( transform.position, destination, ref velocity, dampTime );

            camera.orthographicSize = 
                Mathf.SmoothDamp( camera.orthographicSize, zoom, ref zoomVelocity, zoomDampTime );
        }
    }
}