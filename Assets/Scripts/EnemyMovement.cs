using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 2f;      
    public float rangoMovimiento = 5f;  

    private float posicionInicialX; 

    void Start()
    {
        posicionInicialX = transform.position.x;
    }

    void Update()
    {
        float nuevaPosicionX = posicionInicialX + Mathf.PingPong(Time.time * velocidad, rangoMovimiento * 2) - rangoMovimiento;
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);
    }
}
