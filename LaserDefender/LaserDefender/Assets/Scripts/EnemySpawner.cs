﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> _waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] private bool looping = false;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < _waveConfigs.Count; waveIndex++)
        {
            var currentWave = _waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWaves(currentWave));
        }
    }

    IEnumerator SpawnAllEnemiesInWaves(WaveConfig waveConfig)
    {
        for (int enemyCount=0; enemyCount < waveConfig.NumberOfEnemies; enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.EnemyPrefab,
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
