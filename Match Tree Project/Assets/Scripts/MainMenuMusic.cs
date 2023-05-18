using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private static AudioSource audioSourceInstance;

    void Start()
    {
        if (audioSourceInstance == null)
        {
            audioSourceInstance = GetComponent<AudioSource>();
            audioSourceInstance.Play();
            DontDestroyOnLoad(audioSourceInstance.gameObject);
        }
        else if (audioSourceInstance != null)
        {
            return;
        }
        else
        {
            Destroy(audioSourceInstance.gameObject);
        }
    }
}
