using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    public int HP;
    public float Speed;
    private Vector3 look;

    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D body;

    private bool OnHit;
    private bool OnDead;
    private bool Alive;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        OnHit = false;
        OnDead = false;
        Alive = true;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Alive)
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
            onHit();
        }

        if (HP <= 0)
        {
            onDead();
            Alive = false;
            EnemySpawn.Count++;
            Destroy(body);
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
