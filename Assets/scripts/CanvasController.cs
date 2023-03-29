using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private float time;

    public Text text;
    public Text Mob;

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        
        text.text = (((int)time / 60) % 60).ToString() + " : " + ((int)time % 60).ToString();
        Mob.text = "Score : " + EnemySpawn.Count.ToString();
    }
}
