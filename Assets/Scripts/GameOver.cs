using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class GameOver : MonoBehaviour

{
    public GameObject GameOverScreen;

    private bool gameIsOver;
    public void Setup()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        gameIsOver = true;  
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("HWG");
        Cursor.visible = false;
        Time.timeScale = 1f;
        gameIsOver = false;

}

    public void ExitButton()
    {
        SceneManager.LoadScene("HWG_StartMenu");
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver && Input.GetKeyDown(KeyCode.R)) 
        { 
            RestartButton();
        }

        if (gameIsOver && Input.GetKeyDown(KeyCode.P))
        {
            ExitButton();
        }
    }
}
