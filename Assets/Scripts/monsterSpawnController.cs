using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterSpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnMonster", 0f, 1f);

    }

    void SpawnMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
