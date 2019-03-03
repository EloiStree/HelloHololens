using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipPosition : MonoBehaviour
{
    public Transform m_affectedSpaceShip;
    public Transform m_cameraDirection;
    public Transform m_wantedPosition;

    private void Start()
    {

        TryToFindPositionToFollow();
    }

    void Update()
    {

        if (m_cameraDirection!=null && m_wantedPosition!=null) {
            Vector3 cameraDirection = m_cameraDirection.forward;
            cameraDirection.y = 0;
            cameraDirection.x = 0;
            m_affectedSpaceShip.forward = Vector3.Lerp(m_affectedSpaceShip.forward, cameraDirection, Time.deltaTime);
            m_affectedSpaceShip.position = Vector3.Lerp(m_affectedSpaceShip.position, m_wantedPosition.position, Time.deltaTime);



        }
        else
            TryToFindPositionToFollow();

    }
    private void Reset()
    {
        m_affectedSpaceShip = this.transform;
        TryToFindPositionToFollow();
    }
  

    private void TryToFindPositionToFollow()
    {
        SpaceShipPositionTag tag = GameObject.FindObjectOfType<SpaceShipPositionTag>();
        if (tag)
        {
            if (m_cameraDirection == null)
                m_cameraDirection = tag.transform;
            if (m_wantedPosition == null)
                m_wantedPosition = tag.transform;
        }
    }
}
