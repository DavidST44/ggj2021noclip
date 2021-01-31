using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var v = other.GetComponent<PlayerHealth>();
            v.AddHealth(-1000);
            Destroy(gameObject);
        }

    }
}
