using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerClipController playerClipController;

    public float maxHealth = 100.0f;
    private float health;
    public float restoreRate = 20.0f;
    public float decayRate = 5.0f;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (playerClipController.NoClip)
        {
            health -= Time.deltaTime * decayRate;
            if(health <= 0f)
            {
                health = 0f;
            }
        }
        else if (health < maxHealth)
        {
            health += Time.deltaTime * restoreRate;
        }
        else
        {
            health = maxHealth;
        }
    }
}
