using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLine : MonoBehaviour
{
    public Transform m_max;
    public Transform m_min;
    public float m_extra = 0.1f;
    public Color ColorIn = Color.green;
    public Color ColorOut = Color.red;


    public void Update()
    {
        Vector3 origin = m_min.position;
        Vector3 direction = m_max.position - m_min.position;
        Vector3 extra = direction * m_extra;
        Debug.DrawLine(origin, origin + direction, ColorIn);
        Debug.DrawLine(origin , origin + direction* -m_extra, ColorOut);
    }

}
