using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    public float m_time=5;
    public float m_leftTime;
    public bool m_loop=true;
    public UnityEvent m_doTheThing;
    // Start is called before the first frame update
    void Awake()
    {
        m_leftTime = m_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_leftTime > 0f)
            m_leftTime -= Time.deltaTime;
        else {
            m_leftTime = m_loop ? m_time : 0f;
            m_doTheThing.Invoke();
        }

        
    }
}
