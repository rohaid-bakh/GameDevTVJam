using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMYSTATES { Normal, Enraged}

public class EnemyStates : MonoBehaviour
{    
    //This is the same as using a private var and public getter but in 1 line.
    [field: Header("State")]
    [field: SerializeField] public ENEMYSTATES CurrentState;

    [Header("Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite enragedSprite;

    private SpriteRenderer enemyRenderer;
    private BoxCollider enemyCollider;

    void Awake()
    {
        enemyRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<BoxCollider>();
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

    //Resizes the collider to match the sprite
    void ResizeCollider()
    {
        enemyCollider.size = new Vector3(enemyRenderer.bounds.size.x / transform.lossyScale.x,
                                         enemyRenderer.bounds.size.y / transform.lossyScale.y,
                                         enemyRenderer.bounds.size.z / transform.lossyScale.z);
    }
}
