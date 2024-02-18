using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Victory : MonoBehaviour
{
    public GameObject VictoryScreen;
    public GameObject Player;
    public void Setup()
    {
        VictoryScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("HWG_Whitebox");
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("HWG_StartMenu");
    }
}
