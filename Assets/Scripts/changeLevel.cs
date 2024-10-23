using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{
    public string sceneToLoad; // El nombre de la escena que queremos cargar
    public string entryPoint; // El nombre del punto de entrada (si viene desde adelante o atrás)

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asumimos que el jugador tiene el tag "Player"
        {
            // Guardar el punto de entrada para saber de dónde viene el jugador
            PlayerPrefs.SetString("PreviousEntryPoint", entryPoint);

            // Cargar la nueva escena
            Debug.Log(sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
