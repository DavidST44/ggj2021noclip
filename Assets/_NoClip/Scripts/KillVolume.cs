using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var v = other.GetComponent<PlayerHealth>();
            v.AddHealth(Mathf.NegativeInfinity);
        }
    }
}
