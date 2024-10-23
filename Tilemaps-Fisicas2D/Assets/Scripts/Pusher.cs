using UnityEngine;

public class Pusher : MonoBehaviour
{
    public Vector2 pushForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            Debug.Log("Push it to the limit!");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushForce);
        }
    }
}
