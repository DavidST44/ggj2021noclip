using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public int itemsRequired = 1;
    public MeshRenderer meshRenderer;
    static readonly int shaderID = Shader.PropertyToID("_Alpha");

    void Update()
    {
        if(PlayerHealth.itemsCollected >= itemsRequired)
        {
            if (meshRenderer.material.GetFloat(shaderID) > 0f)
            {
                meshRenderer.material.SetFloat(shaderID, meshRenderer.material.GetFloat(shaderID) - Time.deltaTime * 0.25f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
