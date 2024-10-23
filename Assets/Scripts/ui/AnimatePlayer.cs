using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatePlayer : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Animator characterAnimator;

    // Método que se ejecuta cuando el ratón entra en el botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        characterAnimator.SetBool("isWalking", true);
            
        
    }

    // Método que se ejecuta cuando el ratón sale del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        characterAnimator.SetBool("isWalking", false);
        
    }

}
