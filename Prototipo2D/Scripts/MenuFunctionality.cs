using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour
{
    private AudioSource menuAudio;
    
    void Start()
    {
        menuAudio = GetComponent<AudioSource>();
    }
    
    //Functionality for different menu buttons
    public void StartGame()
    {
        menuAudio.Play();
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        menuAudio.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        menuAudio.Play();        
        Application.Quit();
    }
}
