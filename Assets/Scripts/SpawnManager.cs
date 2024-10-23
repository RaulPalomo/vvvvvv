using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPointFromFront; 
    public Transform spawnPointFromBack; 
    

    void Start()
    {
        // Obtener el punto de entrada anterior desde PlayerPrefs
        string previousEntryPoint = PlayerPrefs.GetString("PreviousEntryPoint", "front");

        // Mover al jugador dependiendo de su origen
        if (previousEntryPoint == "front")
        {
            // Mover el jugador al punto correspondiente
            GameObject.FindWithTag("Player").transform.position = spawnPointFromFront.position;
        }
        else if (previousEntryPoint == "back")
        {
            // Mover el jugador al punto correspondiente
            GameObject.FindWithTag("Player").transform.position = spawnPointFromBack.position;
        }
    }
}
