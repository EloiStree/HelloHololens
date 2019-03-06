using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandToEscort : MonoBehaviour
{
    public HandBasicTag.HandType m_handType;
    public Transform m_center;
    public Transform m_ship;
    public LaunchMissileOnHandClick m_missileLauncher;
    public float m_multiplicator=1;

    [Header("Debug")]
    public bool m_wasDown;

    public HandBasicTag m_handInfo;

    void Update()
    {
        if (m_handInfo == null)
            m_handInfo = HandBasicTag.GetHand(m_handType);
        if (m_handInfo == null)
            return;

        m_ship.forward = m_center.forward;
        m_ship.position = m_center.position + m_handInfo.m_localPosition * m_multiplicator;

        if (m_wasDown != m_handInfo.m_isDown) {

            if (m_handInfo.m_isDown) {
                m_missileLauncher.LaunchMissileOnTarget();
                Debug.Log("Hey mon ami ! "+ m_handType);
            }
            m_wasDown = m_handInfo.m_isDown;
        }


    }
}
