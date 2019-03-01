using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float m_maxTime = 20;
    public DestructorCall m_onLifeOut;
    void Start()
    {
        Invoke("Kill", m_maxTime);
    }
    void Kill() {
        if (m_onLifeOut == null)
            Destroy(this.gameObject);
        else 
        m_onLifeOut.ProcessedToDestroy();
    }

}
