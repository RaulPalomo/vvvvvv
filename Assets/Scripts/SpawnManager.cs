using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPointFromFront; 
    public Transform spawnPointFromBack;
    public GameObject playerPrefab;

    private GameObject playerInstance;
    private void Awake()
    {
        playerInstance = GameObject.FindWithTag("Player");

        // Implementación del patrón Singleton
        if (playerInstance == null)
        {
            playerInstance = Instantiate(playerPrefab);
            DontDestroyOnLoad(playerInstance);
        }
       
        
    }
    void Start()
    {
        
        string previousEntryPoint = PlayerPrefs.GetString("PreviousEntryPoint", "front");

        // Mover al jugador dependiendo de su origen
        if (previousEntryPoint == "front")
        {
            // Mover el jugador al punto correspondiente
            playerInstance.transform.position = spawnPointFromFront.position;
        }
        else if (previousEntryPoint == "back")
        {
            // Mover el jugador al punto correspondiente
            playerInstance.transform.position = spawnPointFromBack.position;
        }
    }
}
