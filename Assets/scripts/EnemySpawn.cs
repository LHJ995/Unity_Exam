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

                //원본, 위치, 회전값을 매개변수로 받아 오브젝트 복제
                GameObject instance = Instantiate(Enemy, spawnPos, Quaternion.identity);
                EnemyList.Add(instance); //오브젝트 관리를 위해 리스트에 add
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
