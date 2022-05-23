using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    public bool facingRight = true;
    public bool FacingRight { get { return facingRight; } private set { facingRight = value; } }

    private Rigidbody myRigidbody;
    private Shoot shoot;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        shoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shoot.PlayerInRange)
        {
            return;
        }

        myRigidbody.velocity = new Vector3(moveSpeed, 0f, 0f);
    }

    void OnTriggerExit(Collider other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemy();
    }

    public void FlipEnemy()
    {
        //facingRight = !facingRight;
        //Vector3 tmpScale = transform.localScale;
        //tmpScale.x *= -1;
        //transform.localScale = tmpScale;
        
        //Changed to rotating object instead scale
        facingRight = !facingRight;
        Vector3 facing = transform.localEulerAngles;
        facing.y = facingRight ? 0 : -180;
        transform.localEulerAngles = facing;
    }
}
