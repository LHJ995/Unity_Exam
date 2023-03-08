using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float Speed;

    // public Vector3 Direction
    // {
    //     get
    //     {
    //         return direction;
    //     }
    //     set
    //     {
    //         direction = value;
    //     }
    // }

    public Vector3 Direction { get; set; }

    void Start()
    {
        Speed = 5.0f;
    }

    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, 0, -2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            Destroy(this.gameObject);
    }
}
