using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public CanardScript Canard;


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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nouveauSpawnPiranha) {
            nouveauSpawnPiranha = Time.time + vitesseDeSpawnPiranha;

            int Int = Random.Range(0, 4);
            switch (Int)
            {
                case 0: Instantiate(PrefabPiranha, new Vector3(-1f, 0.55f, Random.Range(-0.3f, 0.3f)), Quaternion.identity); break;
                case 1: Instantiate(PrefabPiranha, new Vector3(1f, 0.55f, Random.Range(-0.3f, 0.3f)), Quaternion.identity); break;
                case 2: Instantiate(PrefabPiranha, new Vector3(Random.Range(-1f, 1f), 0.55f, -0.3f), Quaternion.identity); break;
                case 3: Instantiate(PrefabPiranha, new Vector3(Random.Range(-1f, 1f), 0.55f, 0.3f), Quaternion.identity); break;
            }
        }

        /*if (Time.time > nouveauSpawnAnguille)
        {
            nouveauSpawnAnguille = Time.time + vitesseDeSpawnAnguille;

            int Int = Random.Range(0, 4);
            switch (Int)
            {
                case 0: Instantiate(PrefabAnguille, new Vector3(-1f, 0.6f, Random.Range(-0.3f, 0.3f)), Quaternion.identity); break;
                case 1: Instantiate(PrefabAnguille, new Vector3(1f, 0.6f, Random.Range(-0.3f, 0.3f)), Quaternion.identity); break;
                case 2: Instantiate(PrefabAnguille, new Vector3(Random.Range(-1f, 1f), 0.6f, -0.3f), Quaternion.identity); break;
                case 3: Instantiate(PrefabAnguille, new Vector3(Random.Range(-1f, 1f), 0.6f, 0.3f), Quaternion.identity); break;
            }
        }

        if (Time.time > nouveauSpawnRequin)
        {
            nouveauSpawnRequin = Time.time + vitesseDeSpawnRequin;

            int Int = Random.Range(0, 4);
            switch (Int)
            {
                case 0: Instantiate(PrefabRequin, new Vector3(-1f, 0.6f, Random.Range(-0.3f, 0.3f)), Quaternion.identity); break;
                case 1: Instantiate(PrefabRequin, new Vector3(1f, 0.6f, Random.Range(-0.3f, 0.3f)), Quaternion.identity); break;
                case 2: Instantiate(PrefabRequin, new Vector3(Random.Range(-1f, 1f), 0.6f, -0.3f), Quaternion.identity); break;
                case 3: Instantiate(PrefabRequin, new Vector3(Random.Range(-1f, 1f), 0.6f, 0.3f), Quaternion.identity); break;
            }
        }*/
    }
}