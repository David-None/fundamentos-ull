using UnityEngine;

public class BackParallax : MonoBehaviour
{
    public PlayerMovement playerScript;
    private Rigidbody2D playerRB;
    public Transform camTransform;
    public float parallaxPercent;

    private float disToCam;

    private Transform thisBackground;
    private Collider2D thisCollider;
    private float sizeX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisBackground=GetComponent<Transform>();
        thisCollider=GetComponent<Collider2D>();
        playerRB=playerScript.gameObject.GetComponent<Rigidbody2D>();
        sizeX=thisCollider.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {        
        disToCam=camTransform.position.x-thisBackground.position.x;
        float playerSpeed=System.Math.Abs(playerRB.linearVelocityX);
        //Mover el background un porcentaje de la velocidad del jugador
        thisBackground.Translate(new Vector3(playerScript.move.ReadValue<Vector2>().x*playerSpeed*Time.deltaTime*parallaxPercent,0,0));
        
        //Teleportar el background cuando se sale de camara
        if (disToCam>sizeX)
        {
            thisBackground.Translate(sizeX*2,0,0);
        }
        if (disToCam<-sizeX)
        {
            thisBackground.Translate(-sizeX*2,0,0);
        }
    }
}

