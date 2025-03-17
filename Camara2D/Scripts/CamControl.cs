using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CamControl : MonoBehaviour
{
    public float zoomSpeed;
    private CinemachineBrain camBrain;
    public CinemachineMixingCamera camMix;
    public CinemachineCamera camIn;
    public CinemachineCamera camOut;
    public CinemachineCamera camUptris;
    public CinemachineCamera camDowntris;

    public TextMeshProUGUI descripcion;

    public InputActionAsset playerInput;
    private InputAction switchCam;
    private InputAction uptrisInput;
    private InputAction downtrisInput;
    private InputAction zoomScroll;
    private InputAction deactivateCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camBrain=GetComponent<CinemachineBrain>();
        switchCam=playerInput.FindAction("jump");
        uptrisInput=playerInput.FindAction("spy");
        downtrisInput=playerInput.FindAction("previous");
        zoomScroll=playerInput.FindAction("ZoomScroll");
        deactivateCam=playerInput.FindAction("next");
    }

    // Update is called once per frame
    void Update()
    {
        //Transiciones de camara con input del jugador y mensaje en pantalla
        if(switchCam.IsInProgress())
        {
            camIn.Priority.Value=2;//camMix.SetWeight(camIn,1.0f);
            camOut.Priority.Value=1;//camMix.SetWeight(camOut,0.0f);
            descripcion.text= "Zoom In sin Dead Zone Confinamiento: Rojo";
        }
        else
        {
            camIn.Priority.Value=1;//camMix.SetWeight(camIn,0.0f);
            camOut.Priority.Value=2;//camMix.SetWeight(camOut,1.0f);
            descripcion.text= "Zoom Out con Dead Zone Confinamiento: Amarillo";
        }

        //Transiciones para camaras con group target
        if (uptrisInput.IsInProgress())
        {
            camUptris.Priority.Value=3;
        }
        else if(downtrisInput.IsInProgress())
        {
            camDowntris.Priority.Value=3;
        }
        else
        {
            camDowntris.Priority.Value=0;
            camUptris.Priority.Value=0;
        }

        //Zoom sobre el jugador
        camOut.Lens.OrthographicSize-=(zoomScroll.ReadValue<Vector2>().y*Time.deltaTime*zoomSpeed);

        //Cambio de camara deshabilitando gameobject de camra virtual
        if (deactivateCam.WasPressedThisFrame())
        {
            if (camOut.gameObject.activeSelf==true)
            {
                camOut.gameObject.SetActive(false);
            }
            else
            {
                camOut.gameObject.SetActive(true);
            }
        }
    }
}
