using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;

    public TextMeshProUGUI waveText;

    public int waveCount;
    public int wave;
    public int enemyType;
    public bool spawning;
    public int enemiesSpawned;
    private GameManager gameManager;

    private void Start()
    {
        waveCount = 5;
        wave = 1;
        spawning = false;
        enemiesSpawned = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void Update()
    {
        if (spawning == false && enemiesSpawned == gameManager.defeatedEnemies)
        {
            //AQUI SE CAMBIA EL LA CANTIDAD DE RONDAS
            if(wave == 4)
            {
                SceneManager.LoadScene("winScene");
            }
            StartCoroutine(SpawnWave(waveCount));
        }
    }

    IEnumerator SpawnWave(int waveC)
    {
        spawning = true;
        yield return new WaitForSeconds(1);
        waveText.text = "Wave " + wave;
        yield return new WaitForSeconds(4);
        waveText.text = "";
        for (int i = 0; i <waveC; i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(1);
        }
        wave += 1;
        waveCount += 20;
        spawning = false;

        yield break;
    }

    void SpawnEnemy(int wave)
    {
        int spawnPos = UnityEngine.Random.Range(0, 9);
        if (wave == 1)
        {
            enemyType = 1;
        }
        else 
        {
            enemyType = UnityEngine.Random.Range(0, 4);
        }

        Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, spawnPoints[spawnPos].transform.rotation);
        enemiesSpawned += 1;
    }
}
