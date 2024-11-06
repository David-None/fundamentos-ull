using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float offsetX;

    private Transform camTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camTransform=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Seguir al jugador con desfase en x
        camTransform.position=new Vector3(playerTransform.position.x+offsetX,camTransform.position.y,camTransform.position.z);
    }
}
