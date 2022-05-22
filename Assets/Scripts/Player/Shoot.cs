using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifetime = 5f;
    [SerializeField] private float baseFiringRate = 0.5f;

    [SerializeField] private bool isPlayer;

    private PlayerHealth player;

    void Awake()
    {
        if (isPlayer)
        {
            player = GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (isPlayer && player.IsAlive == false)
        {
            return;
        }

        GameObject go = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        go.GetComponent<Projectile>().projectileOwner = transform;
    }
}
