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
            SwitchState(PLAYERSTATES.Chicken);
        }
    }

    //Call this method from other scripts to switch state randomly
    public void SwitchState() 
    {
        //Change to a random state
        CurrentState = (PLAYERSTATES)Random.Range(0, System.Enum.GetValues(typeof(PLAYERSTATES)).Length);
        controller.turnOffState(); // turn off current state / controls
        
        switch (CurrentState)
        {
            case PLAYERSTATES.Vampire:
                playerRenderer.sprite = vampireSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToVampire");
                }
                controller.turnOnState(PLAYERSTATES.Vampire);
                controller.setState(allStates[0]);
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToChicken");
                }
                controller.turnOnState(PLAYERSTATES.Chicken);
                controller.setState(allStates[1]);
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;

                if (animator != null)
                {
                    //animator.SetTrigger("changeToSheep");
                }
                controller.turnOnState(PLAYERSTATES.Sheep);
                controller.setState(allStates[2]);
                break;
            case PLAYERSTATES.Cat:
                playerRenderer.sprite = catSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToCat");
                }
                controller.turnOnState(PLAYERSTATES.Cat);
                controller.setState(allStates[3]);
                break;
            default:
                break;
        }

        ResizeCollider();
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
                controller.turnOnState(PLAYERSTATES.Vampire);
                controller.setState(allStates[0]);
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToChicken");
                }
                controller.turnOnState(PLAYERSTATES.Chicken);
                controller.setState(allStates[1]);
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;

                if (animator != null)
                {
                    //animator.SetTrigger("changeToSheep");
                }
                controller.turnOnState(PLAYERSTATES.Sheep);
                controller.setState(allStates[2]);
                break;
            case PLAYERSTATES.Cat:
                playerRenderer.sprite = catSprite;

                if (animator != null)
                {
                    animator.SetTrigger("changeToCat");
                }
                controller.turnOnState(PLAYERSTATES.Cat);
                controller.setState(allStates[3]);
                break;
            default:
                break;
        }

        ResizeCollider();
    }

    //Resizes the collider to match the object
     void ResizeCollider()
    {
        playerCollider.size = new Vector3(playerRenderer.bounds.size.x / transform.lossyScale.x,
                                          playerRenderer.bounds.size.y / transform.lossyScale.y,
                                          playerRenderer.bounds.size.z / transform.lossyScale.z);
    }
}
