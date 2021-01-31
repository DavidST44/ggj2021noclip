using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelTrigger : MonoBehaviour
{
    public string sceneToLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    private new Collider collider;
    public Collider Collider => collider != null ? collider : (collider = GetComponent<Collider>());

    private void OnDrawGizmos()
    {
        if (!Collider)
            return;
        Gizmos.color = (Color.cyan).WithAlpha(0.1f);
        Gizmos.DrawCube(Collider.bounds.center, Collider.bounds.size);
    }
}
