using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private enum State { Alive, Dead }

    public PlayerClipController playerClipController;
    public Transform respawnTransform;

    private State state = State.Alive;
    public float maxHealth = 100.0f;
    private float health;
    public float restoreRate = 20.0f;
    public float decayRate = 5.0f;

    public static int itemsCollected = 0;
    

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (state == State.Alive)
        {
            if (playerClipController.NoClip)
            {
                AddHealth(-Time.deltaTime * decayRate);
            }
            else if (health < maxHealth)
            {
                AddHealth(Time.deltaTime * restoreRate);
            }
            else
            {
                health = maxHealth;
            }
        }
    }

    public void AddHealth(float value)
    {
        health += value;
        if (state == State.Alive)
        {
            if (health <= 0f)
            {
                health = 0f;
                SetState(State.Dead);
            }
        }
    }

    public float GetHealthNormalised()
    {
        return health / maxHealth;
    }

    private void SetState(State state)
    {
        this.state = state;
        switch (state)
        {
            case State.Alive:
                break;

            case State.Dead:
                var audio = AudioManager.Instance.AddController(AudioManager.Instance.death, false, 1);
                audio.audioSource.Play();
                Respawn();
                break;
        }
    }

    void Respawn()
    {
        playerClipController.noClipMovement.enabled = false;
        playerClipController.clipMovement.enabled = false;
        playerClipController.clipMovement.characterVelocity = Vector3.zero;
        transform.position = respawnTransform.position;
        transform.rotation = respawnTransform.rotation;
        health = maxHealth;
        SetState(State.Alive);
        Invoke("Foo", 0.1f);
    }

    void Foo()
    {
        playerClipController.clipMovement.enabled = true;
    }
}
