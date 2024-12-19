using System.Linq;
using System;
using UnityEngine;

public class BlueMovement : MonoBehaviour
{
    public GameObject[] waypoints;

    public Transform goal;

    public float moveSpeed;
    public float rotSpeed;
    public float safeDist;

    private Transform enemyTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyTransform = GetComponent<Transform>();
        SetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 goalGround = new Vector3(goal.position.x, 0, goal.position.z);
        Quaternion origQuat = this.transform.rotation;
        this.transform.LookAt(goalGround);
        Quaternion goalQuat = this.transform.rotation;
        Quaternion newRot = Quaternion.Slerp(origQuat, goalQuat, rotSpeed);
        this.transform.rotation = newRot;

        Vector3 direction = goalGround - this.transform.position;

        if (direction.magnitude > safeDist)
        {
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
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
            float currentDist = (currentWP.transform.position - this.transform.position).magnitude;
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
        waypoints = waypoints.Where((val, idx) => idx != indexToDelete).ToArray();

        //Debug.Log("El siguiente waypoint es: " + currentWP.name);
    }
}
