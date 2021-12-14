using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private float randX;
    private float randY;
    private float randZ;

    public GameObject moneda;
    public GameObject bomba;

    private Vector3 randPos;

    public PlayerController playerControllerScript;

    private float repeatSpawn = 5f;
    private float startSpawn = 2f;
    

    void Start()
    {
        //Cada 5 segundos aparece un obstaculo
        InvokeRepeating("SpawnObstacle", startSpawn, repeatSpawn);

        //Al iniciar el juego aparecen 10 monedas
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();

        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    //Moneda aleatoria
    public void SpawnerR()
    {
        randX = Random.Range(120, -160);
        randY = Random.Range(0, 190);
        randZ = Random.Range(-100, 190);
        randPos = new Vector3(randX, randY, randZ);
        Instantiate(moneda, randPos, moneda.transform.rotation);
    }

    //Obstaculo aleatorio
    public void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            randX = Random.Range(120, -160);
            randY = Random.Range(0, 190);
            randZ = Random.Range(-100, 190);
            randPos = new Vector3(randX, randY, randZ);
            Instantiate(bomba, randPos, bomba.transform.rotation);
        }
    }
}
