using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerId == -2)
        {
            GlobalEventManager.ClickRightEvent();
        }
        else if(eventData.pointerId == -1)
        {
            GlobalEventManager.ClickLeftEvent();
        }
    }
}
