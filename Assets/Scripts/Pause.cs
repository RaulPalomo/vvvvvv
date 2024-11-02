using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panelPausa; // Asigna aquí el panel de pausa desde el Inspector

    private bool juegoPausado = false;

    void Start()
    {
        
        panelPausa.SetActive(false);
    }

    void Update()
    {
        // Activa o desactiva el menú de pausa cuando se presiona "Escape"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ContinuarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        // Activa el panel de pausa y pausa el tiempo
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void ContinuarJuego()
    {
        // Desactiva el panel de pausa y reanuda el tiempo
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void SalirMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        juegoPausado = false;
    }
}
