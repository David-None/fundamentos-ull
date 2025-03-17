using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RhythmRingBehaviour : MonoBehaviour
{
    public float ringSpeed;

    private Vector3 ringPosition;

    public GameObject player;
    public GameObject aura;

    public InputActionAsset inputAsset;
    private InputAction inputFire;

    private RectTransform thisRect;
    private RollPlayerSkills playerSkills;    
    private AudioSource ringAudio;

    void Start()
    {
        ringPosition = new Vector3(1070, 215, 0);

        aura.SetActive(false);

        inputFire = inputAsset.FindAction("Attack");

        thisRect = GetComponent<RectTransform>();
        playerSkills = player.GetComponent<RollPlayerSkills>();        
        ringAudio = GetComponent<AudioSource>();        
    }

   
    void Update()
    {
        //Move constantly the ring towards the left of the screen
        this.transform.Translate(-ringSpeed*Time.deltaTime,0,0);

        if (thisRect.anchoredPosition3D.x < -1070.0f)
        {
            //Deactivate the ring back to the pool when it reaches the opposite side of the screen
            thisRect.anchoredPosition3D = ringPosition;
            gameObject.SetActive(false);
        }

        if (thisRect.anchoredPosition3D.x <45 && thisRect.anchoredPosition3D.x > -45)
        {
            //Set the condition for perfect accuracy (quavers do a lot more damage) when the ring is inside the target
            playerSkills.perfectAccuracy = true;
            if (inputFire.WasPressedThisFrame())
            {
                aura.SetActive(true);
                ringAudio.Play();
            }
            
        }
        else if (thisRect.anchoredPosition3D.x < 95 && thisRect.anchoredPosition3D.x > -95)
        {
            //Set the condition for good accuracy (quavers do more damage) when the ring is almost inside the target
            playerSkills.goodAccuracy = true;
            if (inputFire.WasPressedThisFrame())
            {
                aura.SetActive(true);
                ringAudio.Play();
            }
        }
        else
        {
            //Deactivate accuracy booleans when far off target
            playerSkills.perfectAccuracy = false;
            playerSkills.goodAccuracy = false;
        }

        if (thisRect.anchoredPosition3D.x < -15)
        {
            //Deactivate the target hit aura when leaving the center
            aura.SetActive(false);
        }        
    }
}
