using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    // Velocidad de movimiento hacia la izquierda
    public float speed = 5f;

    // Velocidad de rotación (en grados por segundo)
    public float rotationSpeed = 100f;
    public GameObject SpikedBall;
    private void Start()
    {
        
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Mover el GameObject hacia la izquierda (en el eje X negativo) en el plano 2D
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Rotar el GameObject en el eje Z (giro en 2D)
        SpikedBall.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
