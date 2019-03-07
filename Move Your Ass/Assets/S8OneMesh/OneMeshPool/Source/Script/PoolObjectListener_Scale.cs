using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class PoolObjectListener_Scale : MonoBehaviour
{
    public Vector3 m_scale;
    public bool m_useOriginalOne=true;
    void Awake()
    {
        if (m_useOriginalOne)
            m_scale = transform.localScale;
        GetComponent<PoolObject>()
            .AddStateListener(
            delegate (bool value) {
                transform.localScale = value? m_scale: Vector3.zero;
            });
    }
    
}
