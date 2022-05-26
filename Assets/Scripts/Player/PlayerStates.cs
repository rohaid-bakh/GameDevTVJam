using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERSTATES { Vampire, Chicken, Sheep, Cat }

public class PlayerStates : MonoBehaviour
{
    //This is the same as using a private var and public getter but in 1 line.
    [field: Header("State")]
    [field: SerializeField] public PLAYERSTATES CurrentState { get; private set; }

    [Header("Sprites")]
    [SerializeField] private Sprite vampireSprite;
    [SerializeField] private Sprite chickenSprite;
    [SerializeField] private Sprite sheepSprite;
    [SerializeField] private Sprite catSprite;

    // Next 2 Vars were added.
    // 0 : Vampire , 1: Chicken, 2: Sheep, 3: Cat
    [SerializeField] private States[] allStates;
    
    private PlayerController controller;
    private Animator animator;
    private SpriteRenderer playerRenderer;
    private BoxCollider playerCollider;

    void Awake()
    {
        playerRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider>();
        controller = GetComponent<PlayerController>();  // Added to change state Automatically
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchState(PLAYERSTATES.Sheep);
        }
    }

    //Call this method from other scripts to switch state randomly
    public void SwitchState() 
    {
        //Change to a random state
        PLAYERSTATES prevState = CurrentState;
        while(CurrentState == prevState){ // make sure to change the state randomly
        CurrentState = (PLAYERSTATES)Random.Range(0, System.Enum.GetValues(typeof(PLAYERSTATES)).Length);
        }
        controller.turnOffState(); // turn off current state / controls
        
        switch (CurrentState)
        {
            case PLAYERSTATES.Vampire:
                playerRenderer.sprite = vampireSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToVampire");
                }
                playerCollider.center = new Vector3(-0.0007758141f,-0.01304388f, 0f );
                playerCollider.size = new Vector3(1.001552f,1.917335f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Vampire);
                controller.setState(allStates[0]);
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToChicken");
                }
                playerCollider.center = new Vector3(0.03322887f,0.02542782f, 0f );
                playerCollider.size = new Vector3(1.066458f,0.9028816f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Chicken);
                controller.setState(allStates[1]);
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToSheep");
                }
                playerCollider.center = new Vector3(-0.0007758141f,-0.01675606f, 0f );
                playerCollider.size = new Vector3(1.001552f,0.9812298f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Sheep);
                controller.setState(allStates[2]);
                break;
            case PLAYERSTATES.Cat:
                playerRenderer.sprite = catSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToCat");
                }
                playerCollider.center = new Vector3(-0.03850317f,-0.01675606f, 0f );
                playerCollider.size = new Vector3(1.077006f,0.9812298f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Cat);
                controller.setState(allStates[3]);
                break;
            default:
                break;
        }

        // ResizeCollider();
    }

    //Call this method from other scripts to switch state, this overload is if we want to force a state
    public void SwitchState(PLAYERSTATES state) 
    {
        CurrentState = state;
        controller.turnOffState(); // turn off current state / controls

        switch (CurrentState)
        {
            case PLAYERSTATES.Vampire:
                playerRenderer.sprite = vampireSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToVampire");
                }
                playerCollider.center = new Vector3(-0.0007758141f,-0.01304388f, 0f );
                playerCollider.size = new Vector3(1.001552f,1.917335f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Vampire);
                controller.setState(allStates[0]);
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToChicken");
                }
                playerCollider.center = new Vector3(0.03322887f,0.02542782f, 0f );
                playerCollider.size = new Vector3(1.066458f,0.9028816f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Chicken);
                controller.setState(allStates[1]);
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToSheep");
                }
                playerCollider.center = new Vector3(-0.0007758141f,-0.01675606f, 0f );
                playerCollider.size = new Vector3(1.001552f,0.9812298f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Sheep);
                controller.setState(allStates[2]);
                break;
            case PLAYERSTATES.Cat:
                playerRenderer.sprite = catSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToCat");
                }
                playerCollider.center = new Vector3(-0.03850317f,-0.01675606f, 0f );
                playerCollider.size = new Vector3(1.077006f,0.9812298f, 0.2f);
                controller.turnOnState(PLAYERSTATES.Cat);
                controller.setState(allStates[3]);
                break;
            default:
                break;
        }

        // ResizeCollider();
    }

    //Resizes the collider to match the object
     void ResizeCollider()
    {
        playerCollider.size = new Vector3(playerRenderer.bounds.size.x / transform.lossyScale.x,
                                          playerRenderer.bounds.size.y / transform.lossyScale.y,
                                          playerRenderer.bounds.size.z / transform.lossyScale.z);
    }
}
