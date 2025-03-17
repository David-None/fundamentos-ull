using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocity;
    public float apparentSpeed;
    public float jumpForce;

    private float previousPosX;
    private float postPosX;
    private bool isGrounded;

    private Rigidbody2D thisRB;
    private Animator thisAnim;
    private SpriteRenderer thisSprite;

    public InputActionAsset iAsset;
    public InputAction move;
    private InputAction jump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisRB=GetComponent<Rigidbody2D>();
        thisAnim=GetComponent<Animator>();
        thisSprite=GetComponent<SpriteRenderer>();
        move=iAsset.FindAction("move");
        jump=iAsset.FindAction("jump");
        isGrounded=true;
    }

    
    void FixedUpdate()
    {
        //Mover al personaje en horizontal
        previousPosX=transform.position.x;
        float moveDistX=(move.ReadValue<Vector2>().x*velocity*Time.fixedDeltaTime);
        thisRB.linearVelocityX=moveDistX;
        
        if (moveDistX<0.0f)
        {
            thisSprite.flipX=true;
        }
        else
        {
            thisSprite.flipX=false;
        }

        //Hacer saltar al personaje
        if(jump.IsPressed() && isGrounded)
        {
            thisRB.AddForceY(jumpForce);
        }

        //Activar la animacion al caminar
        if(moveDistX!=0.0f)
        {
            thisAnim.SetBool("isWalking",true);
        }
        else
        {
            thisAnim.SetBool("isWalking", false);
        }
    }

    void Update()
    {
        postPosX=transform.position.x;
        apparentSpeed=(postPosX-previousPosX);
    }

    //Detectar colision con el suelo para habilitar salto
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            isGrounded=true;
            thisAnim.SetBool("isGrounded", true);
        }
    }
    //Detectar salida del suelo para deshabilitar salto
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            isGrounded=false;
            thisAnim.SetBool("isGrounded", false);
        }
    }
}
