using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private int projectileDamage = 20;
    [SerializeField] private float projectileLifetime = 5f;

    //This is so the projectile knows if it should spawn on left or right depending on the sprites X scale
    public Transform projectileOwner;

    private Rigidbody myRigidbody;
    private float xSpeed;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();        
    }

    void Start()
    {
        //Spawns on the correct side and sets speed
        xSpeed = projectileOwner.localScale.x * projectileSpeed;

        Destroy(gameObject, projectileLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(xSpeed, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        Shoot shoot = other.GetComponent<Shoot>();

        //To make sure player or enemy cant hit themselves
        if (shoot.transform == projectileOwner)
        {
            return;
        } 

        if (damageable != null)
        {
            damageable.Damage(projectileDamage);
        }        
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}