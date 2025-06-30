using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BacksoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backsoundClip;

    void Start()
    {
        if (audioSource != null && backsoundClip != null)
        {
            audioSource.clip = backsoundClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopBacksound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

}

