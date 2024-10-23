using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatePlayer : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Animator characterAnimator;

    // M�todo que se ejecuta cuando el rat�n entra en el bot�n
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        characterAnimator.SetBool("isWalking", true);
            
        
    }

    // M�todo que se ejecuta cuando el rat�n sale del bot�n
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        characterAnimator.SetBool("isWalking", false);
        
    }

}
