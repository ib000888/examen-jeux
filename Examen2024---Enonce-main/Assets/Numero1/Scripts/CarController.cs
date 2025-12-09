using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float Speed;

    [SerializeField] private float Amplitude;

    float refTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        refTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsed = Time.time - refTime;
        gameObject.transform.Translate( new Vector3(0,0,Mathf.Sin(elapsed * Speed) * Amplitude));

    }
}
