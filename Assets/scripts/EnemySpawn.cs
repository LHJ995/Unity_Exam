using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private int SpawnCount;
    private float RandomRange;

    public GameObject Enemy;
    private List<GameObject> EnemyList = new List<GameObject>();

    float time;
    void Start()
    {

    }

    private void Update()
    {
        SpawnCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
        time += Time.deltaTime;

        if (time > 5)
        {
            time = 0;
            if (SpawnCount < 3)
            {
                Vector3 spawnPos = new Vector3(24.58f, RandomRange = Random.Range(-1.35f, 0.5f), 0.0f);

                //원본, 위치, 회전값을 매개변수로 받아 오브젝트 복제
                GameObject instance = Instantiate(Enemy, spawnPos, Quaternion.identity);
                EnemyList.Add(instance); //오브젝트 관리를 위해 리스트에 add
            }
        }
        
    }
}
