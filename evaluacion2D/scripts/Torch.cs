using UnityEngine;

public class Torch : MonoBehaviour
{
    public Plataforma platafoma;
    
    void Start()
    {
        //Escuchar cuando se interactua con la plataforma de salto
        platafoma.jumpPlatform.AddListener(ActivateMe);
        gameObject.SetActive(false);
    }

    void ActivateMe()
    {
        this.gameObject.SetActive(true);
    }
}
