using UnityEngine;
using UnityEngine.InputSystem;

public class Doppler : MonoBehaviour
{
    public InputActionAsset iAsset;
    public InputAction shootFire;

    private Transform thisTransform;
    private AudioSource audioPlayer;

    private Vector3 startPosition;

    public float speed;

    private bool toReset;
    private bool isFired;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFired = false;
        toReset = false;
        shootFire = iAsset.FindAction("shootFire");
        thisTransform=GetComponent<Transform>();
        audioPlayer=GetComponent<AudioSource>();
        startPosition=thisTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootFire.WasPressedThisFrame())
        {
            if(toReset)
            {
                //Resetear para pruebas rapidas sin reiniciar el modo de juego
                isFired=false;
                thisTransform.position=startPosition;
                audioPlayer.Stop();
                toReset=false;
            }
            else
            {
                isFired = true;
                audioPlayer.Play();
            }            
        }
        if (isFired)
        {
            thisTransform.Translate(Vector3.left*speed*Time.deltaTime);
            toReset=true;
        }
    }
}
