using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button level_select;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public static int previousScreenIndex = -1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("escape"))
        {
            if(GameIsPaused)
            {
                Debug.Log(Input.GetKey("escape"));
                Debug.Log("Resume");
                Resume();
            }
            else
            {
                Debug.Log(Input.GetKey("escape"));
                Debug.Log("Pause");
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }  

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void PlayGame()
    {
        int screenIndex = 0;

        if (level_select.gameObject.tag == "level1")
        {
            SceneManager.LoadScene(2);
            screenIndex = 2;
        }
        else if (level_select.gameObject.tag == "level2")
        {
            SceneManager.LoadScene(3);
            screenIndex = 3;
        }
        else if (level_select.gameObject.tag == "level3")
        {
            SceneManager.LoadScene(4);
            screenIndex = 4;
        }
        else if (level_select.gameObject.tag == "level4")
        {
            SceneManager.LoadScene(5);
            screenIndex = 5;
        }
        else if (level_select.gameObject.tag == "level5")
        {
            SceneManager.LoadScene(6);
            screenIndex = 6;
        }
        else if (level_select.gameObject.tag == "level6")
        {
            SceneManager.LoadScene(7);
            screenIndex = 7;
        }
        else if (level_select.gameObject.tag == "level7")
        {
            SceneManager.LoadScene(8);
            screenIndex = 8;
        }
        else if (level_select.gameObject.tag == "level8")
        {
            SceneManager.LoadScene(9);
            screenIndex = 9;
        }
        else if (level_select.gameObject.tag == "level9")
        {
            SceneManager.LoadScene(10);
            screenIndex = 10;
        }
        else
        {
            SceneManager.LoadScene(11);
            screenIndex = 11;
        }
        previousScreenIndex = screenIndex;
    }

    public void OpenAchievements()
    {
        SceneManager.LoadScene(12);
    }

    public void BackToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void BackToSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNextLevel()
    {
        if (previousScreenIndex != -1 && previousScreenIndex < 11)
        {
            previousScreenIndex++;
            SceneManager.LoadScene(previousScreenIndex);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(previousScreenIndex);
    }

}
