using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementChange : MonoBehaviour
{
    public PlayerCharacterController standard;
    public PlayerCharacterNoClip noClip;
    public CharacterController characterController;
    public bool standardMovement = true;

    void Update()
    {
        standard.enabled = standardMovement;
        noClip.enabled = !standardMovement;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnterNoClip"))
        {
            standardMovement = false;
            gameObject.layer = LayerMask.NameToLayer("NoClip");
        }
        else if (other.CompareTag("ExitNoClip"))
        {
            standardMovement = true;
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
