using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipPosition : MonoBehaviour
{
    public Transform m_affectedSpaceShip;
    public Transform m_cameraDirection;
    public Transform m_wantedPosition;


    void Update()
    {

        Vector3 cameraDirection = m_cameraDirection.forward;
        cameraDirection.y = 0;
        cameraDirection.x = 0;
        m_affectedSpaceShip.forward = Vector3.Lerp(m_affectedSpaceShip.forward, cameraDirection, Time.deltaTime);
        m_affectedSpaceShip.position = Vector3.Lerp(m_affectedSpaceShip.position, m_wantedPosition.position, Time.deltaTime);

        
    }
}
