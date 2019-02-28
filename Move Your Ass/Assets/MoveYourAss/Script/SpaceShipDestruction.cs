using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipDestruction : MonoBehaviour
{
    public GameObject m_explosion;
    public Transform m_explosionPosition;
    public GameObject m_spaceShipToDestroy;
    
    public void BigBadaBoum()
    {
        GameObject.Instantiate(m_explosion, m_explosionPosition.position, m_explosionPosition.rotation);
        m_spaceShipToDestroy.SetActive(false);
    }
}
