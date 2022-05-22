using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [field: SerializeField] public int ProjectileDamage = 20;
    [SerializeField] private float fireRate = 0.5f;
    private float nextFire = 0;
    private float shootTimer = 0;

    [Header("AI Shooting")]
    [SerializeField] private float detectRadius = 4f;
    [field: SerializeField] public bool PlayerInRange { get; private set; }

    //Is this object the player?
    [SerializeField] private bool isPlayer = false;   

    private PlayerHealth player;
    private EnemyController enemyController;
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        enemyController = GetComponent<EnemyController>();

        if (isPlayer)
        {
            player = GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftControl) && isPlayer)
        {
            ShootProjectile();
        }

        if (isPlayer == false)
        {
            float dist = Vector3.Distance(playerTransform.transform.position, transform.position);

            if (dist <= detectRadius)
            {
                PlayerInRange = true;
            }
            else
            {
                PlayerInRange = false;
            }

            AttackPlayerInRange();
        }
    }

    //Used by AI if isPlayer is false
    void AttackPlayerInRange()
    {
        if (PlayerInRange == false)
        {
            return;
        }

        if (playerTransform.transform.position.x < transform.position.x && enemyController.FacingRight)
        {
            enemyController.FlipEnemy();        
        }
        else if (playerTransform.transform.position.x > transform.position.x && enemyController.FacingRight == false)
        {
            enemyController.FlipEnemy();
        }

        ShootProjectile();
    }

    void ShootProjectile()
    {
        if (isPlayer && player.IsAlive == false)
        {
            return;
        }

        if (shootTimer > nextFire)
        {
            nextFire = shootTimer + fireRate;

            GameObject go = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
            go.GetComponent<Projectile>().projectileOwner = transform;
        }
    }

    //Uncomment to test radius 
    void OnDrawGizmos()
    {
        if (isPlayer == false)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectRadius);
        }
    }
}
