using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    [Header("Asteroids")]
    [SerializeField] GameObject[] asteroids;
    [SerializeField] float minDelayAst, maxDelayAst;
    float nextLaunchTimeAst;
    int randomAsteriod;

    [Header("Enemy Pathing")]
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;

    private IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = 0; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(), 
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.Euler(0f, 180f, 0f));
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    void Update()
    {
        LaunchAsteroid();
    }

    void LaunchAsteroid()
    {
        if (Time.time > nextLaunchTimeAst)
        {
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float zPozition = transform.position.z;

            randomAsteriod = Random.Range(0, asteroids.Length);

            Instantiate(asteroids[randomAsteriod], new Vector3(xPosition, 0, zPozition), Quaternion.identity);
            nextLaunchTimeAst = Time.time + Random.Range(minDelayAst, minDelayAst);
        }
    }  
}
