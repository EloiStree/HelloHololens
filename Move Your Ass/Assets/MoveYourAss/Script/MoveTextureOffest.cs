using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTextureOffest : MonoBehaviour
{
    public Vector2 m_offsetDirection =  Vector2.one;
    public float m_speed =2;
    public Material m_affectedMaterial;
    Vector2 m_currentOFfset;
    void Update()
    {
        
        m_currentOFfset += m_offsetDirection * Time.deltaTime* m_speed;
        m_affectedMaterial.SetTextureOffset("_MainTex", m_currentOFfset);

        
    }
}
