using UnityEngine;

public class WallScript : MonoBehaviour
{
    private AudioSource wallAudio;
    
    void Start()
    {
        wallAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Play sound when Quavers hit a wall
        if (collision.gameObject.CompareTag("playerQuaver")||collision.gameObject.CompareTag("enemyQuaver"))
        {
            wallAudio.Play();
        }
    }
}
