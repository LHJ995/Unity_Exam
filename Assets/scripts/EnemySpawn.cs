using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private static EnemySpawn instance = null;

    public static EnemySpawn GetInstance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    private GameObject Parent;
    private GameObject Prefab;

    public float Distance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            Distance = 0.0f;

            // ** 생성되는 Enemy를 담아둘 상위 객체
            Parent = new GameObject("SpawnPoint");

            // ** Enemy로 사용할 원형 객체
            Prefab = Resources.Load("Prefabs/Enemy") as GameObject;
        }
    }

    private IEnumerator Start()
    {
        while (true)
        {
            // ** Enemy 원형객체를 복제한다.
            GameObject Obj = Instantiate(Prefab);

            // ** Enemy 작동 스크립트 포함.
            //Obj.AddComponent<EnemyController>();

            // ** 클론의 위치를 초기화.
            Obj.transform.position = new Vector3(
                24.58f, Random.Range(1.475f, 0.52f), 0.0f);

            Obj.transform.position = new Vector3(
                 24.58f, -0.497f, 0.0f);

            // ** 클론의 이름 초기화.
            Obj.transform.name = "Enemy";

            // ** 클론의 계층구조 설정.
            Obj.transform.SetParent(Parent.transform);

            // ** 1.5초 휴식.
            yield return new WaitForSeconds(1.5f);
        }
    }

    void Update()
    {
        if (ControllerManager.GetInstance().DirRight)
        {
            Distance += Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        }
    }
}
