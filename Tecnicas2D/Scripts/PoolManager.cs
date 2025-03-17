using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public List<GameObject> pickPool;
    public GameObject pickPrefab;
    public Transform camTransform;

    public int poolSize;
    public float randomRangeX;
    public float randomRangeY;
    public int minActivePicks;
    public int currentActivePicks;

    private bool needsNewPool=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentActivePicks=0;
        foreach(GameObject pickable in pickPool)
        {
            if(pickable.activeSelf)
            {
                currentActivePicks++;
            }
        }
    }

    public void ManagePicks()
    {
        
        if (currentActivePicks < minActivePicks)
        {
            needsNewPool=true;
            ActivatePick();
        }
        // Si no encontramos ningun pickable inactivo, needsNewPool seguira siendo verdadero y activara el metodo de creacion de pool
        if (needsNewPool)
        {
            Debug.Log("Creando una piscina");
            CreateNewPool();
            
        }
    }

    public void CreateNewPool()
    {
        // Creamos un nuevo pool con una cantidad de objetos poolSize
        for(int i=0; i < poolSize; i++)
        {
            GameObject newInstance=Instantiate(pickPrefab);
            newInstance.SetActive(false);
            pickPool.Add(newInstance);
        }
        ActivatePick();        
    }

    public void ActivatePick()
    {
        // Repasamos el array de pickables hasta encontrar un inactivo
        foreach (GameObject pickable in pickPool)
        {
            if (!pickable.activeSelf)
            {
                //Le damos una posicion aleatoria, lo activamos y dejamos de buscar en el array
                float spawnPosX = camTransform.position.x+Random.Range(-randomRangeX,randomRangeX);
                float spawnPosY = camTransform.position.y+Random.Range(-randomRangeY,0);
                Vector3 spawnPos = new Vector3(spawnPosX,spawnPosY,0.0f);
                pickable.GetComponent<Transform>().position= spawnPos;
                pickable.SetActive(true);
                currentActivePicks++;
                Debug.Log(pickable.name+" se enciende.");
                Debug.Log("Pickables activos: "+currentActivePicks.ToString());
                needsNewPool=false;
                break;
            }
        }
    }
}
