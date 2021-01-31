using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    private void Update()
    {
        if (audioSource.clip == null)
            return;

        if (!audioSource.loop)
        {
            if (Mathf.Approximately(audioSource.time, audioSource.clip.length))
            {
                Destroy(gameObject);
            }    
        }
    }
}
