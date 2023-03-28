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

            // ** �����Ǵ� Enemy�� ��Ƶ� ���� ��ü
            Parent = new GameObject("SpawnPoint");

            // ** Enemy�� ����� ���� ��ü
            Prefab = Resources.Load("Prefabs/Enemy") as GameObject;
        }
    }

    private IEnumerator Start()
    {
        while (true)
        {
            // ** Enemy ������ü�� �����Ѵ�.
            GameObject Obj = Instantiate(Prefab);

            // ** Enemy �۵� ��ũ��Ʈ ����.
            //Obj.AddComponent<EnemyController>();

            // ** Ŭ���� ��ġ�� �ʱ�ȭ.
            Obj.transform.position = new Vector3(
                24.58f, Random.Range(1.475f, 0.52f), 0.0f);

            Obj.transform.position = new Vector3(
                 24.58f, -0.497f, 0.0f);

            // ** Ŭ���� �̸� �ʱ�ȭ.
            Obj.transform.name = "Enemy";

            // ** Ŭ���� �������� ����.
            Obj.transform.SetParent(Parent.transform);

            // ** 1.5�� �޽�.
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
