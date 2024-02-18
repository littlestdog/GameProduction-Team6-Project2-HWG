using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Victory : MonoBehaviour
{
    public GameObject VictoryScreen;
    private bool isGameWon;

    private void Start()
    {
    }
    public void Setup()
    {
        VictoryScreen.SetActive(true);
        Time.timeScale = 0.0f;
        isGameWon = true;
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

    private void Update()
    {
        if (isGameWon && Input.GetKeyDown(KeyCode.R))
        {
            RestartButton();
        }

        if (isGameWon && Input.GetKeyDown(KeyCode.P))
        {
            ExitButton();
        }
    }
}
