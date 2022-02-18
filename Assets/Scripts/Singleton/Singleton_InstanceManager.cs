using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keep in mind that a Singleton Pattern create instance accessible in ALL the code and is likely a GLOBAL VARIABLE
/// </summary>

public class Singleton_InstanceManager : MonoBehaviour
{
    /// <summary>
    /// This will create our instance when call ; 
    /// We want to access the instance ;
    /// We do not want to modifie the instance ;
    /// </summary>
    public static Singleton_InstanceManager Instance { get; private set; }

    /// <summary>
    /// The value of our instance 
    /// </summary>
    public int Value;

    /// <summary>
    /// We want our instance call once but as soon as possible (before Start method)
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            // If our instance is null we create our first instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If we already have an instance we destroy the new one to keep only the first (delete that if we want to use the instance)
            Destroy(gameObject);
        }
    }


}
