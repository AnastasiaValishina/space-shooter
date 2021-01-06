﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float speed;
    [SerializeField] GameObject lazerShot;
    [SerializeField] GameObject lazerGun;
    [SerializeField] float timeBetweenShots;

    [SerializeField] GameObject enemyExplosion;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        InvokeRepeating("Shoot", 1f, timeBetweenShots);
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
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        }
    }
}