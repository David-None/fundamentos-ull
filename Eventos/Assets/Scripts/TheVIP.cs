using UnityEngine;

public class TheVIP : MonoBehaviour
{
    public CharControl mainChar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainChar.specialEvent.AddListener(MoveMe);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveMe()
    {
        this.transform.position = new Vector3(0, 1, 0);
    }
}
