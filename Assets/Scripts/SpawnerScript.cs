using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    private CanardScript Canard;

    [Range(0.5f, 2)]
    public float spawnRate;
    private float elapsedTime;
    
    private float useSpawnRate;

    public GameObject PrefabPiranha;

    public GameObject PrefabAnguille;

    public GameObject PrefabRequin;


    public float vitesseDeSpawnPiranha;

    public float vitesseDeSpawnAnguille;

    public float vitesseDeSpawnRequin;

    private float nouveauSpawnPiranha;

    private float nouveauSpawnAnguille;

    private float nouveauSpawnRequin;

    private int nombreDePrefab;
    private int spawnIndex;

    [Header("Spawner")]
    public Transform[] Points;
    public float spawnRateIncrease = 30f;

    private void Awake()
    {
        Canard = GameObject.Find("Canard").GetComponent<CanardScript>();
    }

    private void Start()
    {
        spawnIndex = 0;
        elapsedTime = 0f;
        useSpawnRate = spawnRate;
        nouveauSpawnPiranha = vitesseDeSpawnPiranha;
        nouveauSpawnAnguille = vitesseDeSpawnAnguille;
        nouveauSpawnRequin = vitesseDeSpawnRequin;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime * useSpawnRate;

        if (elapsedTime >= 3f)
        {
            elapsedTime = 0f;
            int rand = Random.Range(0, Points.Length);

            switch (spawnIndex)
            {
                case 0: 
                    Instantiate(PrefabPiranha, Points[rand].position, Quaternion.identity);
                    break;
                    
                case 1: 
                    Instantiate(PrefabAnguille, Points[rand].transform.position, Quaternion.identity);
                    break;
                
                case 2: 
                    Instantiate(PrefabPiranha, Points[rand].position, Quaternion.identity);
                    break;
                
                case 3: 
                    Instantiate(PrefabRequin, Points[rand].transform.position, Quaternion.identity);
                    break;
                
                default:
                    Instantiate(PrefabPiranha, Points[rand].position, Quaternion.identity);
                    break;
            }
            
            spawnIndex++;
        }

        if (spawnIndex >= 4)
        {
            spawnIndex = 0;
        }

        useSpawnRate += Time.deltaTime/spawnRateIncrease;

        // if (elapsedTime >= nouveauSpawnPiranha)
        // {
        //     int rand = Random.Range(0, Points.Length);
        //     Instantiate(PrefabPiranha, Points[rand].position, Quaternion.identity);
        //
        //     nouveauSpawnPiranha = elapsedTime + vitesseDeSpawnPiranha;
        // }
        //
        // if (elapsedTime > nouveauSpawnAnguille)
        // {
        //     int rand = Random.Range(0, Points.Length);
        //     Instantiate(PrefabAnguille, Points[rand].transform.position, Quaternion.identity);
        //     
        //     nouveauSpawnAnguille = elapsedTime + vitesseDeSpawnPiranha;
        // }
        //
        // if (elapsedTime > nouveauSpawnRequin)
        // {
        //     int rand = Random.Range(0, Points.Length);
        //     Instantiate(PrefabRequin, Points[rand].transform.position, Quaternion.identity);
        //     
        //     nouveauSpawnRequin = elapsedTime + vitesseDeSpawnPiranha;
        // }
    }
}
