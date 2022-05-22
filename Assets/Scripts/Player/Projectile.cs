using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private int projectileDamage = 20;

    public Transform projectileOwner;

    private Rigidbody myRigidbody;
    private float xSpeed;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();        
    }

    void Start()
    {
        xSpeed = projectileOwner.localScale.x * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(xSpeed, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        
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
