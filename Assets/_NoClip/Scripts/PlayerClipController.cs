using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClipController : MonoBehaviour
{
    public PlayerControllerClip clipMovement;
    public PlayerControllerNoClip noClipMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ClippingVolume"))
        {
            clipMovement.enabled = true;
            noClipMovement.enabled = false;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ClippingVolume"))
        {
            clipMovement.enabled = false;
            noClipMovement.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("NoClip");
        }
    }
}
