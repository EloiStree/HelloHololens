using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HololensActionListener : MonoBehaviour, IInputHandler
{
    public UnityEvent m_onClickDown;
    public UnityEvent m_onClickUp;
    public void OnInputDown(InputEventData eventData)
    {
        m_onClickDown.Invoke();
    }

    public void OnInputUp(InputEventData eventData)
    {
        m_onClickUp.Invoke();
    }




   
}
