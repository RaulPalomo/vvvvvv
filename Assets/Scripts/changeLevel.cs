using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{
    public string sceneToLoad; 
    public string entryPoint; 

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            
            PlayerPrefs.SetString("PreviousEntryPoint", entryPoint);

            Debug.Log(sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
