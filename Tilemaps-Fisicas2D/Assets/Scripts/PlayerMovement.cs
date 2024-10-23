using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed;
    public float maxSpeed;
    public float jumpForce;
    private float speed;

    private bool isJumping;
    private int score = 0;

    //public float timeUntilTired;
    //private float timeToRecover = 8.0f;
    //private float tiredCountdown;
    //private bool tiredCountdownActive;

    public TextMeshProUGUI UIText;
    public GameObject winPanel;
    public GameObject ultraPanel;

    public InputActionAsset iAGrp;
    private InputAction move;
    private InputAction jump;
    private float inputX;

    private Transform thisTransform;
    private Rigidbody2D thisRb;
    private Animator thisAnimator;
    private SpriteRenderer thisSpriteRenderer;

    
    //private float inputY;
    //private IEnumerator tiredCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        thisAnimator = GetComponent<Animator>();
        thisTransform =GetComponent<Transform>();
        thisRb = GetComponent<Rigidbody2D>();
        move = iAGrp.FindAction("Move");
        jump = iAGrp.FindAction("Jump");
        //tiredCoroutine = GetTired();
        speed = baseSpeed;
        //tiredCountdown = timeUntilTired;
    }

    // Update is called once per frame
    void Update()
    {
        //Tomar input del jugador
        //inputX = move.ReadValue<Vector2>().x;
        //inputY = move.ReadValue<Vector2>().y;

        //Mover al personaje
        //Vector3 direction = new Vector3 (inputX, inputY, 0).normalized;
        //transform.Translate(direction*speed*Time.deltaTime, Space.World);

        //Setear parametros de la animacion
        /*if (inputX > 0)
        {
            thisSpriteRenderer.flipX = true;
        }
        else if (inputX < 0) 
        {
            thisSpriteRenderer.flipX = false;
        }
        if (inputX == 0 && inputY == 0)
        {
            thisAnimator.SetBool("idle", true);
        }
        else
        {
            thisAnimator.SetBool("idle", false);
        }
        thisAnimator.SetFloat("inputX", inputX);
        thisAnimator.SetFloat("inputY", inputY);*/

        //Cambiar animacion despues de caminar cierta distancia
        /*if (move.WasPressedThisFrame())
        {            
            tiredCountdownActive = true;
        }
        if (move.WasReleasedThisFrame())
        {
            tiredCountdownActive= false;
            tiredCountdown = timeUntilTired;
            thisAnimator.SetBool("tired", false);
            speed = baseSpeed;
        }
        if (tiredCountdownActive)
        {
            tiredCountdown=tiredCountdown-Time.deltaTime;
        }
        if (tiredCountdown <= 0.0f)
        {
            thisAnimator.SetBool("tired", true);
            speed = 0;
        }*/
    }

    private void FixedUpdate()
    {
        //Tomar input del jugador
        inputX = move.ReadValue<Vector2>().x;

        //Mover al personaje en horizontal
        Vector2 direction = new Vector2(inputX, 0).normalized;
        //thisRb.MovePosition(thisRb.position+(direction * speed * Time.fixedTime));
        
        if (thisRb.linearVelocityX < maxSpeed)
        {
            thisRb.AddForce(direction * speed);
        }        

        //Salto
        if (jump.IsPressed() && !isJumping)
        {
            thisRb.AddForce(transform.up * jumpForce);
            isJumping = true;
        }

        //Setear parametros de la animacion
        if (inputX > 0)
        {
            thisSpriteRenderer.flipX = true;
        }
        else if (inputX < 0)
        {
            thisSpriteRenderer.flipX = false;
        }
        if (inputX == 0)
        {
            thisAnimator.SetBool("idle", true);
        }
        else
        {
            thisAnimator.SetBool("idle", false);
        }
        thisAnimator.SetFloat("inputX", inputX);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isJumping=false;
            thisRb.linearVelocity = new Vector2(thisRb.linearVelocityX, 0);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("MovingPlatforms"))
        {
            gameObject.transform.SetParent(collision.gameObject.transform, true);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("InvisiblePlatforms"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("MovingPlatforms"))
        {
            gameObject.transform.parent = null;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("InvisiblePlatforms"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "collectable")
        {
            Destroy(collision.gameObject);
            score++;
            UIText.text = "Dulces recolectados: "+score.ToString();
            if (score >= 5)
            {
                jumpForce = jumpForce * 1.5f;
                ultraPanel.SetActive(true);
            }
            if (score >= 10)
            {
                winPanel.SetActive(true);
            }
        }
    }
}
