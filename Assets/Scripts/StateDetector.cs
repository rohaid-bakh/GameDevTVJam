using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDetector : MonoBehaviour
{
    [SerializeField] private PLAYERSTATES requiredStateToEnter;

    //The collider we need to turn off so the player can go through
    [SerializeField] private Collider roomCollider;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStates playerStates = other.GetComponent<PlayerStates>();

            if (playerStates != null)
            {
                if (playerStates.CurrentState == requiredStateToEnter)
                {
                    roomCollider.enabled = false;
                    Debug.Log("Door Opened!");
                }
                else
                {
                    Debug.Log("Incorrect State: Door remaining closed");
                }
            }
        }
    }
}
