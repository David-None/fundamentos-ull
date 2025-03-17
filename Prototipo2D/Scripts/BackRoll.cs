using UnityEngine;

public class BackRoll : MonoBehaviour
{
    public float rollPercent;

    private Vector3 pastCamPos;
    private Vector3 currentCamPos;

    public Transform camTarget;

    private Renderer backMat;

    void Start()
    {
        backMat = GetComponent<Renderer>();
        currentCamPos= camTarget.position;
    }
    
    void Update()
    {
        //Roll background textures with the position of the camera
        pastCamPos=currentCamPos;
        currentCamPos = camTarget.position;
        this.transform.position = new Vector3(camTarget.position.x, camTarget.position.y, 0);
        Vector2 deltaCamPos = new Vector2(currentCamPos.x - pastCamPos.x,currentCamPos.y-pastCamPos.y);
        Vector2 currentOffset = backMat.material.GetTextureOffset("_MainTex");
        backMat.material.SetTextureOffset("_MainTex", currentOffset-(deltaCamPos*rollPercent));
    }
}
