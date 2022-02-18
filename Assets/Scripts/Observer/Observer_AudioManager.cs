using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In Observer Pattern we are listening for event ;
/// We call Methods when the event happen
/// </summary>

public class Observer_AudioManager : MonoBehaviour
{
    /// <summary>
    /// The audio source of our sound
    /// </summary>
    [SerializeField]
    private AudioSource m_audioSource = null;

    /// <summary>
    /// When clicking on the left mouse button we enable our audio source
    /// </summary>
    private void OnEnable()
    {
        Observer_MouseManager.OnClickHappens += PlayAudio;
    }

    /// <summary>
    /// At the end of our audio source we desable it ;
    /// (Expression-bodied syntax)
    /// </summary>
    private void OnDisable() => Observer_MouseManager.OnClickHappens -= PlayAudio;

    /// <summary>
    /// Play our audio source 
    /// </summary>
    private void PlayAudio()
    {
        if (m_audioSource != null)
            m_audioSource.Play();
    }

}
