using System;
using UnityEngine;

/// <summary>
/// Example of an implementation of DamageComponent
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Bullet : DamageComponent
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D collider2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        collider2D.isTrigger = true;
    }

    public void Shoot(Vector3 direction)
    {
        rigidbody2D.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            DealDamage(damageable);
            gameObject.SetActive(false); //im setting the gameObject to FALSE in order to also release it back to the pool of BulletPooler
        }
    }
}

