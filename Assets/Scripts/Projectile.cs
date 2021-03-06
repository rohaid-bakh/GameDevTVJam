using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float projectileLifetime = 5f;

    //This is so the projectile knows if it should spawn on left or right depending on the sprites X scale
    public Transform projectileOwner;

    private Rigidbody myRigidbody;
    private Shoot shoot;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();        
    }

    void Start()
    {
        shoot = projectileOwner.GetComponent<Shoot>();

        //Spawns on the correct side and sets speed
        //xSpeed = projectileOwner.localScale.x * projectileSpeed;      //No longer needed

        Destroy(gameObject, projectileLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //Changed to work with the projectilespawnpoints location/side
        myRigidbody.velocity = transform.right * projectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        Shoot otherShoot = other.GetComponent<Shoot>();

        if (otherShoot != null)
        {
            //To make sure player or enemy cant hit themselves
            if (otherShoot.tag == projectileOwner.tag)
            {
                return;
            } 
        }

        if (damageable != null)
        {
            damageable.Damage(shoot.ProjectileDamage);
        }        

        Destroy(gameObject);
    }
}
