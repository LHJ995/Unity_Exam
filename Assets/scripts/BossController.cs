using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    CircleCollider2D body;
    [SerializeField]
    Transform playerTransform;

    private bool Alive;
    private bool Onwalk;
    private bool Onhit;
    private bool Ondead;
    private float Speed;
    private int HP;

    private Vector3 look;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        Alive = true;
        Onwalk = false;
        Onhit = false;
        Ondead = false;

        Speed = 1.0f;
        HP = 10;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Alive)
        {
            transform.position = Vector3.MoveTowards
            (transform.position, playerTransform.position, Time.deltaTime * Speed);

            look = playerTransform.position - transform.position;

            if (look.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            --HP;
            OnHit();
        }

        if (HP <= 0)
        {
            OnDead();
            Alive = false;
            EnemySpawn.Count += 5;
            Destroy(body);
            Destroy(this.gameObject, 1.15f);
        }
    }

    void OnWalk()
    {
        if (Onwalk)
            return;

        Onwalk = true;
        animator.SetTrigger("Walk");
    }

    void Setwalk()
    {
        Onwalk = false;
    }

    void OnHit()
    {
        if (Onhit)
            return;

        Onhit = true;
        animator.SetTrigger("Hit");
    }

    void Sethit()
    {
        Onhit = false;
    }

    void OnDead()
    {
        if (Ondead)
            return;

        Ondead = true;
        animator.SetTrigger("Dead");
    }
}
