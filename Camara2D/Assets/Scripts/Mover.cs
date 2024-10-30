using System.Collections;
using System.IO;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moverSpeed;
    public float changeTime;


    private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomDirection();
        StartCoroutine(WaitForChange());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(direction*moverSpeed*Time.deltaTime);
    }

    private void RandomDirection()
    {
        direction= new Vector3(UnityEngine.Random.Range(-1.0f,1.0f),UnityEngine.Random.Range(-1.0f,1.0f),0).normalized;
        StartCoroutine(WaitForChange());
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="innerBorder")
        {
            direction=new Vector3(-direction.x,-direction.y,0);
        }
        
    }

    private IEnumerator WaitForChange()
    {
        yield return new WaitForSeconds(changeTime);
        RandomDirection();
    }
}
