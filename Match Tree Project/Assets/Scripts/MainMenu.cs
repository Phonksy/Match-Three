using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button level_select;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public static int previousScreenIndex = -1;

    public GameObject QuestionCanvas;

    public Achievements ach;

    public static int level = -1;

    public void PressedYes() 
    {
        int[] a = ach.GetAchieved();

        SceneManager.LoadScene(level+2);
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
        int[] a = ach.GetAchieved();

        int screenIndex = 0;
/* day and night
[Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLength;
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    [Header("Sun")]
    public Light sun;
    public Gradient sunColor;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColor;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionIntensityMultiplier;

    private float particleEmissionMin = 10.0f;
    private float particleEmissionMax = 150.0f;

    [SerializeField]
    private ParticleSystem fire;
    private ParticleSystem.EmissionModule fireEmission;

    [SerializeField]
    private ParticleSystem smoke;
    private ParticleSystem.EmissionModule smokeEmission;

    [SerializeField]
    private ParticleSystem rain;
    private ParticleSystem.EmissionModule rainEmission;


    private void Start()
    {
        timeRate = 1.0f / fullDayLength;
        time = startTime;
        fireEmission = fire.emission;
        smokeEmission = smoke.emission;
        rainEmission = rain.emission;
    }

    private void Update()
    {
        time += timeRate * Time.deltaTime;
        if (time >= 1.0f)
            time = 0.0f;

        sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f;
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;

        if (sun.intensity == 0 && sun.gameObject.activeInHierarchy)
            sun.gameObject.SetActive(false);
        else if(sun.intensity > 0 && !sun.gameObject.activeInHierarchy)
            sun.gameObject.SetActive(true);

        if (moon.intensity == 0 && moon.gameObject.activeInHierarchy)
            moon.gameObject.SetActive(false);
        else if (moon.intensity > 0 && !moon.gameObject.activeInHierarchy)
            moon.gameObject.SetActive(true);

        if (time > 0.0f && time < 0.5f)
        {
            fireEmission.rateOverTime = Mathf.Lerp(particleEmissionMin, particleEmissionMax, time / 0.5f);
            smokeEmission.rateOverTime = Mathf.Lerp(particleEmissionMin, particleEmissionMax, time / 0.5f);
        }
        else
        {
            fireEmission.rateOverTime = Mathf.Lerp(particleEmissionMax, particleEmissionMin, time / 0.75f);
            smokeEmission.rateOverTime = Mathf.Lerp(particleEmissionMax, particleEmissionMin, time / 0.75f);
        }

        if (time > 0.75f && time < 0.875f)
        {
            rainEmission.rateOverTime = Mathf.Lerp(particleEmissionMin, particleEmissionMax, time / 0.875f);
        }
        if (time > 0.875f && time < 1f)
        {
            rainEmission.rateOverTime = Mathf.Lerp(particleEmissionMax, particleEmissionMin, time / 1f);
        }

        if (time > 0.0f && time < 0.75f)
        {
            if (!fire.isPlaying)
                fire.Play();
            if (!smoke.isPlaying)
                smoke.Play();
            if (rain.isPlaying)
                rain.Stop();
        }
        else
        {
            if (!rain.isPlaying)
                rain.Play();
            if (fire.isPlaying)
                fire.Stop();
            if (smoke.isPlaying)
                smoke.Stop();
        }
    }
*/
        if (level_select.gameObject.tag == "level1")
        {
            if (a[0] == 0)
            {
                SceneManager.LoadScene(2);
                screenIndex = 2;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 0;
            }
        }
        else if (level_select.gameObject.tag == "level2")
        {
            if (a[1] == 0)
            {
                SceneManager.LoadScene(3);
                screenIndex = 3;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 1;
            }
        }
        else if (level_select.gameObject.tag == "level3")
        {
            if (a[2] == 0)
            {
                SceneManager.LoadScene(4);
                screenIndex = 4;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 2;
            }
        }
        else if (level_select.gameObject.tag == "level4")
        {
            if (a[3] == 0)
            {
                SceneManager.LoadScene(5);
                screenIndex = 5;
            }

            else
            {
                level = 3;
                QuestionCanvas.SetActive(true);
            }
        }
        else if (level_select.gameObject.tag == "level5")
        {
            if (a[4] == 0)
            {
                SceneManager.LoadScene(6);
                screenIndex = 6;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 4;
            }
        }
        else if (level_select.gameObject.tag == "level6")
        {
            if (a[5] == 0)
            {
                SceneManager.LoadScene(7);
                screenIndex = 7;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 5;
            }
        }
        else if (level_select.gameObject.tag == "level7")
        {
            if (a[6] == 0)
            {
                SceneManager.LoadScene(8);
                screenIndex = 8;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 6;
            }
        }
        else if (level_select.gameObject.tag == "level8")
        {
            if (a[7] == 0)
            {
                SceneManager.LoadScene(9);
                screenIndex = 9;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 7;
            }
        }
        else if (level_select.gameObject.tag == "level9")
        {
            if (a[8] == 0)
            {
                SceneManager.LoadScene(10);
                screenIndex = 10;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 8;
            }
        }
        else
        {
            if (a[9] == 0)
            {
                SceneManager.LoadScene(11);
                screenIndex = 11;
            }

            else
            {
                QuestionCanvas.SetActive(true);
                level = 9;
            }
        }
        previousScreenIndex = screenIndex;
    }
//pogstickobstacles
//[SerializeField]
   // private List<GameObject> obstacles;

   // [Min(0f)]
  //  [SerializeField]
  //  private int count = 6;

  //  [SerializeField]
  //  private Vector3 size = new Vector3(1f, 0f, 10f);


   // private void OnDrawGizmos()
  //  {
  //      Gizmos.DrawWireCube(transform.position, size);
  //  }
  //  private void Start()
  //  {
  //      CreateObstacles();
 //   }

  //  private void CreateObstacles()
  //  {
  //      for (var i = 0; i < count; i++)
  //      {
  //          foreach(var obstacle in obstacles)
   //         {
   //             Instantiate(obstacle, GetRandomPosition(), 
   //                 obstacle.transform.rotation, gameObject.transform);
   //         }
   //     }
  //  }

  //  private Vector3 GetRandomPosition()
  //  {
  //      var volumePosition = new Vector3(
  //              Random.Range(0, size.x),
   //             Random.Range(0, size.y),
   //             Random.Range(0, size.z)
   //         );
   //     return transform.position + volumePosition - size / 2;
  //  }
//
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
