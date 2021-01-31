using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.menuMusic.audioSource.Play();
    }

    public void Play() 
    {
        SceneManager.LoadScene("level1");
        AudioManager.Instance.menuMusic.audioSource.Pause();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
