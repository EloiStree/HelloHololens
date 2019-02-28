using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public Transform m_camera;
    public Transform m_affected;
    void Update()
    {
        m_affected.position = m_camera.position;
        m_affected.rotation = m_camera.rotation;
    }
    private void Reset()
    {
        m_camera = Camera.main.transform;
        m_affected = this.transform;
    }
}
