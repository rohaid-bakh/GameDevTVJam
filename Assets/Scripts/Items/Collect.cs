using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    [SerializeField]
    private ItemCount count;
    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            count.Add(); // ADDS count in seperate script. this is just for if we want to do something fancy when the itemCount is finished.
            Destroy(gameObject);
        }
    }
}
