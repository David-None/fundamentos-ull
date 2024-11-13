using UnityEngine;

using System.Collections;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset iAsset;
    private InputAction move;
    private Transform thisTransform;
    private Vector3 direction;
    private Rigidbody thisRB;
    private AudioSource playerAudio;
    public AudioSource stepsAudio;
    public float speed;

    void Start()
    {
        move = iAsset.FindAction("move");
        thisTransform = GetComponent<Transform>();
        thisRB = GetComponent<Rigidbody>();
        playerAudio=GetComponent<AudioSource>();
    }
    void LateUpdate()
    {
        if(move.WasPressedThisFrame())
        {
            stepsAudio.Play();
        }       
        if (move.IsInProgress())
        {
            direction = new Vector3(move.ReadValue<Vector2>().x, 0.0f, move.ReadValue<Vector2>().y).normalized;
            thisRB.linearVelocity=direction*speed;
        }
        else if (move.WasReleasedThisFrame())
        {
            thisRB.linearVelocity=Vector3.zero;
            stepsAudio.Stop();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("soundSphere"))
        {
            
            float hitVolume = Mathf.InverseLerp(0.0f, speed, other.impulse.magnitude);
            playerAudio.PlayOneShot(playerAudio.clip,hitVolume);
        }
    }
}
