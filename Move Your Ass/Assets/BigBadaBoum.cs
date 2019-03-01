using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadaBoum : MonoBehaviour
{

    public Transform m_explosion;
    public float m_maxRange=40;
    public float m_growingSpeed;
    public LayerMask m_affectedByTheBoum;
    public float m_currentSize;

    void Start()
    {
        m_explosion.localScale = Vector3.zero;
    }

    void Update()
    {
        m_currentSize += Time.deltaTime * m_growingSpeed;
        if (m_currentSize > 40f)
            Destroy(this.gameObject);
        m_explosion.localScale = Vector3.one * m_currentSize;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_affectedByTheBoum == (m_affectedByTheBoum | (1 << other.gameObject.layer)))
        {
            DestructorCall.TryToDestroy(other.gameObject);
        }
           
    }
    public DestructorCall m_destructor;

}
