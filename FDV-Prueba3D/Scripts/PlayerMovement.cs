using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset actionAsset;
    //private InputAction rotAction;
    private InputAction moveAction;

    public float moveSpeed;
    public float rotSpeed;

    private Animator playerAnimator;
    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        //actionAsset = GetComponent<InputActionAsset>();
        moveAction = actionAsset.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAction.IsInProgress())
        {
            playerTransform.Translate(Vector3.forward*moveSpeed*moveAction.ReadValue<Vector2>().y*Time.deltaTime);
            playerTransform.Rotate(Vector3.up, rotSpeed*moveAction.ReadValue<Vector2>().x*Time.deltaTime);
        }
        if (moveAction.ReadValue<Vector2>().y!=0)
        {
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
    }
}
