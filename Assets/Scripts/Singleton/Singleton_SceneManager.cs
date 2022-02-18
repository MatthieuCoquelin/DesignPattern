using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Singleton_SceneManager : MonoBehaviour
{
    /// <summary>
    /// Will be incremented each time we change our scene 
    /// </summary>
    [SerializeField]
    private Text m_valueText = null;

    // Start is called before the first frame update
    void Start()
    {
        // Do not forget to on build 
        if (m_valueText != null)
        {
            //modifie the text value with the value variable of our singleton 
            m_valueText.text = Singleton_InstanceManager.Instance.Value.ToString();
        }
        
        
    }

    /// <summary>
    /// Call our instance and increment its value property when calling the first scene (click on the button)
    /// </summary>
    public void GoToFirstScene()
    {
        SceneManager.LoadScene("Singleton_FirstScene");
        Singleton_InstanceManager.Instance.Value++;
    }

    /// <summary>
    /// Call our instance and increment its value property when calling the second scene (click on the button)
    /// </summary>
    public void GoToSecondScene()
    {
        SceneManager.LoadScene("Singleton_SecondScene");
        Singleton_InstanceManager.Instance.Value++;
    }
}
