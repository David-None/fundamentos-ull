using UnityEngine;
using UnityEngine.InputSystem;

public class Parallax : MonoBehaviour
{
    private Renderer thisMat;
    public float speed;
    public float parallaxSpeedScale;

    private Transform thisTransform;

    public InputActionAsset iAsset;
    private InputAction move;

    private Vector3 newPos;

    public Transform mainCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisMat = GetComponent<Renderer>();
        thisTransform=GetComponent<Transform>();
        move = iAsset.FindAction("move");
    }

    // Update is called once per frame
    void Update()
    {
        newPos=new Vector3(mainCam.position.x, mainCam.position.y,thisTransform.position.z);
        this.transform.position = newPos;
        thisMat.material.SetTextureOffset("_BaseMap", new Vector2(thisMat.material.GetTextureOffset("_BaseMap").x + (move.ReadValue<Vector2>().x * speed * parallaxSpeedScale * Time.deltaTime), 0));
    }
}
