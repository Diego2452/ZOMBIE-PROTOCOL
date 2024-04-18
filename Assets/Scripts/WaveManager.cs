using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;

    public int waveCount;
    public int wave;
    public int enemyType;
    public bool spawning;
    public int enemiesSpawned;
    private GameManager gameManager;

    private void Start()
    {
        waveCount = 2;
        wave = 1;
        spawning = false;
        enemiesSpawned = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void Update()
    {
        if (spawning == false && enemiesSpawned == gameManager.defeatedEnemies)
        {
            StartCoroutine(SpawnWave(waveCount));
        }
    }

    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;

        yield return new WaitForSeconds(4);

        for (int i = 0; i <waveC; i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(2);
        }
        wave += 1;
        waveCount += 2;
        spawning = false;

        yield break;
    }

    void SpawnEnemy(int wave)
    {
        int spawnPos = UnityEngine.Random.Range(0, 6);
        if (wave == 1)
        {
            enemyType = 1;
        }
        else 
        {
            enemyType = UnityEngine.Random.Range(0, 2);
        }

        Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
        enemiesSpawned += 1;
    }
}
