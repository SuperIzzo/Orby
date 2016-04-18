using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    static Dialog instance;

    [SerializeField]
    GameObject graphics;

    [SerializeField]
    Text text;

    void Start()
    {
        instance = this;
    }

    public static void Show( string message )
    {
        instance.text.text = message;
        instance.graphics.SetActive( true );
    }

    public static void Hide()
    {
        instance.graphics.SetActive( false );
    }
}
