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
