using System.Linq;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    public float points;
    public Manager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //manager.trophyArray.Append<GameObject>(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            manager.totalPoints += points;
            manager.trophyCollected();            
            Destroy(gameObject);
        }
    }
}
