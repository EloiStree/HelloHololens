using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public Transform[] m_targets;
    public RandomRotationData[] m_rotationsState;
    public float m_minRotationValue = 45;
    public float m_maxRotationValue = 180;
    
    // Start is called before the first frame update
    void Awake()
    {
        int count = m_targets.Length;
        m_rotationsState = new RandomRotationData[count];
        for (int i = 0; i < count; i++)
        {
            m_rotationsState[i].m_linkedObject = m_targets[i];
            m_rotationsState[i].m_euleurRotaionn = GetRandomEuleurRotation();

        }
    }

    private Vector3 GetRandomEuleurRotation()
    {
        return new Vector3(UnityEngine.Random.Range(m_minRotationValue, m_maxRotationValue), UnityEngine.Random.Range(m_minRotationValue, m_maxRotationValue), UnityEngine.Random.Range(m_minRotationValue, m_maxRotationValue));
    }
    public struct RandomRotationData
    {
        public Vector3 m_euleurRotaionn;
        public Vector3 m_rotationState;
        public Transform m_linkedObject;

    }

    public void Update()
    {
        //Replace later by a computer shader for the demo
        int count = m_rotationsState.Length;
        for (int i = 0; i < count; i++)
        {
            m_rotationsState[i].m_rotationState += Time.deltaTime * m_rotationsState[i].m_euleurRotaionn;
            m_rotationsState[i].m_linkedObject.rotation = Quaternion.Euler(m_rotationsState[i].m_rotationState);

        }
    }
}
