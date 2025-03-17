using Unity.Cinemachine;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines.Interpolators;

public class RollPlayerMovement : MonoBehaviour
{
    public float baseSpeed;

    public InputActionAsset inputsAsset;
    private InputAction moveInput;
    private InputAction inputFire;
    private InputAction inputRoll;
    private InputAction inputZoom;

    public GameObject background;

    public CinemachineCamera followCam;
    public CinemachineCamera outCam;
    public CinemachineBrain brainCam;

    public Animator playerAnimator;
    public SpriteRenderer sprite;

    [HideInInspector] public float speed;

    private RollPlayerSkills skills;
    
    void Start()
    {
        moveInput = inputsAsset.FindAction("Move");
        inputFire = inputsAsset.FindAction("Attack");
        inputRoll = inputsAsset.FindAction("Roll");
        inputZoom = inputsAsset.FindAction("ZoomOut");

        speed = baseSpeed;

        skills=GetComponent<RollPlayerSkills>();
    }
       
    void Update()
    {
        //Move the main character
        Vector3 inputVector = new Vector3(moveInput.ReadValue<Vector2>().x, moveInput.ReadValue<Vector2>().y, 0);
        this.transform.Translate(inputVector*speed*Time.deltaTime);

        //Flip its sprite based on input direction
        if (moveInput.ReadValue<Vector2>().x < 0)
        {
            sprite.flipX = true;
        }
        if (moveInput.ReadValue<Vector2>().x > 0)
        {
            sprite.flipX = false;
        }

        //Set floats for animator's transitions
        playerAnimator.SetFloat("InputY", moveInput.ReadValue<Vector2>().y);
        playerAnimator.SetFloat("InputMagnitude",moveInput.ReadValue<Vector2>().magnitude);

        //Call to skills from input buttons
        if (inputFire.WasPressedThisFrame())
        {
            skills.actionFire();
        }
        if (inputRoll.WasPressedThisFrame())
        {
            skills.actionRoll();
        }        
        
        //Change cinemachine camera with an input
        if (inputZoom.IsPressed())
        {
            outCam.Priority = 2;
            if (brainCam.ActiveBlend != null)
            {
                background.transform.localScale = Vector3.Slerp(Vector3.one, new Vector3(5, 5, 5), brainCam.ActiveBlend.BlendWeight);
            }
        }
        else
        {
            outCam.Priority = 0;
            if (brainCam.ActiveBlend != null)
            {
                background.transform.localScale = Vector3.Slerp(new Vector3(5, 5, 5), Vector3.one, brainCam.ActiveBlend.BlendWeight);
            }
        }
    }
}
