using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerScript : MonoBehaviour
{
    private CanardScript Canard;


    public GameObject PrefabPiranha;

    public GameObject PrefabAnguille;

    public GameObject PrefabRequin;


    public float vitesseDeSpawnPiranha = 10;

    public float vitesseDeSpawnAnguille = 30;

    public float vitesseDeSpawnRequin = 60;

    public float nouveauSpawnPiranha = 0;

    public float nouveauSpawnAnguille = 0;

    public float nouveauSpawnRequin = 0;
    
    public int nombreDeSpawn;

    public int nombreMaxDeSpawn;

    private int nombreDePrefab;

    [Header("Spawner")]
    public Transform[] Points;

    private void Awake()
    {
        Canard = GameObject.Find("Canard").GetComponent<CanardScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nouveauSpawnPiranha) {
            nouveauSpawnPiranha = Time.time + vitesseDeSpawnPiranha;

            int rand = Random.Range(0, Points.Length);
            Instantiate(PrefabPiranha, Points[rand].transform.position, Quaternion.identity);

            // switch (Int)
            // {
            //     case 0: Instantiate(PrefabPiranha, new Vector3(-2.25f, Canard.transform.position.y, Random.Range(-0.6f, 0.6f)), Quaternion.Euler(0,270,0)); break;
            //     case 1: Instantiate(PrefabPiranha, new Vector3(2.25f, Canard.transform.position.y, Random.Range(-0.6f, 0.6f)), Quaternion.Euler(0, 270, 0)); break;
            //     case 2: Instantiate(PrefabPiranha, new Vector3(Random.Range(-2.25f, 2.25f), Canard.transform.position.y, -0.6f), Quaternion.Euler(0, 270, 0)); break;
            //     case 3: Instantiate(PrefabPiranha, new Vector3(Random.Range(-2.25f, 2.25f), Canard.transform.position.y, 0.6f), Quaternion.Euler(0, 270, 0)); break;
            // }
        }

        if (Time.time > nouveauSpawnAnguille)
        {
            nouveauSpawnAnguille = Time.time + vitesseDeSpawnAnguille;
            
            int rand = Random.Range(0, Points.Length);
            Instantiate(PrefabAnguille, Points[rand].transform.position, Quaternion.identity);
        
            // int Int = Random.Range(0, 4);
            // switch (Int)
            // {
            //     case 0: Instantiate(PrefabAnguille, new Vector3(-2.25f, 1.5f, Random.Range(-0.6f, 0.6f)), Quaternion.Euler(0, 90, 0)); break;
            //     case 1: Instantiate(PrefabAnguille, new Vector3(2.25f, 1.5f, Random.Range(-0.6f, 0.6f)), Quaternion.Euler(0, 90, 0)); break;
            //     case 2: Instantiate(PrefabAnguille, new Vector3(Random.Range(-2.25f, 2.25f), 1.5f, -0.6f), Quaternion.Euler(0, 90, 0)); break;
            //     case 3: Instantiate(PrefabAnguille, new Vector3(Random.Range(-2.25f, 2.25f), 0.15f, 0.6f), Quaternion.Euler(0, 90, 0)); break;
            // }
        }
        
        if (Time.time > nouveauSpawnRequin)
        {
            nouveauSpawnRequin = Time.time + vitesseDeSpawnRequin;
            
            int rand = Random.Range(0, Points.Length);
            Instantiate(PrefabRequin, Points[rand].transform.position, Quaternion.identity);
        
            // int Int = Random.Range(0, 4);
            // switch (Int)
            // {
            //     case 0: Instantiate(PrefabRequin, new Vector3(-2.25f, 1.5f, Random.Range(-0.6f, 0.6f)), Quaternion.Euler(270, 180, 0)); break;
            //     case 1: Instantiate(PrefabRequin, new Vector3(2.25f, 1.5f, Random.Range(-0.6f, 0.6f)), Quaternion.Euler(270, 180, 0)); break;
            //     case 2: Instantiate(PrefabRequin, new Vector3(Random.Range(-2.25f, 2.25f), 1.5f, -0.6f), Quaternion.Euler(270, 180, 0)); break;
            //     case 3: Instantiate(PrefabRequin, new Vector3(Random.Range(-2.25f, 2.25f), 0.15f, 0.6f), Quaternion.Euler(270, 180, 0)); break;
            // }
        }
    }
}