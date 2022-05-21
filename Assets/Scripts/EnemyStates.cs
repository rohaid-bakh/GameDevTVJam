using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    public enum ENEMYSTATES { Normal, Enraged}
    //This is the same as using a private var and public getter but in 1 line.
    [field: Header("State")]
    [field: SerializeField] public ENEMYSTATES CurrentState;

    [Header("Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite enragedSprite;

    private SpriteRenderer enemyRenderer;
    private BoxCollider2D enemyCollider;

    // Start is called before the first frame update
    void Start()
    {
        enemyRenderer = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Temp inputs for testing, remove later
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchState(ENEMYSTATES.Normal);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchState(ENEMYSTATES.Enraged);
        }
    }

    //Call this method from other scripts to switch state
    public void SwitchState(ENEMYSTATES state)
    {
        CurrentState = state;

        switch (CurrentState)
        {
            case ENEMYSTATES.Normal:
                enemyRenderer.sprite = normalSprite;
                break;
            case ENEMYSTATES.Enraged:
                enemyRenderer.sprite = enragedSprite;

                //TODO: Increase enemy damage?
                break;
            default:
                break;
        }

        ResizeCollider();
    }

    void ResizeCollider()
    {
        enemyCollider.offset = new Vector2(0, 0);
        enemyCollider.size = new Vector3(enemyRenderer.bounds.size.x / transform.lossyScale.x,
                                         enemyRenderer.bounds.size.y / transform.lossyScale.y,
                                         enemyRenderer.bounds.size.z / transform.lossyScale.z);
    }
}
