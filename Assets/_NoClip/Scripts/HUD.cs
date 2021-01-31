using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public CanvasGroup m_DeathSpalshCanvasGroup;

    private PlayerControllerClip m_playerControllerClip;
    // Start is called before the first frame update
    private void Awake()
    {
        HideDeathSplash();
    }

    private void Update()
    {
        if (!m_playerControllerClip)
        {
            return;
        }

        if (m_playerControllerClip.IsAlive())
        {
            HideDeathSplash();
        }
        else
        {
            ShowDeathSplash();
        }
    }

    void ShowDeathSplash()
    {
        m_DeathSpalshCanvasGroup.alpha = 1;
    }

    void HideDeathSplash()
    {
        m_DeathSpalshCanvasGroup.alpha = 0;
    }

    public void OnRespawnButtonPressed()
    {
        m_playerControllerClip.Respawn();
    }
}
