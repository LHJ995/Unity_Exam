using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float Speed; // 움직이는 속도
    public static int HP;
    private Vector3 Movement; // 움직임 저장하는 벡터
    public Vector2 MoveEnd;

    // [상태체크]
    private bool OnAttack;
    private bool OnHit;
    private bool OnJump;
    private bool OnSlide;

    // 플레이어의 SpriteRenderer 구성요소 받아오기
    private SpriteRenderer spriteRenderer;

    // 플레이어의 Animator 구성요소 받아오기
    public Animator animator;

    // 복사할 총알 원본
    public GameObject BulletPrefab;
    // 복제된 총알의 저장 공간
    private List<GameObject> Bullets = new List<GameObject>();

    // 플레이어가 마지막으로 바라본 방향
    private float Direction;

    private void Awake()
    {
        // 위에 선언된 구성요소 받아오기
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // 속도 초기화
        Speed = 3.0f;

        // 상태 false로 초기화
        OnAttack = false;
        OnHit = false;
        OnSlide = false;

        // 초기 바라보는 상태
        Direction = 1.0f;

        Time.timeScale = 1.0f;

        HP = 5;
    }

    void Update()
    {
        // 입력값 체크
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxis("Vertical");

        spriteRenderer.flipX = (Hor < 0) ? true : false;

        // Hor이 0이면 멈춰있는 상태 이므로 예외처리
        if (Hor != 0)
            Direction = Hor;

        // 플레이어가 바라보고 있는 방향에 따라 이미지 설정
        if (Direction < 0)
            spriteRenderer.flipX = true;
        else if (Direction > 0)
            spriteRenderer.flipX = false;

        // 입력받은 값으로 플레이어 이동
        Movement = new Vector3(Hor * Time.deltaTime * Speed, Ver * Time.deltaTime * Speed, 0.0f);

        // 이벤트 발생
        if (Input.GetKeyDown(KeyCode.Z))
            onAttack();

        if (Input.GetKey(KeyCode.Space))
            onJump();

        if (Input.GetKey(KeyCode.LeftShift))
            onSlide();

        animator.SetFloat("Speed", Hor);
        transform.position += Movement;
        transform.localPosition = MaxPosition(transform.localPosition);
    }

    public Vector3 MaxPosition(Vector3 position)
    {
        return new Vector3
            (
                Mathf.Clamp(position.x, -MoveEnd.x, MoveEnd.x), Mathf.Clamp(position.y, -MoveEnd.y, MoveEnd.y), 0.0f
                );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            onHit();
            CanvasController.HpCheck = false;
            HP--;
        }
        if (HP == 0)
        {
            Time.timeScale = 0;
            CanvasController.gameovercheck = true;
            Destroy(this.gameObject);
        }
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

    private void ThrrowUp()
    {
        GameObject obj = Instantiate(BulletPrefab);
        obj.transform.position = transform.position;
        BulletController Controller = obj.AddComponent<BulletController>();

        Controller.Direction = new Vector3(Direction, 0.25f, 0);

        Bullets.Add(obj);
    }

    private void ThrrowMid()
    {
        GameObject obj = Instantiate(BulletPrefab);
        obj.transform.position = transform.position;
        BulletController Controller = obj.AddComponent<BulletController>();

        Controller.Direction = new Vector3(Direction, 0, 0);

        Bullets.Add(obj);
    }

    private void ThrrowDown()
    {
        GameObject obj = Instantiate(BulletPrefab);
        obj.transform.position = transform.position;
        BulletController Controller = obj.AddComponent<BulletController>();

        Controller.Direction = new Vector3(Direction, -0.25f, 0);

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
