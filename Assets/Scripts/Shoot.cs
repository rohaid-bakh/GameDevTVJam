using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float fireRate = 0.5f;
    private float nextFire = 0;

    [Header("AI Shooting")]
    [SerializeField] private float detectRadius = 4f;
    //TODO: Can be private later
    [SerializeField] private bool playerInRange = false;

    [SerializeField] private bool isPlayer;

    //TODO: Should be moved into an enemyController/movement script
    private bool facingRight = true;

    private PlayerHealth player;
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;

        if (isPlayer)
        {
            player = GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && isPlayer)
        {
            ShootProjectile();
        }

        if (isPlayer == false)
        {
            //TODO: Should be moved into an enemyController/movement script
            float dist = Vector3.Distance(playerTransform.transform.position, transform.position);

            if (dist <= detectRadius)
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }

            AttackPlayerInRange();
        }
    }

    //Used by AI if isPlayer is false
    void AttackPlayerInRange()
    {
        if (playerInRange == false)
        {
            return;
        }

        if (playerTransform.transform.position.x < transform.position.x && facingRight)
        {
            FlipEnemy();        
        }
        else if (playerTransform.transform.position.x > transform.position.x && facingRight == false)
        {
            FlipEnemy();
        }

        ShootProjectile();
    }

    //TODO: Should be moved into an enemyController/movement script
    void FlipEnemy()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = transform.localScale;
        tmpScale.x *= -1;
        transform.localScale = tmpScale;
    }

    void ShootProjectile()
    {
        if (isPlayer && player.IsAlive == false)
        {
            return;
        }

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject go = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
            go.GetComponent<Projectile>().projectileOwner = transform;
        }
    }

    void OnDrawGizmos()
    {
        if (isPlayer == false)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectRadius);
        }
    }
}
