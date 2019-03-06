using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBasicTag : MonoBehaviour
{
    public bool m_isDown;
    public Vector3 m_localPosition;
    public HandType m_handType;
    public enum HandType { Left, Right}

    public static HandBasicTag m_left;
    public static HandBasicTag m_right;


    public void Awake()
    {
        if (m_handType == HandType.Left)
            m_left = this;
        if (m_handType == HandType.Right)
            m_right = this;

    }
    private void Update()
    {
        m_localPosition = transform.position;
    }

    public void SetHandDown(bool state) {
        m_isDown = state;
    }
    public static HandBasicTag GetHand(HandType type) {
        if (type == HandType.Left) return m_left;
        return m_right;
    }
}
