using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SetProjectile();
    }

    public void SetProjectile()
    {
        // Configura la velocidad inicial del proyectil
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;
            Spawner.spawner.Push(gameObject);
        }
        
    }

    void Update()
    {
        // Rota el proyectil cada frame
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}