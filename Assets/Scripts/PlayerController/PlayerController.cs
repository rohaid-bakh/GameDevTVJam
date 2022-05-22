using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // MAKE SCRIPTABLE OBJECTS FOR EACH STATE WITH ENUMS TO CONTROL SPEEDS AND MOVEMENT;
    // TODO: ADD IN INSTANT MOVEMENT WHEN LANDING ON THE FLOOR

    [Header("Controls")]
    private Controller cont;

    [Header("Ground")]
    [SerializeField]
    private Transform GroundCheck;
    [SerializeField]
    private LayerMask ground;
    private float distanceToGround = 0f;
    private SpriteRenderer sprite;

    [Header("Movement")]
    private Rigidbody rigid;
    private Vector2 move;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    [Range(20,30)]
    private float speed = 20f;
    [SerializeField]
    [Range(1f,10f)]
    private float linearDrag = 6f;

    [Header("Jump")]
    [SerializeField]
    [Range(3,10)]
    private float jumpSpeed = 10f;
    private float gravity = 1f;
    private float gravityScale = 1f;
    private float globalGravity = -9.81f;
    public float fallMultiplier = 2f;

    [Header("State")]
    private string state = "human";

    private void Awake(){
        sprite = GetComponent<SpriteRenderer>();
        cont = new Controller();
        rigid = GetComponent<Rigidbody>();

        linearDrag = 6f;
        rigid.useGravity = false;
        fallMultiplier = 5f;
        gravityScale = 1f;
        gravity = 1f;


        cont.Enable();

        if (state == "human"){ //TODO: CHANGE THIS TO ACCOMODATE DIFFERENT STATES
            cont.Human.Enable();
            cont.Human.Movement.Enable();
            cont.Human.Movement.performed += x => move = x.ReadValue<Vector2>();
            cont.Human.Movement.canceled += x => move = x.ReadValue<Vector2>();
            cont.Human.Jump.Enable();
            cont.Human.Jump.performed += _ => Jump();
            }
    }

    private void OnEnable(){
        cont.Enable();
        cont.Human.Enable();
        cont.Human.Movement.Enable();
        cont.Human.Jump.Enable();
    }

    private void OnDisable(){
        cont.Disable();
        cont.Human.Disable();
        cont.Human.Movement.Disable();
        cont.Human.Jump.Disable();
    }

    private void FixedUpdate()
    {
        Gravity();
        float distanceToGround = sprite.bounds.size.y * .5f;

        if(!onGround()){
            modifyFall();
        } else {
            modifyWalk();
        };

        Move();
        FlipSprite();
     }

    private void Gravity(){
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rigid.AddForce(gravity, ForceMode.Acceleration);
    }

    private bool onGround(){
        float distanceToGround = sprite.bounds.size.y * .5f;
        return Physics.Raycast(GroundCheck.position, Vector3.down, distanceToGround, ground);
    }

    private void Move(){
        Vector3 force = new Vector3(move.x * speed, 0f, 0f);
        rigid.AddForce(force);
    }

    private void Jump(){
        if(onGround()){
        rigid.velocity = new Vector3(rigid.velocity.x, 0f, 0f); // TODO: Make this snappier
        rigid.AddForce(Vector3.up * jumpSpeed , ForceMode.Impulse);
        }
    }

    //UNCOMMENT FOR DEBUGGING
    // void OnDrawGizmos()
    // {       
    //         Gizmos.color = Color.blue;
    //         Gizmos.DrawWireSphere(GroundCheck.position, distanceToGround);
    // }

    private void modifyFall(){
        gravityScale = gravity;
        rigid.drag = linearDrag *.15f;

        if(rigid.velocity.y < 0 ){
        gravityScale = gravity * fallMultiplier; // Increase gravity when falling to accelerate
        } else if (rigid.velocity.y > 0 && !cont.Human.Jump.inProgress){
            gravityScale = gravity * (fallMultiplier * .5f); // Decrease gravity when jumping to spend more time going up
        }
    }

    private void modifyWalk(){
        bool changingDirection = (move.x > 0f &&  rigid.velocity.x < 0f) || (move.x < 0f && rigid.velocity.x > 0f); // check if direction changes
        if(Mathf.Abs(move.x) < 0.4f || changingDirection){ //check if barely moving
            rigid.drag = linearDrag;
        } else {
            rigid.drag = 0f;
        }
        gravityScale = 0f;
    }

    //Added flipping sprites x scale
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rigid.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigid.velocity.x), 1f);
        }
    }
}
