using UnityEngine;

public class Entity : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigidBody2D;
    AudioSource _audio;

    protected Animator animator
    {
        get { return _animator; }
    }


    public bool grounded
    {
        get
        {
            Vector2 groundPoint = new Vector2(
                transform.position.x,
                transform.position.y - groundY );

            return Physics2D.OverlapCircle( groundPoint, 0.1f, groundLayerMask );
        }
    }

    public AudioSource audio {  get { return _audio;  } }
    
    public Rigidbody2D rigidBody2D { get { return _rigidBody2D; } }


    public enum Direction
    {
        Left  = -1,
        Right = 1
    } 

    [SerializeField]
    public Direction direction = Direction.Right;

    protected float groundY;
    

    [SerializeField]
    LayerMask groundLayerMask;

    protected virtual void Start()
    {
        var box  = GetComponent<BoxCollider2D>();
        var circ = GetComponent<CircleCollider2D>();

        if( box )
        {
            groundY =  box.size.y/2 - box.offset.y;
        }

        if( circ )
        {
            groundY =  circ.radius - circ.offset.y;
        }

        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs( scale.x ) * (int) direction;
        transform.localScale = scale;
    }
}