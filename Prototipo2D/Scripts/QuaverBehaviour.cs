using UnityEngine;

public class QuaverBehaviour : MonoBehaviour
{
    public float quaverSpeed;
    public float quaverRotation;
    public float yLimit;
    public float xLimit;

    [HideInInspector] public float quaverDamage;
    [HideInInspector] public Vector3 direction;

    private SpriteRenderer quaverSprite;
    private AudioSource quaverAudio;

    void Start()
    {
        quaverSprite = GetComponentInChildren<SpriteRenderer>();
        quaverSprite.transform.Rotate(0, 0, Random.Range(0, 360));
        quaverAudio = GetComponent<AudioSource>();
    }
        
    void Update()
    {
        //Move the Quaver in the direction set when instantiated
        this.transform.Translate(direction.normalized*quaverSpeed*Time.deltaTime);
        //Rotate for "flavor"
        quaverSprite.transform.Rotate(0,0,quaverRotation*Time.deltaTime);
        //Destroy the Quaver when off limits (a precaution in the case some quaver flies over a wall)
        if (this.transform.position.y > yLimit || this.transform.position.y < -yLimit || this.transform.position.x > xLimit || this.transform.position.x < -xLimit)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy the Quaver when it hits a wall
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }        
    }
}
