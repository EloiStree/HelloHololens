using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAsteroidsPositioning : MonoBehaviour
{
    public Transform[] m_targets;
    public float m_minScaleValue = 1;
    public float m_maxScaleValue = 5;
    public float m_maxRange=30;
    public Transform m_center;
    
    void Awake()
    {
        int count = m_targets.Length;
        for (int i = 0; i < count; i++)
        {
            m_targets[i].position = GetRandomPosition();
            m_targets[i].localScale = GetRandomScale();

        }
    }

    private Vector3 GetRandomPosition()
    {
        return m_center.position +  new Vector3(UnityEngine.Random.Range(-m_maxRange, m_maxRange), UnityEngine.Random.Range(-m_maxRange, m_maxRange), UnityEngine.Random.Range(-m_maxRange, m_maxRange));
    }
    private Vector3 GetRandomScale()
    {
        return new Vector3(UnityEngine.Random.Range(m_minScaleValue, m_maxScaleValue), UnityEngine.Random.Range(m_minScaleValue, m_maxScaleValue), UnityEngine.Random.Range(m_minScaleValue, m_maxScaleValue));
    }

}
