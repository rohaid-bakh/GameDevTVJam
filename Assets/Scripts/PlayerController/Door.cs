using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: BIG ISSUE
// TELEPORTATION WORKS AS INTENDED BUT THE COMPUTER CAN'T TELL WHEN TO STOP. FIGURE IN THE MORNING
public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform pairDoor;
    private Controller cont; //  have it so if the player presses down and they're in the trigger, they go in.

    void Awake(){
        cont = new Controller();
        cont.Enable();
        cont.General.Enable();
        cont.General.Door.Enable();
    }

    void OnEnable(){
        cont.Enable();
        cont.General.Enable();
        cont.General.Door.Enable();
    }

    void OnDisable(){
        cont.General.Door.Disable();
        cont.General.Disable();
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && cont.General.Door.IsPressed()){ // Should only run when the player is in front 
            Vector3 newPosition = new Vector3(pairDoor.position.x , pairDoor.position.y , other.transform.position.z);
            other.GetComponent<Rigidbody>().position = newPosition;
        }
    }
}
