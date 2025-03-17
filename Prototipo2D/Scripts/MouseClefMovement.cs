using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClefMovement : MonoBehaviour
{
    public float mouseSensitivity;

    public InputActionAsset inputsAsset;    
    private InputAction lookInput;

    private Vector3 lastPosition;

    private Transform parentTransform;
    
    void Start()
    {
        lookInput = inputsAsset.FindAction("Look");

        lastPosition = this.transform.localPosition;
        parentTransform =GetComponentInParent<Transform>();
        this.transform.position=parentTransform.position;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Move clef cursor
        Vector3 mousePos = new Vector3(lookInput.ReadValue<Vector2>().x, lookInput.ReadValue<Vector2>().y, 0);
        this.transform.Translate(mousePos * mouseSensitivity, Space.Self);
        lastPosition = this.transform.localPosition;
    }
}
