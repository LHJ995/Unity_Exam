using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private float time;
    private bool state;

    public Text text;
    public Text Mob;

    public Image HP_1;
    public Image HP_2;
    public Image HP_3;
    public Image HP_4;
    public Image HP_5;

    void Start()
    {
        state = true;
    }

    void Update()
    {
        time += Time.deltaTime;
        
        text.text = (((int)time / 60) % 60).ToString() + " : " + ((int)time % 60).ToString();
        Mob.text = "Score : " + EnemySpawn.Count.ToString();

        if (PlayerController.HP <= 4)
            HP_5.gameObject.SetActive(false);
        if (PlayerController.HP <= 3)
            HP_4.gameObject.SetActive(false);
        if (PlayerController.HP <= 2)
            HP_3.gameObject.SetActive(false);
        if (PlayerController.HP <= 1)
            HP_2.gameObject.SetActive(false);
        if (PlayerController.HP <= 0)
            HP_1.gameObject.SetActive(false);
    }
}
