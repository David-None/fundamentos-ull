using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharControl : MonoBehaviour
{

    public float normalSpeed;
    public float turboSpeed;
    public float hinderAmount;
    private float hinder= 1.0f;
    public float hinderTime;
    private float speed;
    private int collectableCount;

    public UnityEvent specialEvent;

    public Material norMat;
    public Material hinderMat;
    public Toggle turboToggleUI;
    public TMP_Text collectableCountUI;
    public InputActionAsset inputAsset;
    private InputAction move;

    private IEnumerator coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = inputAsset.FindAction("Move");
        collectableCount = 0;
        collectableCountUI.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tDirection = new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y);
        if (turboToggleUI.isOn)
        {
            speed = turboSpeed*hinder;
        }
        else
        {
            speed = normalSpeed*hinder;
        }
        this.transform.Translate(tDirection.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collectable")
        {
            collectableCount++;
            collectableCountUI.text=collectableCount.ToString();
            Destroy(other.gameObject);
        }

        if(other.tag == "hinderer")
        {
            coroutine = Hinder();
            StartCoroutine(coroutine);
            Destroy(other.gameObject);
        }

        if(other.tag == "special")
        {
            specialEvent.Invoke();
            Destroy(other.gameObject);
        }
    }

    private IEnumerator Hinder()
    {
        hinder = hinderAmount;
        this.GetComponent<MeshRenderer>().material = hinderMat;
        yield return new WaitForSeconds(hinderTime);
        hinder = 1.0f;
        this.GetComponent<MeshRenderer>().material = norMat;
    }
}
