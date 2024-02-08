using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    // событие получения рандомной точки

    public static Func<Vector3> ReceivingRandomPoint;
    public static Action ClickRigth;
    public static Action ClickLeft;
    public static Vector3 ReceivingRandomPointInvoke()
    {
        return ReceivingRandomPoint.Invoke();
    }

    public static void ClickRightEvent()
    {
        ClickRigth?.Invoke();
    }

    public static void ClickLeftEvent()
    {
        ClickLeft?.Invoke();
    }
}
