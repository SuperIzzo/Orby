using UnityEngine;
using System.Collections;

public class SignMessage : MonoBehaviour
{
    [Multiline]
    public string message;

	void OnTriggerEnter2D( Collider2D coll )
    {
        if( coll.tag == "Player")
        {
            Dialog.Show( message );
        }
    }

    void OnTriggerExit2D( Collider2D coll )
    {
        if( coll.tag == "Player" )
        {
            Dialog.Hide();
        }
    }
}
