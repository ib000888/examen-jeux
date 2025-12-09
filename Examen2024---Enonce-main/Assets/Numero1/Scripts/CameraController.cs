using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    int used = 0;
    Camera current;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Camera c in cameras)
        {
            c.enabled = false;
        }
        current = cameras[0];
        current.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            used = (used + 1) % 3;
            Camera old= current;
            current = cameras[used];
            current.enabled = true;
            old.enabled = false;
        }
    }
}
