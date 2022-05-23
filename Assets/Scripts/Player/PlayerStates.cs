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

    private SpriteRenderer playerRenderer;
    private BoxCollider playerCollider;
    // Next 2 Vars were added.
    // 0 : Vampire , 1: Chicken, 2: Sheep, 3: Cat
    [SerializeField] private States[] allStates;
    private PlayerController controller;

    void Awake()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider>();
        controller = GetComponent<PlayerController>();  // Added to change state Automatically
    }

    // Commented out because the game uses the new input system  so these no longer work.
    // void Update()
    // {

    //     if (Input.GetKeyDown(KeyCode.V))
    //     {
    //         SwitchState(PLAYERSTATES.Vampire);
    //     }
    //     if (Input.GetKeyDown(KeyCode.C))
    //     {
    //         SwitchState(PLAYERSTATES.Chicken);
    //     }
    //     if (Input.GetKeyDown(KeyCode.S))
    //     {
    //         SwitchState(PLAYERSTATES.Sheep);
    //     }
    // }

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
                controller.turnOnState(PLAYERSTATES.Vampire);
                controller.setState(allStates[0]);
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;
                controller.turnOnState(PLAYERSTATES.Chicken);
                controller.setState(allStates[1]);
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;
                controller.turnOnState(PLAYERSTATES.Sheep);
                controller.setState(allStates[2]);
                break;
            case PLAYERSTATES.Cat:
                playerRenderer.sprite = catSprite;
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
                controller.turnOnState(PLAYERSTATES.Vampire);
                controller.setState(allStates[0]);
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;
                controller.turnOnState(PLAYERSTATES.Chicken);
                controller.setState(allStates[1]);
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;
                controller.turnOnState(PLAYERSTATES.Sheep);
                controller.setState(allStates[2]);
                break;
            case PLAYERSTATES.Cat:
                playerRenderer.sprite = catSprite;
                controller.turnOnState(PLAYERSTATES.Cat);
                controller.setState(allStates[3]);
                break;
            default:
                break;
        }

        // ResizeCollider();
    }

    //COMMENTED OUT BECAUSE SIZE CAN BE NEGATIVE DUE TO THE NEGATIVE SCALE
    //Leading to really weird bugs

    //Resizes the collider to match the sprite
    // void ResizeCollider()
    // {
    //     playerCollider.size = new Vector3(playerRenderer.bounds.size.x / transform.lossyScale.x,
    //                                       playerRenderer.bounds.size.y / transform.lossyScale.y,
    //                                       playerRenderer.bounds.size.z / transform.lossyScale.z);
    // }
}
