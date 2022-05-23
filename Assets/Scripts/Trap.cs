using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage = 40;
    [SerializeField] private float pushForce = 3f;

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (damageable != null)
        {
            damageable.Damage(damage);

            if (rb != null)
            {
                rb.velocity *= -pushForce;
            }
        }
    }
}
