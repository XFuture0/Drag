using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StringEventSO
{
    public static event Action<int> GetPointEvent;
    public static void CallGetPointEvent(int Int)
    {
        GetPointEvent?.Invoke(Int);
    }
    public static event Action GameOverEvent;
    public static void CallGameOverEvent()
    {
        GameOverEvent?.Invoke();
    }
}
