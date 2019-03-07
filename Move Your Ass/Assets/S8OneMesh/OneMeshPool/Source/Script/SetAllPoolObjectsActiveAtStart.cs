using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllPoolObjectsActiveAtStart : MonoBehaviour
{
    public string m_poolName;
    public OneMeshPool m_poolRef;
    public bool m_setAsActive=true;
    public float m_delay = 0.1f;
    IEnumerator Start()
    {
        yield return m_delay;
        if (m_poolRef == null )
            m_poolRef = OneMeshPool.GetPool(m_poolName);
        if (m_poolRef)
        {
            foreach (PoolObject po in m_poolRef.GetAll())
            {
                po.SetAsActive(m_setAsActive);
            }
        }
    }
    
}
