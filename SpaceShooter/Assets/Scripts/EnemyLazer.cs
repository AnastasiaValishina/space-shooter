using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazer : MonoBehaviour
{
    public float speed;
    public GameObject playerExplosion;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
    }
 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary")
        {
            return;
        }

        if (other.tag == "Asteroid")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        Destroy(other.gameObject);
    }*/
}