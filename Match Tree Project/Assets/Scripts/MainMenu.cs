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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
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
        if (level_select.gameObject.tag == "level1")
            SceneManager.LoadScene(2);
        else if (level_select.gameObject.tag == "level2")
            SceneManager.LoadScene(3);
        else if (level_select.gameObject.tag == "level3")
            SceneManager.LoadScene(4);
        else if (level_select.gameObject.tag == "level4")
            SceneManager.LoadScene(5);
        else if (level_select.gameObject.tag == "level5")
            SceneManager.LoadScene(6);
        else if (level_select.gameObject.tag == "level6")
            SceneManager.LoadScene(7);
        else if (level_select.gameObject.tag == "level7")
            SceneManager.LoadScene(8);
        else if (level_select.gameObject.tag == "level8")
            SceneManager.LoadScene(9);
        else if (level_select.gameObject.tag == "level9")
            SceneManager.LoadScene(10);
        else
            SceneManager.LoadScene(11);
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
}
