using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCamera : MonoBehaviour
{
    public Transform m_affectedTransform;
    public float m_horizontalRotation = 40f;
    public float m_verticalRotation = 40f;
    public float m_currentRotationHorizontal;
    public float m_currentRotationVertical;

    void Update()
    {
        Vector2 rotateCameraOf = new Vector2(Input.GetAxis("Horizontal")*m_horizontalRotation, Input.GetAxis("Vertical") * m_verticalRotation);
        m_currentRotationHorizontal += rotateCameraOf.x * Time.deltaTime;
        m_currentRotationVertical += rotateCameraOf.y * Time.deltaTime;
        m_affectedTransform.localRotation =Quaternion.Euler( new Vector3(-m_currentRotationVertical, m_currentRotationHorizontal, 0));

    }
    public void Reset()
    {
        m_affectedTransform = this.transform;
    }
}
