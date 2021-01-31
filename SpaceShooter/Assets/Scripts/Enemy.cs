using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 1;
    [SerializeField] float speed;

    [Header("Shooting")]
    [SerializeField] GameObject lazerShot;
    [SerializeField] GameObject lazerGun;
    [SerializeField] float timeBetweenShots;
    [SerializeField] GameObject enemyExplosion;

    void Start()
    {
        InvokeRepeating("Shoot", UnityEngine.Random.Range(0.1f, 1f), timeBetweenShots);
    }

    void Shoot()
    {
         Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        }
    }
}
