using UnityEngine;

public class Damager : MonoBehaviour
{
    public Plataforma platafoma;
    
    void Start()
    {
        //Escuchar cuando se interactua con la plataforma de salto
        platafoma.jumpPlatform.AddListener(DeactivateMe);
    }

    void DeactivateMe()
    {
        this.gameObject.SetActive(false);
    }
}
