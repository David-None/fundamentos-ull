using UnityEngine;

public class BasicMobBehaviour : MonoBehaviour
{
    public float mobMaxHealth;    
    public float mobSpeed;
    public float mobAttack;
    public float mobFireRate;
    public float sightRange;
    public float nextPointDist;

    private float mobHealth;
    private float mobHealthSegment;
    private int mobHealthIndex;

    private float fireTimer;

    private Vector3 toPlayer;
    private float distToPlayer;

    private Vector3 toPatrol;
    private float distToPatrol;

    private int currentPointIndex;

    private bool onSight;

    public GameObject player;
    public GameObject quaver;
    public SpriteRenderer mobHealthbar;    
    public Score score;    

    public GameObject[] patrolPoints;
    public Sprite[] mobHealthStates;    

    private Animator mobAnimator;
    private AudioSource mobAudio;

    void Start()
    {
        mobHealth = mobMaxHealth;
        mobHealthSegment = mobMaxHealth / mobHealthStates.Length;
        mobHealthIndex = 3;

        fireTimer = mobFireRate;

        currentPointIndex = 0;  

        mobAnimator = GetComponentInChildren<Animator>();
        mobAudio = GetComponent<AudioSource>();

        mobHealthbar.sprite = mobHealthStates[mobHealthIndex];
        mobHealthbar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime; // firing cooldown

        //Get the vector from mob to player and its distance
        toPlayer = player.transform.position - this.transform.position;
        distToPlayer = toPlayer.magnitude;

        //Check if player is on sight or not
        if (distToPlayer < sightRange)
        {
            onSight = true;
        }
        else
        {
            onSight = false;
        }

        if (!onSight)
        {
            //When the player is not on sight radius, patrol between the set points

            //Set Animator's transitions
            mobAnimator.SetBool("IsMoving", true);
            mobAnimator.SetBool("IsAttacking", false);

            //Trace the vector from mob to patrol point and get its magnitude
            toPatrol = (patrolPoints[currentPointIndex].transform.position - this.transform.position);
            distToPatrol= toPatrol.magnitude;

            //Move the mob toward the patrol point
            this.transform.Translate(toPatrol.normalized*mobSpeed*Time.deltaTime);

            if(distToPatrol < nextPointDist)
            {
                //Change to next patrol point when near enough
                currentPointIndex++;
                if (currentPointIndex >  patrolPoints.Length-1)
                {
                    currentPointIndex= 0;
                }
            }
        }
        else
        {
            if(fireTimer < 0)
            {
                //When the player is on sight and cooldown has passed, fire a Quaver
                GameObject newQuaver;
                QuaverBehaviour newQuaverBehaviour;

                //Set Animator's transitions
                mobAnimator.SetBool("IsMoving", false);
                mobAnimator.SetBool("IsAttacking", true);
                
                //Instantiate new Quaver aimed at player
                newQuaver = Instantiate(quaver, this.transform.position, Quaternion.identity);
                newQuaverBehaviour = newQuaver.GetComponent<QuaverBehaviour>();
                newQuaverBehaviour.direction = toPlayer;
                newQuaverBehaviour.quaverDamage = mobAttack;
                fireTimer = mobFireRate;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerQuaver"))
        {
            //Receive damage and set score when mob is hit by the player
            QuaverBehaviour attackingQuaver;  
            attackingQuaver=collision.gameObject.GetComponent<QuaverBehaviour>();

            //Add score
            score.RewriteScore(((int)attackingQuaver.quaverDamage));

            //Take damage
            mobHealth -= attackingQuaver.quaverDamage;
            mobHealthSegment -= attackingQuaver.quaverDamage;

            CheckHealth();  //Changes healthbar appearance and destroys the mob if health is 0

            Destroy(attackingQuaver.gameObject);

            mobAudio.Play();
        }
    }

    void CheckHealth()
    {
        //Changes healthbar appearance and destroys the mob if health is 0
        if (mobHealth <= 0)
        {
            //Destroy mob when health reaches 0
            Destroy(this.gameObject);
        }
        else
        {
            if (mobHealth < mobMaxHealth)
            {
                //Healthbar is only shower after the mod takes first damage
                mobHealthbar.enabled = true;
            }
            if (mobHealthSegment <= 0)
            {
                //Change appearance of the healthbar to reflect inflicted damage
                float overDamage;
                overDamage = mobHealthSegment;
                mobHealthIndex--;
                mobHealthbar.sprite = mobHealthStates[mobHealthIndex];
                mobHealthSegment = (mobMaxHealth / mobHealthStates.Length) - overDamage;
            }
        }
    }
}
