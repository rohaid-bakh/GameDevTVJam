using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;

    [Header("Respawn")]
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay = 1f;

    //TODO: Can remove from inspector later
    [field: SerializeField] public bool IsAlive { get; private set; }

    private PlayerStates state;

    [Header("Slider")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image fillImage;
    public Gradient grad;

    [Header("Hit Flash")]
    [SerializeField] private Material flash;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private SpriteRenderer sprite;

    void Awake()
    {
        state = GetComponent<PlayerStates>();

        IsAlive = true;

        health = maxHealth;
        healthBar.normalizedValue = 1f;

        if (respawnPoint == null)
        {
            Debug.LogError("No Respawn Point assigned, setting current position as Respawn Point");
            respawnPoint = new GameObject().transform;
            respawnPoint.name = "Player Respawn Point";
            respawnPoint.position = transform.position;
        }
    }

    void Update()
    {
        //TODO: Temp inputs for testing, remove later
        if (Input.GetKeyDown(KeyCode.M))
        {
            Damage(20);
        }
    }

    //Call this from enemy projectiles OnTriggerEnter by accessing the IDamageable interface
    public void Damage(int damage)
    {
        if (IsAlive == false)
        {
            return;
        }

        Debug.Log("Player Hit!");

        health -= damage;
        updateUIbar();
        hitFlash();
        if (health <= 0)
        {
            Debug.Log("Player has died");
            IsAlive = false;

            StartCoroutine(Respawn());
        }
    }

    private void updateUIbar(){ 
        healthBar.normalizedValue = 1f - ((float)(maxHealth - health) / (float)maxHealth); // Sets the percent of the health bar
        fillImage.color =  grad.Evaluate(healthBar.normalizedValue); // Applies a gradient to the health bar image
    }

    private void hitFlash(){ // Shows a damage flash
        sprite.material = flash;
        sprite.color = Color.red; // can become any color
        StartCoroutine(endFlash());
    }

    private IEnumerator endFlash(){
        yield return new WaitForSeconds(.2f);
        sprite.color = Color.white;
        sprite.material = defaultMaterial;
    }
    IEnumerator Respawn()
    {
        //TODO: Expand Respawn later
        yield return new WaitForSeconds(respawnDelay);
        transform.position = respawnPoint.position;
        state.SwitchState();
        health = maxHealth;
        IsAlive = true;
    }
}
