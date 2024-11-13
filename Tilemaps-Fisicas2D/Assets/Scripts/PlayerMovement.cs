using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public float baseSpeed;
    public float maxSpeed;
    public float jumpForce;
    private float speed;

    private bool isJumping;
    private int score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject ultraPanel;

    public InputActionAsset iAGrp;
    private InputAction move;
    private InputAction jump;
    private float inputX;

    private Transform thisTransform;
    private Rigidbody2D thisRb;
    private Animator thisAnimator;
    private SpriteRenderer thisSpriteRenderer;

    private AudioSource playerAudio;
    private AudioSource stepsAudio;

    public AudioClip jumpClip;
    public AudioClip landClip;
    public AudioClip collectClip;
    public AudioClip loseHealthClip;
    public AudioClip gainHealthClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        thisAnimator = GetComponent<Animator>();
        thisTransform =GetComponent<Transform>();
        thisRb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        stepsAudio = GetComponentInChildren<AudioSource>();
        move = iAGrp.FindAction("Move");
        jump = iAGrp.FindAction("Jump");
        speed = baseSpeed;
        health = maxHealth;
        healthText.text = "Salud: " + health.ToString();
        scoreText.text = "Dulces recolectados: " + score.ToString();
    }

    private void FixedUpdate()
    {
        //Tomar input del jugador
        inputX = move.ReadValue<Vector2>().x;

        //Mover al personaje en horizontal
        Vector2 direction = new Vector2(inputX, 0).normalized;
        

        if (thisRb.linearVelocityX < maxSpeed)
        {
            thisRb.AddForce(direction * speed);            
        }

        //Salto
        if (jump.IsPressed() && !isJumping)
        {
            thisRb.AddForce(transform.up * jumpForce);
            isJumping = true;
            playerAudio.PlayOneShot(jumpClip);
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
        if (collision.gameObject.CompareTag("ground") && isJumping)
        {
            playerAudio.PlayOneShot(landClip);
        }

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

        if (collision.gameObject.CompareTag("damager"))
        {
            health--;
            healthText.text = "Salud: " + health.ToString();
            playerAudio.PlayOneShot(loseHealthClip);
            if (health <= 0)
            {
                losePanel.SetActive(true);
            }
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
            playerAudio.PlayOneShot(collectClip);
            scoreText.text = "Dulces recolectados: "+score.ToString();
            if (health < maxHealth)
            {
                health++;
                healthText.text = "Salud: "+health.ToString();
                playerAudio.PlayOneShot(gainHealthClip);
            }
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
