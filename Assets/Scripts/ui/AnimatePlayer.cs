using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimatePlayer : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Animator characterAnimator;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        characterAnimator.SetBool("isWalking", true);
            
        
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        characterAnimator.SetBool("isWalking", false);
        
    }

}
