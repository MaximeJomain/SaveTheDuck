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
        if (Time.time > nouveauSpawnPiranha){
            nouveauSpawnPiranha = Time.time + vitesseDeSpawnPiranha;
            Instantiate(PrefabPiranha, new Vector3(Random.Range(-8f, 8f), 1, Random.Range(-8f, 8f)), Quaternion.identity);
        }

        if (Time.time > nouveauSpawnAnguille)
        {
            nouveauSpawnAnguille = Time.time + vitesseDeSpawnAnguille;
            Instantiate(PrefabAnguille, new Vector3(Random.Range(-8f, 8f), 1, Random.Range(-8f, 8f)), Quaternion.identity);
        }

        if (Time.time > nouveauSpawnRequin)
        {
            nouveauSpawnRequin = Time.time + vitesseDeSpawnRequin;
            Instantiate(PrefabRequin, new Vector3(Random.Range(-8f, 8f), 1, Random.Range(-8f, 8f)), Quaternion.identity);
        }
    }
}