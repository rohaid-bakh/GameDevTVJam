using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;

    [Header("Enrage")]
    [SerializeField] private bool enemyHasEnrage = false;
    private bool isEnraged = false;

    private EnemyStates state;

    void Awake()
    {
        state = GetComponent<EnemyStates>();

        health = maxHealth;
    }

    //Call this from player projectiles OnTriggerEnter by accessing the IDamageable interface
    public void Damage(int damage)
    {
        Debug.Log("Enemy Hit!");

        health -= damage;

        if (health <= 0 && isEnraged == false && enemyHasEnrage)
        {
            Debug.Log("Enemy has become enraged");

            Respawn();
        }

        else if (health <= 0 && isEnraged)
        {
            Debug.Log("Enemy has died");

            Die();
        }

        else if (health <= 0 && enemyHasEnrage == false)
        {
            Debug.Log("Enemy has died");

            Die();
        }
    }

    void Respawn()
    {
        //TODO: Expand Respawn later
        state.SwitchState(ENEMYSTATES.Enraged);
        health = maxHealth;
        isEnraged = true;
    }

    void Die()
    {
        //TODO: Expand Death later
        Destroy(gameObject);
    }
}
