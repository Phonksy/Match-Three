using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSFX : MonoBehaviour
{
    public AudioClip clickSFX;

    private static GameObject audioSourceObject;

    private static AudioSource audioSource;

    private void Awake()
    {
        if (audioSourceObject == null)
        {
            audioSourceObject = new GameObject("ClickSFX_AudioSource");
            audioSource = audioSourceObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(audioSourceObject);
        }
    }

    public void PlayClickSound()
    {
        if (clickSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSFX);
        }
    }
}