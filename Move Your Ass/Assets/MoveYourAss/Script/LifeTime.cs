using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float m_maxTime = 20;

    void Start()
    {
        Destroy(this.gameObject, m_maxTime);   
    }

}
