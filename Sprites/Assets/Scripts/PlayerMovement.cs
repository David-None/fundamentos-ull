using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed;
    private float speed;
    public float timeUntilTired;
    private float timeToRecover = 8.0f;
    private float tiredCountdown;
    private bool tiredCountdownActive;
    public InputActionAsset iA_grp;
    private InputAction move;
    //private InputAction moveRight;
    private Transform thisTransform;
    private Animator thisAnimator;
    private SpriteRenderer thisSpriteRenderer;
    private float inputX;
    private float inputY;
    private IEnumerator tiredCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        thisAnimator = GetComponent<Animator>();
        thisTransform =GetComponent<Transform>();
        move = iA_grp.FindAction("Move");
        //tiredCoroutine = GetTired();
        speed = baseSpeed;
        tiredCountdown = timeUntilTired;
    }

    // Update is called once per frame
    void Update()
    {
        //Tomar input del jugador
        inputX = move.ReadValue<Vector2>().x;
        inputY = move.ReadValue<Vector2>().y;

        //Mover al personaje
        Vector3 direction = new Vector3 (inputX, inputY, 0).normalized;
        transform.Translate(direction*speed*Time.deltaTime, Space.World);

        //Setear parametros de la animacion
        if (inputX > 0)
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
        thisAnimator.SetFloat("inputY", inputY);

        //Cambiar animacion despues de caminar cierta distancia
        if (move.WasPressedThisFrame())
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
        }
    }
}
