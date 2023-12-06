using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private GameObject tankPrefab;

    [SerializeField]
    private GameObject pointPrefab;

    private float spawnRange = 15.0f;
    private int enemyCount;
    private int waveNumber = 1;

    private bool isGameActive;

    [SerializeField]
    private Text WaveText;

    void Start()
    {
        isGameActive = true;

        // Abstraction
        SpawnEnemyWave(waveNumber, false);
    }

    void Update()
    {
        if (isGameActive)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if(enemyCount == 0)
            {
                waveNumber++;
                WaveText.text = $"Wave: {waveNumber}";
                SpawnEnemyWave(waveNumber, false);
                Instantiate(pointPrefab, GenerateSpawnPosition(), pointPrefab.transform.rotation);
                // Boss Wave
                if(waveNumber % 3 == 0)
                {
                    Instantiate(tankPrefab, GenerateSpawnPosition(), tankPrefab.transform.rotation);
                    Instantiate(pointPrefab, GenerateSpawnPosition(), pointPrefab.transform.rotation);

                }
            }
        }
    }

    // Abstraction
    public void SpawnEnemyWave(int enemiesToSpawn, bool isBoss)
    {
        if (!isBoss)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[enemyIndex], GenerateSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
            }
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 2, spawnPosZ);

        return randomPos;
    }

}
