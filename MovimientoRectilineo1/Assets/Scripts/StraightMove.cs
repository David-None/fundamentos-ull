using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class StraightMove : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;
    public float speedIncreaseAmount = 0.5f;
    public float accuracy = 0.1f;
    public float rotSpeed = 1.0f;
    public InputActionAsset inputAsset;
    private InputAction increaseSpeed;
    private GameObject[] waypoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        increaseSpeed = inputAsset.FindAction("jump");
        SetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        //Incremento de velocidad al pulsar espacio
        if (increaseSpeed.WasPressedThisFrame())
        {
            speed = speed + speedIncreaseAmount;
            Debug.Log("La velocidad actual es:"+ speed.ToString());
        }

        //Encontrar direccion de giro (suavizada)
        Vector3 goalGround =new Vector3(goal.position.x,0, goal.position.z);
        Quaternion origQuat = this.transform.rotation;
        this.transform.LookAt(goalGround);
        Quaternion goalQuat = this.transform.rotation;        
        Quaternion newRot= Quaternion.Slerp(origQuat, goalQuat, rotSpeed);
        this.transform.rotation = newRot;   //Giro

        //Direccion entre el perseguidor y su objetivo
        Vector3 direction = goalGround - this.transform.position;

        //Mover al perseguidor / Cambiar de waypoint al acercarse
        if (direction.magnitude > accuracy)
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            SetNextWaypoint();
        }
    }

    void SetNextWaypoint()
    {
        
        //Si la lista de waypoints esta vacia, se reinicia
        if (waypoints == null || waypoints.Length == 0)
        {
            waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        }
        GameObject currentWP = waypoints[0];

        //Encontrar el miembro de la lista mas cercano
        foreach (GameObject wp in waypoints)
        {            
            float currentDist= (currentWP.transform.position - this.transform.position).magnitude;
            float testingDist = (wp.transform.position - this.transform.position).magnitude;
            if (testingDist < currentDist)
            {
                currentWP = wp;
            }
        }

        //Asignamos el waypoint como nuevo goal
        goal = currentWP.transform;

        //Eliminar el waypoint de la lista para la siguiente comprobacion no volver a pasar por el mismo
        int indexToDelete = Array.FindIndex(waypoints, x => x == currentWP);
        waypoints = waypoints.Where((val,idx) => idx != indexToDelete).ToArray();

        Debug.Log("El siguiente waypoint es: " + currentWP.name);
    }
}
