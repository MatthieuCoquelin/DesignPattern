using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observer_MouseManager : MonoBehaviour
{
    /// <summary>
    /// Our event when ckicking ; 
    /// "event" prevent from calling ;
    /// Action inherit from delegate
    /// </summary>
    public static event Action OnClickHappens;

    ////Could use a delegate with a static event instead of action 
    //public delegate void OnClickReceived();
    //public static event OnClickReceived OnClickHappens;

    private void Update()
    {
        // when pressing left mouse button we call our listener by using Invoke method 
        if (Input.GetMouseButtonDown(0))
        {
            // "?" for positive case : OnEnable
            OnClickHappens?.Invoke(); 
        }
    }
}

