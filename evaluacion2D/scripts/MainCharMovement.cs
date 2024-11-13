using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class MainCharMovement : MonoBehaviour
{
    public float velocity;
    public float apparentSpeed;
    public float jumpForce;

    private float previousPosX;
    private float postPosX;
    private bool isGrounded;

    public GameObject lastEnemy;

    private int score;
    public int maxHealth;
    private int health;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public GameObject winPanel;

    private Rigidbody2D thisRB;
    private Animator thisAnim;
    private SpriteRenderer thisSprite;
    private AudioSource thisAudio;

    public InputActionAsset iAsset;
    private InputAction move;
    private InputAction jump;
    private InputAction attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisRB = GetComponent<Rigidbody2D>();
        thisAnim = GetComponent<Animator>();
        thisSprite = GetComponent<SpriteRenderer>();
        thisAudio = GetComponent<AudioSource>();
        move = iAsset.FindAction("move");
        jump = iAsset.FindAction("jump");
        attack = iAsset.FindAction("attack");
        lastEnemy = null;
        isGrounded = true;
        score = 0;
        health = maxHealth;
    }

    void FixedUpdate()
    {
        //Mover al personaje en horizontal
        previousPosX = transform.position.x;
        float moveDistX = (move.ReadValue<Vector2>().x * velocity * Time.fixedDeltaTime);
        thisRB.linearVelocityX = moveDistX;

        if (moveDistX < 0.0f)
        {
            thisSprite.flipX = false;
        }
        else
        {
            thisSprite.flipX = true;
        }

        //Hacer saltar al personaje
        if (jump.IsPressed() && isGrounded)
        {
            thisRB.AddForceY(jumpForce);
        }

        //Activar la animacion al caminar
        if (moveDistX != 0.0f)
        {
            thisAnim.SetBool("isWalking", true);
        }
        else
        {
            thisAnim.SetBool("isWalking", false);
        }
    }

    void Update()
    {
        postPosX = transform.position.x;
        apparentSpeed = (postPosX - previousPosX);

        //Reproducir sonido al atacar y destruir enemigo si lo hubiera
        if (attack.WasPressedThisFrame() && lastEnemy != null)
        {
            thisAudio.Play();
            Destroy(lastEnemy);
        }
    }

    //Detectar colision con el suelo para habilitar salto
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            thisAnim.SetBool("isGrounded", true);
        }
        //Detectar enemigo
        if (other.gameObject.CompareTag("Monster"))
        {
            lastEnemy = other.gameObject;
        }
        //Recibir damage de objetos damager
        if (other.gameObject.CompareTag("Damager"))
        {
            health--;
            healthText.text = "Salud: " + health.ToString();
        }
    }

    //Detectar salida del suelo para deshabilitar salto
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
            thisAnim.SetBool("isGrounded", false);
        }
        //Vaciar enemigo
        if (other.gameObject.CompareTag("Monster"))
        {
            lastEnemy = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dar puntos al colisionar con antorcha
        if (collision.gameObject.CompareTag("Torch"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Antorchas encontradas: " + score.ToString();
            //if (health < maxHealth)
            //{
            //    health++;
            //    healthText.text = "Salud: " + health.ToString();
            //}
        }

        //Finalizar partida al encontrar el tesoro
        if (collision.gameObject.CompareTag("Treasure"))
        {
            winPanel.SetActive(true);
        }
    }
     
}
