using UnityEngine;
using UnityEngine.InputSystem;

public class LaserMovement : MonoBehaviour
{
    public InputActionAsset iAsset;
    private InputAction shootLaser;
    private InputAction stopLaser;
    private Transform thisTransform;
    private AudioSource audioPlayer;
    public float speed;
    private bool onTheMove;

    void Start()
    {
        onTheMove=false;
        thisTransform=GetComponent<Transform>();
        audioPlayer=GetComponentInChildren<AudioSource>();
        shootLaser=iAsset.FindAction("shootLaser");
        stopLaser=iAsset.FindAction("stopLaser");
    }
    void Update()
    {
        if (onTheMove)
        {
            thisTransform.transform.Rotate(Vector3.up, speed);
        }
        
        if (shootLaser.WasPressedThisFrame() && !onTheMove)
        {
            audioPlayer.Play();
            onTheMove=true;
        }

        if(stopLaser.WasPressedThisFrame() && onTheMove)
        {
            audioPlayer.Stop();
            onTheMove=false;
        }
    }
}
