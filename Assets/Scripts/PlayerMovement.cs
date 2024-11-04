using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  
    private Rigidbody2D rb;       
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    public float groundCheckDistance = 0.1f; 
    public LayerMask groundLayer;
    private Vector2 lastCheckpointPosition;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastCheckpointPosition = transform.position;
    }
   
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");

        if (animator.GetBool("isDead") == false)
        {
            if (movement.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movement.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
        

        if (rb.velocity.x==0 && IsGrounded())
        {
            animator.SetBool("isFalling", false);

            animator.SetBool("isWalking", false);
        }
        else if(rb.velocity.y!=0 && !IsGrounded())
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);

            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            
            
            rb.gravityScale= (-rb.gravityScale);
            //spriteRenderer.flipY = !spriteRenderer.flipY;
            transform.localScale= new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnAtCheckpoint();
        }

    }
    bool IsGrounded()
    {
        // Direccion del Raycast basada en el gravityScale del Rigidbody2D
        Vector2 raycastDirection = rb.gravityScale > 0 ? Vector2.down : Vector2.up;

        // Posicion de inicio del raycast (en los pies del objeto)
        Vector2 raycastOrigin = rb.position; // Posición actual del Rigidbody2D

        // Realiza un raycast desde la posición del objeto en la dirección del raycast
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, groundCheckDistance, groundLayer);

        // Dibuja el Raycast en la escena para depuración (se puede quitar luego)
        Debug.DrawRay(raycastOrigin, raycastDirection * groundCheckDistance, Color.red);

        // Devuelve true si el raycast golpea algo en la capa del suelo
        return hit.collider != null;
    }

    void FixedUpdate()
    {
        
        if (movement.x != 0 && animator.GetBool("isDead") == false)
        {
            rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Checkpoint"))
        {
            // Actualizamos la posición del último checkpoint
            lastCheckpointPosition = other.transform.position;
            Debug.Log("Checkpoint alcanzado en: " + lastCheckpointPosition);
        }
        else if (other.CompareTag("DeathZone"))
        {
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            RespawnAtCheckpoint();
        }
    }


    public void RespawnAtCheckpoint()
    {
        // Activar la animación de muerte
        animator.SetBool("isDead", true);

        // Iniciar la corrutina para esperar a que la animación termine antes de reaparecer
        StartCoroutine(EsperarAnimacionYRespawn());
    }

    IEnumerator EsperarAnimacionYRespawn()
    {



        // Esperar a que la animación de muerte termine
        yield return new WaitForSeconds(0.3f);
        
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // La animación de muerte ha terminado, ahora respawn en el checkpoint
        if (lastCheckpointPosition != Vector2.zero)
        {
            if(rb.gravityScale < 0) { rb.gravityScale *=(-1); transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z); }
            transform.position = lastCheckpointPosition;

            Debug.Log("Reapareciendo en: " + lastCheckpointPosition);
        }
        else
        {
            Debug.Log("No se ha alcanzado ningún checkpoint.");
        }

        // Finalmente, hacer que isDead sea false
        animator.SetBool("isDead", false);
        Debug.Log("El jugador ha revivido");
    }

}
