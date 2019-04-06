using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class DebugMovePlayerMR : MonoBehaviour
{
    public Transform m_playerRooToMove;
    public Transform m_playerCameraRoot;
    
    public float m_moveSpeed = 2f;
    public float m_rotationSpeed = 50f;

    public float m_horizontalDegree;

    public float m_verticalDegree;

    public void Start()
    {
        if (!UnityEngine.XR.XRSettings.enabled)
            m_playerCameraRoot.localPosition = new Vector3(0, 1.7f, 0);
       else
            m_playerCameraRoot.localPosition = new Vector3(0,0, 0);

    }


    void Update()
    {
        //https://answers.unity.com/questions/1350081/xbox-one-controller-mapping-solved.html
        Vector3 movePosition = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveHead = new Vector3(Input.GetAxis("5th"), Input.GetAxis("4th"), 0);
        movePosition *= m_moveSpeed * Time.deltaTime;
        moveHead *= m_rotationSpeed * Time.deltaTime;

        m_playerRooToMove.Translate(movePosition,Space.Self);

        m_horizontalDegree += moveHead.y;
        if (m_horizontalDegree < -180f) m_horizontalDegree += 360f;
        if (m_horizontalDegree > 180f) m_horizontalDegree -= 360f;
        m_verticalDegree += moveHead.x;
        m_verticalDegree = Mathf.Clamp(m_verticalDegree, -80f, 80f);
        m_playerRooToMove.rotation = Quaternion.Euler(0, m_horizontalDegree, 0);
        m_playerCameraRoot.localRotation = Quaternion.Euler(m_verticalDegree, 0, 0);
       // m_playerCameraRoot.rotation =


    }

}
