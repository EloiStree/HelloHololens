using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class MoveHandEscordBasedOnHands : MonoBehaviour
{
#if UNITY_WSA
    public HandsInput m_handsInput;
    public HandBasicTag [] m_handsTransform;
    public Text m_debug;
    void Update()
    {
        if(m_debug)
        m_debug.text = string.Format("{0}:{1} <-> {2}:{3}", m_handsInput.handStates[0].isTappingDown, m_handsInput.handStates[0].latestTapStartPosition, m_handsInput.handStates[1].isTappingDown, m_handsInput.handStates[1].latestTapStartPosition );
        if (m_handsInput.handStates[0].isTappingDown)
        {
            m_handsTransform[0].transform.position = m_handsInput.handStates[0].latestTapStartPosition;
            m_handsTransform[0].m_isDown = m_handsInput.handStates[0].isTappingDown;
        }
        else {
            m_handsTransform[0].transform.position = InputTracking.GetLocalPosition(XRNode.LeftHand);
            m_handsTransform[0].m_isDown = Input.GetAxis("CONTROLLER_LEFT_TRIGGER") > 0f;



        }

        if (m_handsInput.handStates[1].isTappingDown)
        {
            m_handsTransform[1].transform.position = m_handsInput.handStates[1].latestTapStartPosition;
            m_handsTransform[1].m_isDown = m_handsInput.handStates[1].isTappingDown;

        }
        else
        {
            m_handsTransform[1].transform.position = InputTracking.GetLocalPosition(XRNode.RightHand);
            m_handsTransform[1].m_isDown = Input.GetAxis("CONTROLLER_RIGHT_TRIGGER") >0f;
        }

    }
#endif
}
