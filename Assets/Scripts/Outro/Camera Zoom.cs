using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    public Camera cam1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam1.orthographicSize >= 3.8)
        {
            cam1.orthographicSize -= (float)0.00003;
        }
    }
}
