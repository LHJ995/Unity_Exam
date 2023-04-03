using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("GameScene_1");
        Debug.Log("Start");
    }

    public void OnClickOption()
    {
        Debug.Log("Option");
    }

    public void OnClickExit()
    {
        Debug.Log("Exit");
    }
}
