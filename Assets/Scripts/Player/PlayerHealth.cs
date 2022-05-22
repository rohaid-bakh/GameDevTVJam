using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake()
    {
        state = GetComponent<PlayerStates>();

        IsAlive = true;

        health = maxHealth;
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
        Debug.Log("Player Hit!");

        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Player has died");
            IsAlive = false;

            StartCoroutine(Respawn());
        }
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
