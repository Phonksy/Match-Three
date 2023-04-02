using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    private static AudioSource audioSourceInstance;

    void Start()
    {
        if (audioSourceInstance == null)
        {
            audioSourceInstance = GetComponent<AudioSource>();
            audioSourceInstance.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
