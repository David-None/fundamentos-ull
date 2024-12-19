using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour
{
    public Trophy[] trophyArray;
    public UnityEvent managerEvent;
    public UnityEvent specialTrophy;
    public float totalPoints;
    public TextMeshProUGUI pointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalPoints = 0;
        trophyCollected();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trophyCollected()
    {
        pointsText.text = "Puntos: " + totalPoints.ToString();
        trophyArray = FindObjectsByType<Trophy>(FindObjectsSortMode.None);
        managerEvent.Invoke();
    }
    public void specialTrophyCollected()
    {
        specialTrophy.Invoke();
    }
}
