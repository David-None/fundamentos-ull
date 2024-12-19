using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotSpeed;
    public float safeDist;

    public string enemyGroup;

    private bool specialOverride;

    private List<GameObject> trophies;
    private Transform enemyTransform;

    public GameObject currentTrophy;

    public GameObject player;
    public GameObject specialDestination;

    public Manager manager;
    public Vector3 destination;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager.managerEvent.AddListener(SetDestination);
        manager.specialTrophy.AddListener(SetSpecialDestination);
        enemyTransform=GetComponent<Transform>();
        specialOverride = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTransform.LookAt(destination);
        Quaternion goalQuat=enemyTransform.rotation;
        if ((destination-enemyTransform.position).magnitude > safeDist)
        {
            //enemyTransform.LookAt(destination);
            enemyTransform.Translate((destination-enemyTransform.position).normalized * moveSpeed * Time.deltaTime);
            Quaternion.Slerp(enemyTransform.rotation, goalQuat, rotSpeed * Time.deltaTime);
        }
    }

    void SetDestination()
    {
        if (!specialOverride)
        {
            float checkDist = 2000.0f;
            //GameObject currentTrophy = null;
            for (int i = 0; i < manager.trophyArray.LongLength; i++)
            {

                float distToTrophy = (manager.trophyArray[i].transform.position - this.transform.position).magnitude;

                if (distToTrophy < checkDist)
                {
                    checkDist = distToTrophy;
                    currentTrophy = manager.trophyArray[i].gameObject;
                }
            }
            destination = new Vector3(currentTrophy.transform.position.x, 0.0f, currentTrophy.transform.position.z);
        }
        
    }

    void SetSpecialDestination()
    {
        specialOverride = true;
        if (enemyGroup=="A")
        {
            destination = new Vector3(player.transform.position.x-enemyTransform.position.x,0.0f, player.transform.position.z - enemyTransform.position.z).normalized * (-100);
        }
        else
        {
            destination = new Vector3(specialDestination.transform.position.x,0.0f, specialDestination.transform.position.z);
        }
    }
}
