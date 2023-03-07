using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float Speed;
    private Vector3 Movement;
    private bool OnAttack;
    private bool OnHit;
    private bool OnJump;
    private bool OnSlide;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Speed = 5.0f;

        animator = this.GetComponent<Animator>();

        OnAttack = false;
        OnHit = false;
        OnSlide = false;
    }

    // Update is called once per frame
    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxis("Vertical");
        // Vector3 flipmove = Vector3.zero;

        Movement = new Vector3(Hor * Time.deltaTime * Speed, Ver * Time.deltaTime * Speed, 0.0f);

        // if (Input.GetAxisRaw("Horizontal") < 0)
        // {
        //     flipmove = Vector3.left;
        //     transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        // }
        // else if (Input.GetAxisRaw("horizontal") > 0)
        // {
        //     flipmove = Vector3.right;
        //     transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        // }


        if (Input.GetKey(KeyCode.Z))
            onAttack();

        if (Input.GetKey(KeyCode.Space))
            onJump();

        if (Input.GetKey(KeyCode.LeftShift))
            onSlide();

        if (Input.GetKey(KeyCode.T))
            onHit();

        animator.SetFloat("Speed", Hor);
        transform.position += Movement;
    }

    void onAttack()
    {
        if (OnAttack)
            return;

        OnAttack = true;
        animator.SetTrigger("Attack");
    }

    private void SetAttack()
    {
        OnAttack = false;
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

    void onJump()
    {
        if (OnJump)
            return;

        OnJump = true;
        animator.SetTrigger("Jump");
    }

    private void SetJump()
    {
        OnJump = false;
    }

    void onSlide()
    {
        if (OnSlide)
            return;

        OnSlide = true;
        animator.SetTrigger("Slide");
    }

    private void SetSlide()
    {
        OnSlide = false;
    }
}
