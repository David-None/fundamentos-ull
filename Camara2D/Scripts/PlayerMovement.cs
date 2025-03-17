using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public CinemachineBrain cineBrain;
    public InputActionAsset playerInput;
    private InputAction playerMove;
    private Transform playerTr;
    private Animator playerAn;
    private SpriteRenderer playerSpr;

    public CinemachineCamera blackCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTr=GetComponent<Transform>();
        playerAn=GetComponent<Animator>();
        playerSpr=GetComponent<SpriteRenderer>();
        playerMove=playerInput.FindAction("move");
    }

    // Update is called once per frame
    void Update()
    {
        //Mover personaje
        Vector3 direction= new Vector3(playerMove.ReadValue<Vector2>().x, playerMove.ReadValue<Vector2>().y,0).normalized;
        playerTr.Translate(direction*speed*Time.deltaTime);

        //Activar animaciones del personaje
        if (direction.magnitude>0.0f)
        {
            playerAn.SetBool("isWalking", true);
        }
        else
        {
            playerAn.SetBool("isWalking",false);
        }

        //Voltear personaje segun direccion
        if (direction.x > 0)
        {
            playerSpr.flipX = false;
        }
        if (direction.x < 0)
        {
            playerSpr.flipX = true;
        }
    }

    //Camara lenta y rapida
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "slomo")
        {
            Time.timeScale=0.5f;
        }
        if(other.tag=="fastforward")
        {
            Time.timeScale=2.0f;
        }
        if(other.tag == "blackHole")
        {
            blackCam.gameObject.SetActive(true);
        }
    }
}