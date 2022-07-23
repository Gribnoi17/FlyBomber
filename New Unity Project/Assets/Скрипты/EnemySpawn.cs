using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startwave = 0;
    [SerializeField] bool looping = false;
    
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }
    private IEnumerator SpawnAllWaves() 
    {
        for (int waveIndex = startwave; waveIndex < waveConfigs.Count; waveIndex++) {
            var currentwave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesinWave(currentwave));
        }
        
        startwave = Random.Range(0, 2);
    }
    private IEnumerator SpawnAllEnemiesinWave(WaveConfig waveConfig) {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberofEnemies(); enemyCount++)
        {

            float enemych = Random.Range(0.1f, 0.9f);
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(enemych),
                waveConfig.GetWayPoint()[0].transform.position,
                Quaternion.identity);
            


            newEnemy.GetComponent<EnemyMove>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    
}
