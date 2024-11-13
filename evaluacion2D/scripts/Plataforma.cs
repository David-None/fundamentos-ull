using UnityEngine;
using UnityEngine.Events;

public class Plataforma : MonoBehaviour
{
    public UnityEvent jumpPlatform;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            jumpPlatform.Invoke();
        }
    }
}
