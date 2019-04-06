using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FastObjectCollision : MonoBehaviour
{
    public Transform m_targeted;
    public float m_delay=0.1f;
    public LayerMask m_layersAllow;
    public float m_radius = 0.1f;
    public OnCollision m_onHasHit;

    public Vector3 m_lastPosition;
    public Vector3 m_currentPosition;
    IEnumerator Start()
    {
        while (true) {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_delay);
            m_lastPosition = m_currentPosition;
            m_currentPosition = m_targeted.position;

            RaycastHit hit;
            bool hasHit = Physics.SphereCast(
                m_lastPosition,
                m_radius,
                (m_currentPosition- m_lastPosition).normalized, 
                out hit,
                Vector3.Distance(m_lastPosition, m_currentPosition),
                m_layersAllow);
            if (hasHit)
                m_onHasHit.Invoke(m_targeted.gameObject, hit.collider);


        }
    }

    public void Reset() {
        m_targeted = this.transform;
    }
    [System.Serializable]
    public class OnCollision : UnityEvent<GameObject, Collider> {

    }
    
}
