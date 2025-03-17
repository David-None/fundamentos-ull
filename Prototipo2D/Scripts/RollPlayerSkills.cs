using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RollPlayerSkills : MonoBehaviour
{
    public float rollSpeedMultiplier;
    public float playerMaxHealth;
    public float playerAttack;

    [HideInInspector] public float playerHealth;
    private float healthSegment;
    private int healthbarIndex;

    [HideInInspector] public bool perfectAccuracy;
    [HideInInspector] public bool goodAccuracy;
    private bool rolling;

    public Transform clefTransform;
    public GameObject quaver;
    public Image healthBar;

    public Sprite[] healthStates;    

    private RollPlayerMovement movement;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;
    
    void Start()
    {
        playerHealth = playerMaxHealth;
        healthSegment = playerMaxHealth/healthStates.Length;
        healthbarIndex = 8;

        healthBar.sprite = healthStates[healthbarIndex];

        movement = GetComponent<RollPlayerMovement>();
        playerAnimator = movement.playerAnimator;
        playerAudioSource = GetComponent<AudioSource>();                
    }

    //Fire a new Quaver
    public void actionFire()
    {
        GameObject newQuaver;
        QuaverBehaviour newQuaverBehaviour;
        //Set the attack animation
        playerAnimator.SetTrigger("Attack");
        //Get the direction in which the player is aiming the Clef
        Vector3 quaverDirection= (clefTransform.position-this.transform.position);
        
        //Instantantiate a new Quaver and set its direction from the aim vector
        newQuaver=Instantiate(quaver, this.transform.position, Quaternion.identity);
        newQuaverBehaviour=newQuaver.GetComponent<QuaverBehaviour>();
        newQuaverBehaviour.direction= quaverDirection;

        //Modify Quaver's damage based on rhythm accuracy
        if(perfectAccuracy)
        {
            newQuaverBehaviour.quaverDamage = playerAttack*5;
        }
        else if(goodAccuracy) 
        {
            newQuaverBehaviour.quaverDamage = playerAttack*2;
        }
        else
        {
            newQuaverBehaviour.quaverDamage = playerAttack;
        }        
    }

    //Roll (move faster)
    public void actionRoll()
    {
        if (!rolling)
        {
            rolling = true;
            //Trigger the rolling animation
            playerAnimator.SetTrigger("Roll");
            movement.speed *= rollSpeedMultiplier;
        }
    }

    //This action is called at the end of the rolling animation to set speed back to normal
    public void actionEndRoll()
    {
        movement.speed = movement.baseSpeed;
        rolling = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Get damaged when hit by an enemy projectile
        if (collision.gameObject.CompareTag("enemyQuaver"))
        {
            QuaverBehaviour enemyQuaver;
            playerAudioSource.Play();
            
            enemyQuaver=collision.gameObject.GetComponent<QuaverBehaviour>();
            playerHealth -= enemyQuaver.quaverDamage; 
            healthSegment -= enemyQuaver.quaverDamage;
            checkHealth(); //Check health to end game or change UI sprite
            Destroy(enemyQuaver.gameObject);
        }
    }

    //Check health to stablish the correct UI indicator, and end the game when it reaches 0
    void checkHealth()
    {
        if (playerHealth <= 0)
        {
            //Game end
            Debug.Log("Rock is Dead");
            SceneManager.LoadScene("GameOver");
        }
        else 
        {
            if (healthSegment <= 0)
            {
                //Change health UI sprite when a segment of health is lost
                float overDamage;
                overDamage = healthSegment;
                healthbarIndex--;
                healthBar.sprite = healthStates[healthbarIndex];
                healthSegment = (playerMaxHealth / healthStates.Length) - overDamage;
            }
        }

    }
}
