using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C_MapToSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public C_MenuScript menuScript;
    public Animator animator;
    public int mapToSelect;
    public bool isShowing;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Trigger hover animation only if the map is not selected
        if (mapToSelect != menuScript.mapSelection && !isShowing)
        {
            animator.Play("Show");
            isShowing = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert hover animation only if the map is not selected
        if (mapToSelect != menuScript.mapSelection && isShowing)
        {
            animator.Play("Hide");
            isShowing = false;
        }
    }

    bool IsAnimationPlaying(string stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
    }
}
