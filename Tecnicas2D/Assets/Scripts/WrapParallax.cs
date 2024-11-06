using UnityEngine;
using UnityEngine.InputSystem;

public class WrapParallax : MonoBehaviour
{
    private Renderer thisMat;
    public float speed;
    public float parallaxSpeedScale;
    public InputActionAsset iAsset;
    private InputAction move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisMat=GetComponent<Renderer>();
        move=iAsset.FindAction("move");
    }

    // Update is called once per frame
    void Update()
    {
        thisMat.material.SetTextureOffset("_BaseMap",new Vector2(thisMat.material.GetTextureOffset("_BaseMap").x+(move.ReadValue<Vector2>().x*speed*parallaxSpeedScale*Time.deltaTime),0));
    }
}
