using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float shift = Mathf.Repeat(Time.time * speed, 150);
        transform.position = startPosition + new Vector3(0, 0, -shift) ;
    }
}
