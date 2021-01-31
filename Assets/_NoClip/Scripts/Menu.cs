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
        Debug.Log("Quit Pressed");
    }
    public void OnMenuButtonPressed(GameObject go)
    {
        go.SetActive(true);
        AudioManager.Instance.menuPopupMusic.audioSource.Play();
        AudioManager.Instance.menuMusic.audioSource.Pause();
    }
    public void OnClosePopup(GameObject go)
    {
        go.SetActive(false);
        AudioManager.Instance.menuPopupMusic.audioSource.Pause();
        AudioManager.Instance.menuMusic.audioSource.Play();
    }
}
