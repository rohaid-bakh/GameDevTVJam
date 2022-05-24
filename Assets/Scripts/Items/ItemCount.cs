using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCount : MonoBehaviour
{
    private float count = 0;
    private float maxCount;

    // private LevelExit exit; // uncomment when scenes merge. this is so that the exit is acessible when all items are there
    private void Awake(){
        maxCount = transform.childCount;
        // exit.enabled = false;
        // exit = FindObjectOfType<LevelExit>();
        
    }
    public void Add(){
        count++;
        if(count == maxCount){ // put in Other Things
            Debug.Log("Collected all the items");
            // exit.enabled = true;

        }
    }
}
