using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyStroke : MonoBehaviour
{
    public KeyCode[] m_keys;
    public UnityEvent m_onOneKeyUp;
    public UnityEvent m_onOneKeyDown;
    void Update()
    {
        for (int i = 0; i < m_keys.Length; i++)
        {
            if (Input.GetKeyDown(m_keys[i]))
                m_onOneKeyDown.Invoke();
            if (Input.GetKeyUp(m_keys[i]))
                m_onOneKeyUp.Invoke();
        }
        
    }
}
