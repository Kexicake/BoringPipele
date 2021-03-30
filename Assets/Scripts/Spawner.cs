using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab1, prefab2, prefab3, prefab4, prefab5;

    public float spawnRate = 5f;

    public float nextSpawn = 0f;

    public int whatToSpawn;

    public float time = Time.time;


    public void spawwwwn()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);
            print(whatToSpawn);
            nextSpawn = Time.time + spawnRate;
            time = Time.time;
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(prefab2, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(prefab3, transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(prefab4, transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(prefab5, transform.position, Quaternion.identity);
                    break;
                default:
                    break;

            }



        }

    }
    void Update()
    {

        spawwwwn();
    }
}
