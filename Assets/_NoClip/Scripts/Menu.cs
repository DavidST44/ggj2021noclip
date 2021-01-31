using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.menuSound.audioSource.Play();
    }

    public void Play() 
    {
        SceneManager.LoadScene("level1");
        AudioManager.Instance.menuSound.audioSource.Pause();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
