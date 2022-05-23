using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlayerState", menuName = "GameDevTVJam/PlayerState", order = 0)]
public class States : ScriptableObject {
    [Header("State")]
    public PLAYERSTATES state;
    [Header("Ground")]
    public float speed;
    public float linearDrag;
    [Header("Jump")]
    public float jumpSpeed;
    public float gravity;
    public float fallMultiplier;
    
}

