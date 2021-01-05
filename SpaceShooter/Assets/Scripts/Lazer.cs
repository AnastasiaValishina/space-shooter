using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float speed;
    public float directionX;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(directionX, 0, speed);
    }

}
