using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioNearPlayer : MonoBehaviour
{
    public AudioSource m_audioSource;
    public float m_rangeOfTrigger = 5;
    public float m_delayToCheck=0.2f;

    public bool m_hasBeenTrigggered;

    public LayerMask m_playerLayer;
    public Transform m_triggerCenter;
    IEnumerator Start()
    {
        while (true) {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(0.2f);
            CheckForTrigger();
        }
    }

    private void CheckForTrigger()
    {
        if (!m_hasBeenTrigggered && Physics.OverlapSphere(m_triggerCenter.position, m_rangeOfTrigger, m_playerLayer).Length > 0) {
            m_hasBeenTrigggered = true;
            m_audioSource.Play();

        }
        
    }

    private void OnEnable()
    {
        ResetToDefault();
    }
    public void ResetToDefault() {
        m_hasBeenTrigggered = false;
    }
}
