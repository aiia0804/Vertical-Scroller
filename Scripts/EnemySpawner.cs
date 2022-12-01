using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    [SerializeField] bool loop = false;

    IEnumerator Start()
    {
        do
        {
            yield return (spawnAllWaves());
        } while (loop);

    }

    private IEnumerator spawnAllWaves()
    {
        for (var waveIndex = startWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(spawnAllEnemyInWave(currentWave));
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator spawnAllEnemyInWave(WaveConfig waveConfig)
    {
        for (var enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemy(); enemyCount++)
        {

            var newEnemy = Instantiate(waveConfig.GetEnemyPrefb(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWayConvig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawn());
        }
    }
}
