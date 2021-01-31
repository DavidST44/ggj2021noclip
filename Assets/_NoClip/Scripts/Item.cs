using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Vector3 rot;
    private void Start()
    {
        rot = Random.onUnitSphere;
    }
    private void Update()
    {
        transform.Rotate(rot * Time.deltaTime * 30f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ++PlayerHealth.itemsCollected;
            Destroy(gameObject);
        }

    }
}
