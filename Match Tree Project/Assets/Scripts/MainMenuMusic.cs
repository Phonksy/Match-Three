using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusic : MonoBehaviour
{
    private static MainMenuMusic instance;
    private AudioSource audioSource;
    private bool isMusicPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusic();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            if (isMusicPaused)
            {
                PauseMusic();
            }
            else
            {
                PlayMusic();
            }
        }
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            isMusicPaused = false;
        }
    }

    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
            isMusicPaused = true;
        }
    }

    public void UnpauseMusic()
    {
        if (audioSource != null && isMusicPaused)
        {
            audioSource.UnPause();
            isMusicPaused = false;
        }
    }
}
