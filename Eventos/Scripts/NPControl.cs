using UnityEngine;

public class NPControl : MonoBehaviour
{
    public float NPCSpeed;
    public float accuracy;
    public float rotSlerp;

    public Transform goal;
    private Transform currentGoal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGoal = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 goalDirection = currentGoal.position - this.transform.position;

        Quaternion currentQuat= this.transform.rotation;
        this.transform.LookAt(currentGoal.position);
        Quaternion toGoalQuat= this.transform.rotation;
        this.transform.rotation=Quaternion.Slerp(currentQuat, toGoalQuat, rotSlerp);

        float distanceToGoal=goalDirection.magnitude;
        if(distanceToGoal > accuracy)
        {
            this.transform.Translate(Vector3.forward*NPCSpeed*Time.deltaTime, Space.Self);
        }
    }

    public void SetGoal()
    {
        currentGoal = goal;
    }
}
