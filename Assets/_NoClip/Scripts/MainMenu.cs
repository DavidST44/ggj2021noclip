using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonPressed()
    {
        GameObject.Destroy(gameObject);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
