using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.DeleteAll();
        Destroy(GameObject.FindWithTag("Player"));
    }


    void Update()
    {
        
    }
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnExitGame()
    {
        Application.Quit();
    }
}
