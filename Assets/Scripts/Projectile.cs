using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float lifeTime = 0.1f; // tempo de vida do projétil

    // Awake é chamado quando o GameObject do projétil é instanciado
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        // Destrói o projétil automaticamente após "lifeTime" segundos
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }

        Destroy(gameObject);
    }
}