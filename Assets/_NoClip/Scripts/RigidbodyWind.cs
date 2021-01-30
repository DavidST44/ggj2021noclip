using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RigidbodyWind : MonoBehaviour
{
    public List<Rigidbody> _rbs;
    public float _forceScalar;
    public float _radius;
    public WindZone _windZone;
    public SphereCollider _sphereCollider;
    private void Awake()
    {
        _rbs = new List<Rigidbody>();
        _windZone = GetComponent<WindZone>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _rbs.Add(other.GetComponent<Rigidbody>());    
    }

    private void OnTriggerExit(Collider other)
    {
        _rbs.Remove(other.GetComponent<Rigidbody>());
    }

    private void Update()
    {
        foreach (Rigidbody rb in _rbs)
        {
            var forceDir = rb.transform.position - transform.position;
            rb.AddForce(forceDir * _forceScalar);
        }
    }

    private void OnValidate()
    {
        _windZone = GetComponent<WindZone>();
        _sphereCollider = GetComponent<SphereCollider>();
        _windZone.radius = _radius;
        _sphereCollider.radius = _radius;
        transform.localScale = Vector3.one;
    }
}
