using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingVolume : MonoBehaviour
{
    private new Collider collider;
    public Collider Collider => collider != null ? collider : (collider = GetComponent<Collider>());
    public bool noClip = true;
    public bool listenForExit = true;

    private void OnDrawGizmos()
    {
        if (!Collider)
            return;
        Gizmos.color = (noClip ? Color.red : Color.green).WithAlpha(0.1f);
        Gizmos.DrawCube(Collider.bounds.center, Collider.bounds.size);
    }
}
