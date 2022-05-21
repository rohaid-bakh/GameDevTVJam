using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYERSTATES { Vampire, Chicken, Sheep }

public class PlayerStates : MonoBehaviour
{
    //This is the same as using a private var and public getter but in 1 line.
    [field: Header("State")]
    [field: SerializeField] public PLAYERSTATES CurrentState { get; private set; }

    [Header("Sprites")]
    [SerializeField] private Sprite vampireSprite;
    [SerializeField] private Sprite chickenSprite;
    [SerializeField] private Sprite sheepSprite;

    private SpriteRenderer playerRenderer;
    private BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Temp inputs for testing, remove later
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwitchState(PLAYERSTATES.Vampire);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchState(PLAYERSTATES.Chicken);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchState(PLAYERSTATES.Sheep);
        }
    }

    //Call this method from other scripts to switch state randomly
    public void SwitchState()
    {
        //Change to a random state
        CurrentState = (PLAYERSTATES)Random.Range(0, System.Enum.GetValues(typeof(PLAYERSTATES)).Length);

        switch (CurrentState)
        {
            case PLAYERSTATES.Vampire:
                playerRenderer.sprite = vampireSprite;
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;
                break;
            default:
                break;
        }

        ResizeCollider();
    }

    //Call this method from other scripts to switch state, this overload is if we want to force a state
    public void SwitchState(PLAYERSTATES state)
    {
        //var rand
        CurrentState = state;

        switch (CurrentState)
        {
            case PLAYERSTATES.Vampire:
                playerRenderer.sprite = vampireSprite;
                break;
            case PLAYERSTATES.Chicken:
                playerRenderer.sprite = chickenSprite;
                break;
            case PLAYERSTATES.Sheep:
                playerRenderer.sprite = sheepSprite;
                break;
            default:
                break;
        }

        ResizeCollider();
    }

    //Resizes the collider to match the sprite
    void ResizeCollider()
    {
        playerCollider.offset = new Vector2(0, 0);
        playerCollider.size = new Vector3(playerRenderer.bounds.size.x / transform.lossyScale.x,
                                          playerRenderer.bounds.size.y / transform.lossyScale.y,
                                          playerRenderer.bounds.size.z / transform.lossyScale.z);
    }
}
