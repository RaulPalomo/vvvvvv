using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /*public Transform player;  
    public float smoothSpeed = 0.125f;  
    public Vector3 offset; 
    public Rigidbody2D rb;
    public float verticalOffset = 1.0f;

    void FixedUpdate()
    {
        
        
        Vector3 desiredPosition = player.position + offset;

        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);  
    }*/
    public Transform player;
    public Vector3 offset;
    public float smoothSpeedX = 0.125f;
    public float smoothSpeedY = 0.005f;
    public Rigidbody2D playerRigidbody; 
    public float verticalOffset = 20f; 

    void LateUpdate()
    {

        Vector3 desiredPosition = player.position + offset;

        // Ajusta el offset vertical dependiendo de la gravedad
        if (playerRigidbody.gravityScale > 0)
        {
            desiredPosition.y += verticalOffset;
        }
        else if (playerRigidbody.gravityScale < 0)
        {
            desiredPosition.y -= verticalOffset;
        }

        // Suavizado de la posición de la cámara usando Lerp para suavizar la transición
        Vector3 smoothedPosition = new Vector3(
            Mathf.Lerp(transform.position.x, desiredPosition.x, smoothSpeedX), // Suavizado en X
            Mathf.Lerp(transform.position.y, desiredPosition.y, smoothSpeedY), // Suavizado en Y con velocidad ajustada
            transform.position.z); // Mantén el valor Z sin cambios (2D)

        // Asigna la posición suavizada a la cámara
        transform.position = smoothedPosition;
    }
}
