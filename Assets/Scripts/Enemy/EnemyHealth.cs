using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    //This is the same as using a private var and public getter but in 1 line.
    [field: Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [field: SerializeField] public int Health { get; private set; }

    private EnemyStates state;

    private bool isEnraged = false;

    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<EnemyStates>();

        Health = maxHealth;
    }

    void Update()
    {
        //TODO: Temp inputs for testing, remove later
        if (Input.GetKeyDown(KeyCode.K))
        {
            Damage(20);
        }
    }

    //Call this from player projectiles OnTriggerEnter by accessing the IDamageable interface
    public void Damage(int damage)
    {
        Debug.Log("Enemy Hit!");

        Health -= damage;

        if (Health <= 0 && isEnraged == false)
        {
            Debug.Log("Enemy has become enraged");

            Respawn();
        }

        else if (Health <= 0 && isEnraged)
        {
            Debug.Log("Enemy has died");

            Die();
        }
    }

    void Respawn()
    {
        //TODO: Expand Respawn later
        state.SwitchState(ENEMYSTATES.Enraged);
        Health = maxHealth;
        isEnraged = true;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
