using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, transform.forward * 2f);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up * 2f);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
