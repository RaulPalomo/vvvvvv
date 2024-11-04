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


        if (playerInstance == null)
        {
            playerInstance = Instantiate(playerPrefab);
            DontDestroyOnLoad(playerInstance);
        }
       
        
    }
    void Start()
    {
        
        string previousEntryPoint = PlayerPrefs.GetString("PreviousEntryPoint", "front");


        if (previousEntryPoint == "front")
        {

            playerInstance.transform.position = spawnPointFromFront.position;
        }
        else if (previousEntryPoint == "back")
        {

            playerInstance.transform.position = spawnPointFromBack.position;
        }
    }
}
