using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private new Collider collider;
    public Collider Collider => collider != null ? collider : (collider = GetComponent<Collider>());
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var v = other.GetComponent<PlayerHealth>();
            v.AddHealth(Mathf.NegativeInfinity);
        }
    }
    private void OnDrawGizmos()
    {
        if (!Collider)
            return;
        Gizmos.color = (Color.yellow).WithAlpha(0.1f);
        Gizmos.DrawCube(Collider.bounds.center, Collider.bounds.size);
    }
}
