using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observer2_NameManager : MonoBehaviour
{
    [SerializeField] private string m_name;

    public static event Action<string> OnContactSayYourNameEvent;

    public string YourName
    {
        get
        {
            return m_name;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (OnContactSayYourNameEvent != null)
        {
            OnContactSayYourNameEvent?.Invoke(m_name);
            //Same as
            //OnContactSayYourNameEvent(m_name);
        }
            
    }
}
