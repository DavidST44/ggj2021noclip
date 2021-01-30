using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private enum State { Alive, Dead }

    public PlayerClipController playerClipController;
    public RectTransform healthBar;
    public Transform respawnTransform;

    private State state = State.Alive;
    public float maxHealth = 100.0f;
    private float health;
    public float restoreRate = 20.0f;
    public float decayRate = 5.0f;

    private void Start()
    {
        health = maxHealth;
    }

    private void LateUpdate()
    {
        if (state == State.Alive)
        {
            if (playerClipController.NoClip)
            {
                health -= Time.deltaTime * decayRate;
                if (health <= 0f)
                {
                    health = 0f;
                    SetState(State.Dead);
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

            Vector3 scale = healthBar.localScale;
            scale.x = health / maxHealth;
            healthBar.localScale = scale;
        }
    }

    private void SetState(State state)
    {
        this.state = state;
        switch (state)
        {
            case State.Alive:
                break;

            case State.Dead:
                Respawn();
                break;
        }
    }

    void Respawn()
    {
        playerClipController.noClipMovement.enabled = false;
        transform.position = respawnTransform.position;
        transform.rotation = respawnTransform.rotation;
        health = maxHealth;
        SetState(State.Alive);
    }
}
