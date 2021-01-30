using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingVolumeGizmo : MonoBehaviour
{
    public new Collider collider;
    private void Reset()
    {
        collider = GetComponent<Collider>();
    }
    private void OnDrawGizmos()
    {
        if (!collider)
            return;

        bool test = transform.CompareTag("NoClippingVolume");
        Gizmos.color = (test ? Color.red : Color.green).WithAlpha(0.1f);
        Gizmos.DrawCube(collider.bounds.center, collider.bounds.size);
    }
}
