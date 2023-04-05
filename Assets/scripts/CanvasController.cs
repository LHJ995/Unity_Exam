using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private float time;
    public static bool HpCheck;
    public static bool gameovercheck;

    public Text text;
    public Text Mob;
    public Text Score;

    public Image HP_1;
    public Image HP_2;
    public Image HP_3;
    public Image HP_4;
    public Image HP_5;

    public Image gameover;

    void Start()
    {
        HpCheck = true;
        gameovercheck = false;

        HP_1.gameObject.SetActive(true);
        HP_2.gameObject.SetActive(true);
        HP_3.gameObject.SetActive(true);
        HP_4.gameObject.SetActive(true);
        HP_5.gameObject.SetActive(true);
    }

    void Update()
    {
        time += Time.deltaTime;

        gameover.gameObject.SetActive(gameovercheck);

        text.text = (((int)time / 60) % 60).ToString() + " : " + ((int)time % 60).ToString();
        Mob.text = "Score : " + EnemySpawn.Count.ToString();

        Score.text = "Score : " + ((int)time + (EnemySpawn.Count * 3));

        if (PlayerController.HP <= 4 && HpCheck == false)
            HP_5.gameObject.SetActive(false);
        if (PlayerController.HP <= 3 && HpCheck == false)
            HP_4.gameObject.SetActive(false);
        if (PlayerController.HP <= 2 && HpCheck == false)
            HP_3.gameObject.SetActive(false);
        if (PlayerController.HP <= 1 && HpCheck == false)
            HP_2.gameObject.SetActive(false);
        if (PlayerController.HP <= 0 && HpCheck == false)
            HP_1.gameObject.SetActive(false);
    }
}
