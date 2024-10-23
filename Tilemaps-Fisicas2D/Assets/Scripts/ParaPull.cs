using UnityEngine;

public class ParaPull : MonoBehaviour
{
    public Rigidbody2D pulledObj;
    public Vector2 pullDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pullPosition = new Vector2 (this.transform.position.x, this.transform.position.y)+pullDistance;
        pulledObj.MovePosition(pullPosition);
    }
}
