using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    //This is the same as using a private var and public getter but in 1 line.
    [field: Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [field: SerializeField] public int Health { get; private set; }

    [Header("Respawn")]
    [SerializeField] private Transform respawnPoint;

    private PlayerStates state;

    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<PlayerStates>();

        Health = maxHealth;
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

        Health -= damage;

        if (Health <= 0)
        {
            Debug.Log("Player has died");

            Respawn();
        }
    }

    void Respawn()
    {
        //TODO: Expand Respawn later
        transform.position = respawnPoint.position;
        state.SwitchState();
        Health = maxHealth;
    }
}
