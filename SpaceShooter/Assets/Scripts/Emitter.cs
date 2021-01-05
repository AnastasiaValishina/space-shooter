using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject[] asteroids;
    public float minDelayAst, maxDelayAst;

    public GameObject enemy;
    public float minDelayEnemy, maxDelayEnemy;

    private float nextLaunchTimeAst;
    private int randomAsteriod;

    private float nextLaunchTimeEnemy;

    void Update()
    {
        LaunchAsteroid();
        LaunchEnemy();
    }

    void LaunchAsteroid()
    {
        if (Time.time > nextLaunchTimeAst)
        {
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float yPosition = 0;
            float zPozition = transform.position.z;

            randomAsteriod = Random.Range(0, asteroids.Length);

            Instantiate(asteroids[randomAsteriod], new Vector3(xPosition, yPosition, zPozition), Quaternion.identity);
            nextLaunchTimeAst = Time.time + Random.Range(minDelayAst, minDelayAst);
        }
    }

    void LaunchEnemy()
    {
        if (Time.time > nextLaunchTimeEnemy)
        {
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            float yPosition = 0;
            float zPozition = transform.position.z;

            Instantiate(enemy, new Vector3(xPosition, yPosition, zPozition), Quaternion.Euler(0f, 180f, 0f));
            nextLaunchTimeEnemy = Time.time + Random.Range(minDelayEnemy, minDelayEnemy);
        }
    }
}
