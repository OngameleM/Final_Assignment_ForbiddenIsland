using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Input : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<CardShow>() != null)
                CardManager.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardShow>());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointer
    }
}
