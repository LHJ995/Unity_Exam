using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    private int SpawnCount;
    private float RandomRange;
    public static int Count = 0;

    public GameObject Enemy;
    private List<GameObject> EnemyList = new List<GameObject>();

    private Text MobCount;

    float time;

    void Awake()
    {
        MobCount = Text.FindObjectOfType<Text>();
    }

    private void Update()
    {
        SpawnCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
        time += Time.deltaTime;

        if (time > 2)
        {
            time = 0;
            int rand = Random.Range(0, 2);
            if (rand == 1 && SpawnCount < 20)
            {
                Vector3 spawnPos = new Vector3(24.26f, RandomRange = Random.Range(-1.35f, 0.5f), 0.0f);

                //����, ��ġ, ȸ������ �Ű������� �޾� ������Ʈ ����
                GameObject instance = Instantiate(Enemy, spawnPos, Quaternion.identity);
                EnemyList.Add(instance); //������Ʈ ������ ���� ����Ʈ�� add
            }
            if (rand == 0 && SpawnCount < 20)
            {
                Vector3 spawnPos = new Vector3(-24.26f, RandomRange = Random.Range(-1.35f, 0.5f), 0.0f);

                GameObject instance = Instantiate(Enemy, spawnPos, Quaternion.identity);
                EnemyList.Add(instance);
            }
        }
        
    }
}
