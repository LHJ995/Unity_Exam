using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float Speed;
    Vector3 cameraposition = new Vector3(0, 0, -5.8f);
    public GameObject target;

    void Start()
    {
        Speed = 2.0f;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            target.transform.position + cameraposition,
            Time.deltaTime * Speed);
    }
}
