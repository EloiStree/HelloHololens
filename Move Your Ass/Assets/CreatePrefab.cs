using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    public GameObject m_prefab;
    public Transform m_where;
    public Transform m_direction;
    public Transform m_scale;
    public Transform m_parent;

    public void Create()
    {
        GameObject obj = GameObject.Instantiate(m_prefab);
        if (m_where)
            obj.transform.position = m_where.position;
        if (m_direction)
            obj.transform.rotation = m_direction.rotation;
        if (m_scale)
            obj.transform.localScale = m_scale.localScale;
        if (m_parent)
            obj.transform.parent = m_parent;
    }
    private void Reset()
    {
        m_where = transform;
        m_direction = transform;
        m_scale = transform;
        m_parent = transform;
    }
}
