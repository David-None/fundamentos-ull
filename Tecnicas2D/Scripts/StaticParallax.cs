using UnityEngine;
using UnityEngine.InputSystem;

public class StaticParallax : MonoBehaviour
{
    //public PlayerMovement playerScript;
    public InputActionAsset iAsset;
    public float speed;
    private InputAction move;
    private Transform thisTransform;

    private float sizeX;

    private Collider2D thisCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisTransform=GetComponent<Transform>();
        thisCollider=GetComponent<Collider2D>();
        move=iAsset.FindAction("move");
        sizeX=thisCollider.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //thisTransform.position=new Vector3(-playerScript.speed*playerScript.move.ReadValue<Vector2>().x*Time.deltaTime,0,0);
        thisTransform.Translate(-speed*move.ReadValue<Vector2>().x*Time.deltaTime,0,0,Space.World);
        if(thisTransform.position.x < sizeX)
        {
                thisTransform.Translate(sizeX*2,0,0,Space.World);
        }
        if(thisTransform.position.x > sizeX)
        {
                thisTransform.Translate(-sizeX*2,0,0,Space.World);
        }
    }
}
