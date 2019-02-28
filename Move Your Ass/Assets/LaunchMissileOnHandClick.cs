using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class LaunchMissileOnHandClick : MonoBehaviour, IInputHandler
{
    public MoveTowardGivenTarget locker;
    public void OnInputDown(InputEventData eventData)
    {
        LaunchMissileOnTarget();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
            LaunchMissileOnTarget();
    }
    private void LaunchMissileOnTarget()
    {
        TargetableByHololensFocus focus = TargetableByHololensFocus.GetLastFocused();
        if (focus)
            locker.m_target = focus.transform;
    }

    public void OnInputUp(InputEventData eventData)
    {
      
    }


}
