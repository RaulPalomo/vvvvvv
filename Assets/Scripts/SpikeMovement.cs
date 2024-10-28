using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public GameObject SpikedBall;
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
        rb.velocity = new Vector2(speed, 0); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Spawner.spawner.stack.Push(gameObject);
    }
    // Update se llama una vez por frame
    void Update()
    {
        SpikedBall.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
