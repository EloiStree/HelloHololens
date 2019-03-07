using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HololensViewAffectableMono : MonoBehaviour, HololensViewAffectable
{
    public Renderer m_linkedRenderer;
    public bool m_isHidden;

    public void Start()
    {   
#if UNITY_EDITOR
        
        SetVisible(false);
#else
        DestroyImmediate(this);
#endif
    }

    public void SetVisible(bool value)
    {
        m_linkedRenderer.enabled= value;
        m_isHidden = !value;
    }

    public void Reset()
    {
        m_linkedRenderer = GetComponent<Renderer>();
    }

}
