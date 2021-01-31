using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClipController : MonoBehaviour
{
    public PlayerControllerClip clipMovement;
    public PlayerControllerNoClip noClipMovement;

    private bool noClip;
    public bool NoClip
    {
        get
        {
            return noClip;
        }
        private set
        {
            if (value != noClip)
            {
                noClip = value;
                clipMovement.enabled = !value;
                noClipMovement.enabled = value;
                gameObject.layer = LayerMask.NameToLayer(value ? "NoClipObject" : "Player");
            }
        }
    }

    private void Update()
    {
        if (noClip)
        {
            var audio = AudioManager.Instance.voidAmbientSound;
            if (!audio.audioSource.isPlaying)
            {
                audio.audioSource.Play();
            }
            AudioManager.Instance.ambientPuzzleSound.audioSource.Pause();
        }
        else
        {
            var audio = AudioManager.Instance.ambientPuzzleSound;
            if (!audio.audioSource.isPlaying)
            {
                audio.audioSource.Play();
            }
            AudioManager.Instance.voidAmbientSound.audioSource.Pause();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ClippingVolume cv = other.GetComponent<ClippingVolume>();
        if (cv)
        {
            NoClip = cv.noClip;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ClippingVolume cv = other.GetComponent<ClippingVolume>();
        if (cv && cv.listenForExit)
        {
            NoClip = !cv.noClip;
        }
    }
}
