using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WheelEvent
{
    OnStartSpin,
    OnEndSpin,
    OnTick,
    OnCoinWin,
    OnUpdateTotalEarnCredit,
}

public class WheelEventSystem: MonoBehaviour
{
    private static Dictionary<WheelEvent, Action> wheelEventsListeners = new Dictionary<WheelEvent, Action>();
    private static Dictionary<WheelEvent, Action<object>> wheelEventsListenersWithParamater = new Dictionary<WheelEvent, Action<object>>();

    public static void AddWheelEventListener(WheelEvent wheelEvent, Action evt)
    {
        if(wheelEventsListeners.TryGetValue(wheelEvent, out Action action))
            wheelEventsListeners[wheelEvent] = action += evt;
        else
            wheelEventsListeners[wheelEvent] = evt;
    }

    public static void AddWheelEventListener<T>(WheelEvent wheelEvent, Action<T> evt)
    {
        Action<object> newAction = (e) => evt((T)e);

        if (wheelEventsListenersWithParamater.TryGetValue(wheelEvent, out Action<object> action))
            wheelEventsListenersWithParamater[wheelEvent] = action += newAction;
        else
            wheelEventsListenersWithParamater[wheelEvent] = newAction;
    }

    public static void RemoveWheelEventListener(WheelEvent wheelEvent, Action evt)
    {
        if (wheelEventsListeners.TryGetValue(wheelEvent, out var action))
        {
            action -= evt;
            if (action == null)
                wheelEventsListeners.Remove(wheelEvent);
            else
                wheelEventsListeners[wheelEvent] = action;
        }
    }

    public static void RemoveWheelEventListener<T>(WheelEvent wheelEvent, Action<T> evt)
    {
        if (wheelEventsListenersWithParamater.TryGetValue(wheelEvent, out var action))
        {
            Action<object> removeAction = (e) => evt((T)e);
            action -= removeAction;

            if (action == null)
                wheelEventsListenersWithParamater.Remove(wheelEvent);
            else
                wheelEventsListenersWithParamater[wheelEvent] = action;
        }
    }

    public static void Broadcast(WheelEvent wheelEvent)
    {
        if (wheelEventsListeners.TryGetValue(wheelEvent, out var action))
        {
            action.Invoke();
        }
    }

    public static void Broadcast(WheelEvent wheelEvent, object obj)
    {
        if (wheelEventsListenersWithParamater.TryGetValue(wheelEvent, out var action))
        {
            action.Invoke(obj);
        }
    }

    private void OnDestroy()
    {
        wheelEventsListeners.Clear();
        wheelEventsListenersWithParamater.Clear();
    }
}
