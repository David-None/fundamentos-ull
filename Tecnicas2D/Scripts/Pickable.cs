using System;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{

    public int destroyCountdown;
    private PoolManager poolManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        poolManager=FindFirstObjectByType<PoolManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // "Apagamos" este game object
            this.gameObject.SetActive(false);
            Debug.Log(this.gameObject.name+" se apaga.");

            // Le remitimos al Pool Manager que hay un pickable activo menos y activamos su metodo de gestion de pickables
            CallPool();

            // Descontamos hasta la destruccion y en su caso destruimos el game object
            destroyCountdown--;
            if (destroyCountdown <= 0)
            {
                int indexToDestroy=poolManager.pickPool.IndexOf(gameObject);
                poolManager.pickPool.RemoveAt(indexToDestroy);
                CallPool();
                Destroy(gameObject);
                Debug.Log(this.gameObject.name+" se destruye.");
            }
        }
    }

    void CallPool()
    {
        // Le remitimos al Pool Manager que hay un pickable activo menos y activamos su metodo de gestion de pickables
        poolManager.currentActivePicks--;
        Debug.Log("Pickables activos: "+poolManager.currentActivePicks.ToString());
        poolManager.ManagePicks();
    }
}
