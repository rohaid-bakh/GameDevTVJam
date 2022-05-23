using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
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
    [Range(20, 30)]
    private float speed = 20f;
    [SerializeField]
    [Range(1f, 10f)]
    private float linearDrag = 6f;

    [Header("Jump")]
    [SerializeField]
    [Range(3, 10)]
    private float jumpSpeed = 10f;
    private float gravity = 1f;
    private float gravityScale = 1f;
    private float globalGravity = -9.81f;
    public float fallMultiplier = 2f;

    [Header("State")]
    [SerializeField]
    private States state;

    private void Awake()
    {
        sprite = transform.Find("Visual").GetComponent<SpriteRenderer>();  //Moved visual to a child object
        cont = new Controller();
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        gravityScale = 1f;

        turnOnGeneral();
        turnOnState(state.state);
    }
    public void turnOnGeneral(){
        cont.Enable();
        cont.General.Enable();

        cont.General.Movement.Enable();
        cont.General.Movement.performed += x => move = x.ReadValue<Vector2>();
        cont.General.Movement.canceled += x => move = x.ReadValue<Vector2>();

        cont.General.Jump.Enable();
        cont.General.Jump.performed += _ => Jump();

    }

    public void turnOffState(PLAYERSTATES state){
        switch(state)
        {
            case PLAYERSTATES.Vampire:
                cont.Vampire.Attack.performed -= _ => GetComponent<Shoot>().ShootProjectile();
                cont.Vampire.Attack.Disable();
                cont.Vampire.Disable();
                break;
            case PLAYERSTATES.Chicken:
                cont.Chicken.Fly.Disable();
                cont.Chicken.Disable();
                break;
            case PLAYERSTATES.Sheep:
                cont.Sheep.Eat.Disable();
                cont.Sheep.Disable();
                break;
            case PLAYERSTATES.Cat:
                cont.Cat.Scratch.Disable();
                cont.Cat.Disable();
                break;
            default:
                break;

        }

    }

    public void turnOffState(){ // turn off state of the controller 
        turnOffState(state.state);
    }

    public void turnOnState(PLAYERSTATES state){
        switch (state)
        {
            case PLAYERSTATES.Vampire:
                cont.Vampire.Enable();
                cont.Vampire.Attack.Enable();
                cont.Vampire.Attack.performed += _ => GetComponent<Shoot>().ShootProjectile();
                break;
            case PLAYERSTATES.Chicken:
                cont.Chicken.Enable();
                cont.Chicken.Fly.Enable();
                break;
            case PLAYERSTATES.Sheep:
                cont.Sheep.Enable();
                cont.Sheep.Eat.Enable();
                break;
            case PLAYERSTATES.Cat:
                cont.Cat.Enable();
                cont.Cat.Scratch.Enable();
                break;
            default:
                break;
        }
    }
   
    public void setState(States newState){
        state = newState;
    }

    private void OnEnable()
    {
        cont.Enable();
        cont.General.Enable();
        cont.General.Movement.Enable();
        cont.General.Jump.Enable();
        turnOnState(state.state);
    }

    private void OnDisable()
    {
        cont.Disable();
        cont.General.Disable();
        cont.General.Movement.Disable();
        cont.General.Jump.Disable();
        turnOffState(state.state);
    }

    private void FixedUpdate()
    {
        Gravity();
        float distanceToGround = sprite.bounds.size.y * .5f;

        if (!onGround())
        {
            modifyFall();
        }
        else
        {
            modifyWalk();
        };

        Move();
        Flip();
    }

    private void Gravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rigid.AddForce(gravity, ForceMode.Acceleration);
    }

    private bool onGround()
    {
        float distanceToGround = sprite.bounds.size.y * .5f;
        return Physics.Raycast(GroundCheck.position, Vector3.down, distanceToGround, ground);
    }

    private void Move()
    {
        Vector3 force = new Vector3(move.x * state.speed, 0f, 0f);
        rigid.AddForce(force);
    }

    private void Jump()
    {
        if (onGround())
        {
            rigid.velocity = new Vector3(rigid.velocity.x, 0f, 0f); // TODO: Make this snappier
            rigid.AddForce(Vector3.up * state.jumpSpeed, ForceMode.Impulse);
        }
    }

    //UNCOMMENT FOR DEBUGGING
    // void OnDrawGizmos()
    // {       
    //         Gizmos.color = Color.blue;
    //         Gizmos.DrawWireSphere(GroundCheck.position, distanceToGround);
    // }

    private void modifyFall()
    {
        gravityScale = state.gravity;
        rigid.drag = state.linearDrag * .15f;

        if (rigid.velocity.y < 0)
        {
            gravityScale = state.gravity * state.fallMultiplier; // Increase gravity when falling to accelerate
        }
        else if (rigid.velocity.y > 0 && !cont.General.Jump.inProgress)
        {
            gravityScale = state.gravity * (state.fallMultiplier * .5f); // Decrease gravity when jumping to spend more time going up
        }
    }

    private void modifyWalk()
    {
        bool changingDirection = (move.x > 0f && rigid.velocity.x < 0f) || (move.x < 0f && rigid.velocity.x > 0f); // check if direction changes
        if (Mathf.Abs(move.x) < 0.4f || changingDirection)
        { //check if barely moving
            rigid.drag = state.linearDrag;
        }
        else
        {
            rigid.drag = 0f;
        }
        gravityScale = 0f;
    }


    //Added flipping object
    void Flip()
    {
        //bool playerHasHorizontalSpeed = Mathf.Abs(rigid.velocity.x) > Mathf.Epsilon;

        //if (playerHasHorizontalSpeed)
        //{
        //    transform.localScale = new Vector2(Mathf.Sign(rigid.velocity.x), 1f);
        //}

        if (move.x != 0)
        {
            Vector3 facing = transform.localEulerAngles;
            facing.y = move.x > 0 ? 0 : 180;
            transform.localEulerAngles = facing;
        }
    }
}
