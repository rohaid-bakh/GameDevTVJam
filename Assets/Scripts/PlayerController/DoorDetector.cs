using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetector : MonoBehaviour
{
    private Collider col;
    private Controller cont; //  have it so if the player presses down and they're in the trigger, they go in.
    [SerializeField] private GameObject player;

    void Awake(){
        col = GetComponent<BoxCollider>();
        cont = new Controller();
        cont.Enable();
        cont.General.Enable();
        cont.General.Door.Enable();
        cont.General.Door.performed += _ => col.enabled = true;
        cont.General.Door.canceled += _ => col.enabled = false;
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
    void OnTriggerEnter(Collider col){
        if(col.tag == "Door"){
           Door script = col.GetComponent<Door>();
            script.Teleport(player);
        }

    }

    IEnumerator pauseBuffer(Collider col){
        
        yield return new WaitForSeconds(2f);
        
        
    }
}
