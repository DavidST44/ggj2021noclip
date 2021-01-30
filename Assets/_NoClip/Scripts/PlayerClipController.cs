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
                gameObject.layer = LayerMask.NameToLayer(value ? "NoClip" : "Default");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ClippingVolume"))
        {
            NoClip = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ClippingVolume"))
        {
            NoClip = true;
        }
    }
}
