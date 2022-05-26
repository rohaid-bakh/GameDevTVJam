using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: BIG ISSUE
// TELEPORTATION WORKS AS INTENDED BUT THE COMPUTER CAN'T TELL WHEN TO STOP. FIGURE IN THE MORNING
public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform pairDoor;
    private Door pairDoorScript;
    private bool canTeleport = true;
    private bool pressed = false;
    private Controller cont; //  have it so if the player presses down and they're in the trigger, they go in.


    // void OnTriggerEnter(Collider other) {
    //     Debug.Log("Trigger");
    //     if (other.tag == "Player" && pressed){ // Should only run when the player is in front 
    //     Debug.Log("At door");
    //     if(canTeleport){
    //         Vector3 newPosition = new Vector3(pairDoor.position.x , pairDoor.position.y , other.transform.position.z);
    //         other.GetComponent<Rigidbody>().position = newPosition;
    //         StartCoroutine(pairDoorScript.DoorWait());
            
    //     }
    //     }
    // }

    public void Teleport(GameObject other){
        if(canTeleport){
            Vector3 newPosition = new Vector3(pairDoor.position.x , pairDoor.position.y , other.transform.position.z);
            other.GetComponent<Rigidbody>().position = newPosition;
            StartCoroutine(pairDoorScript.DoorWait());
            
        }
    }
    public IEnumerator DoorWait(){
        canTeleport = false;
        yield return new WaitForSeconds(.2f);
        canTeleport = true;

    }
}
