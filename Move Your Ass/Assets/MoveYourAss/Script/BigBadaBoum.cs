using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBadaBoum : MonoBehaviour
{

    public Transform m_explosion;
    public float m_growingMultiplicator=40;
    public AnimationCurve m_growingCurved;
    public LayerMask m_affectedByTheBoum;
    public float m_time;
    void Start()
    {
        m_explosion.localScale = Vector3.zero;
    }

    void Update()
    {
        m_time += Time.deltaTime;
        
        float size = m_growingCurved.Evaluate(m_time)*m_growingMultiplicator;
        if (size<= 0)
            Destroy(this.gameObject);
        m_explosion.localScale = Vector3.one * size;
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
