using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    public InputActionAsset iAsset;
    private InputAction zoomOut;

    public CinemachineCamera followCam;
    public CinemachineCamera levelCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zoomOut = iAsset.FindAction("zoomOut");
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomOut.IsInProgress())
        {
            levelCam.Priority.Value = 2;
        }
        if(zoomOut.WasReleasedThisFrame())
        {
            levelCam.Priority.Value = 0;
        }
    }
}
