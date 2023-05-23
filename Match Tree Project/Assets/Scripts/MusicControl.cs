using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameObject ObjectMusic;
    private AudioSource AudioSource;
    public GameObject sound_on;
    public GameObject sound_off;

    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        if (AudioSource.isPlaying)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true);
        }
        else
        {
            sound_on.SetActive(true);
            sound_off.SetActive(false);
        }
    }

    public void MuteMusic()
    {
        AudioSource.Pause();
    }

    public void UnmuteMusic()
    {
        AudioSource.UnPause();
    }
}
