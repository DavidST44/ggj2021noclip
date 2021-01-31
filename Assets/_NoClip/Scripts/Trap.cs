using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage = 100f;
    public bool destroySelf = true;
    private void Update()
    {
        transform.localEulerAngles = new Vector3(Mathf.Sin(Time.time * 1f) * 360f, Mathf.Cos(Time.time * 1f) * 720f, Mathf.Sin(Time.time * 1f) * -720f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var v = other.GetComponent<PlayerHealth>();
            v.AddHealth(-damage);
            if(destroySelf)
                Destroy(gameObject);
        }
    }
}
