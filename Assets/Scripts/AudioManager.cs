using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip gameIntroClip;
    public AudioClip backgroundMusicClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Play the game intro music
        audioSource.clip = gameIntroClip;
        audioSource.Play();

        // Wait for the game intro music to finish
        StartCoroutine(WaitForIntroToEnd());
    }

    private IEnumerator WaitForIntroToEnd()
    {
        yield return new WaitForSeconds(gameIntroClip.length);

        // Switch to the background music
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
