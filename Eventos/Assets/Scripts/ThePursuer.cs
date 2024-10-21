using UnityEngine;

public class ThePursuer : MonoBehaviour
{
    public CharControl mainChar;

    public float pursuerSpeed;
    public float accuracy;

    private Transform currentGoal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainChar.specialEvent.AddListener(PursuePlayer);
        currentGoal = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 goalDirection = currentGoal.position - this.transform.position;
        float distanceToGoal = goalDirection.magnitude;
        if (distanceToGoal > accuracy)
        {
            this.transform.Translate(goalDirection.normalized * pursuerSpeed * Time.deltaTime, Space.World);
        }
    }

    void PursuePlayer()
    {
        currentGoal=mainChar.transform;
    }
}
