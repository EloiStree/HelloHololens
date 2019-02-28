using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Transform m_affected;
    public float m_speed=2f;

    void Update()
    {
        m_affected.Translate(new Vector3(0, 0, m_speed)*Time.deltaTime, Space.Self);   
    }
    private void Reset()
    {
        m_affected = this.transform;
    }
}
