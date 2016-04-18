using UnityEngine;
using System.Collections;

public class DirectionChanger : MonoBehaviour
{
    [SerializeField]
    Entity.Direction direction;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D( Collider2D coll )
    {
        if( coll.tag == "Player" )
            return;

        Entity entity = coll.GetComponent<Entity>();
        if( entity )
        {
            entity.direction = direction;
        }
    }
}
