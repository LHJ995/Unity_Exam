using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int HP;

    public Animator animator;

    private bool OnHit;
    private bool OnDead;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    void Start()
    {
        OnHit = false;
        OnDead = false;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            --HP;
            onHit();
        }

        if (HP == 0)
        {
            onDead();

            Destroy(this.gameObject, 1);
        }
    }

    void onHit()
    {
        if (OnHit)
            return;

        OnHit = true;
        animator.SetTrigger("Hit");
    }

    private void SetHit()
    {
        OnHit = false;
    }

    void onDead()
    {
        if (OnDead)
            return;

        OnDead = true;
        animator.SetTrigger("Dead");
    }
}
