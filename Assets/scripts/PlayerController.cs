using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float Speed; // �����̴� �ӵ�
    private Vector3 Movement; // ������ �����ϴ� ����

    // [����üũ]
    private bool OnAttack;
    private bool OnHit;
    private bool OnJump;
    private bool OnSlide;

    // �÷��̾��� SpriteRenderer ������� �޾ƿ���
    private SpriteRenderer spriteRenderer;

    // �÷��̾��� Animator ������� �޾ƿ���
    public Animator animator;

    // ������ �Ѿ� ����
    public GameObject BulletPrefab;
    // ������ �Ѿ��� ���� ����
    private List<GameObject> Bullets = new List<GameObject>();

    // �÷��̾ ���������� �ٶ� ����
    private float Direction;

    private void Awake()
    {
        // ���� ����� ������� �޾ƿ���
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // �ӵ� �ʱ�ȭ
        Speed = 3.0f;

        // ���� false�� �ʱ�ȭ
        OnAttack = false;
        OnHit = false;
        OnSlide = false;

        // �ʱ� �ٶ󺸴� ����
        Direction = 1.0f;
    }

    void Update()
    {
        // �Է°� üũ
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxis("Vertical");

        spriteRenderer.flipX = (Hor < 0) ? true : false;

        // Hor�� 0�̸� �����ִ� ���� �̹Ƿ� ����ó��
        if (Hor != 0)
            Direction = Hor;

        // �÷��̾ �ٶ󺸰� �ִ� ���⿡ ���� �̹��� ����
        if (Direction < 0)
            spriteRenderer.flipX = true;
        else if (Direction > 0)
            spriteRenderer.flipX = false;

        // �Է¹��� ������ �÷��̾� �̵�
        Movement = new Vector3(Hor * Time.deltaTime * Speed, Ver * Time.deltaTime * Speed, 0.0f);

        // �̺�Ʈ �߻�
        if (Input.GetKeyDown(KeyCode.Z))
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

    private void Thrrow()
    {
        GameObject obj = Instantiate(BulletPrefab);
        obj.transform.position = transform.position;
        BulletController Controller = obj.AddComponent<BulletController>();

        Controller.Direction = new Vector3(Direction, 0, 0);

        Bullets.Add(obj);
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