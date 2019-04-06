using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HololensViewAffectableScaleMono : MonoBehaviour, HololensViewAffectable
{
    public Transform m_affected;
    public Vector3 m_scaleBeforDisabled;
    public bool m_isHidden;
    public bool m_visibilityAtStart=true;
    public void Start()
    {
        if (HololensViewArea.m_instanceInScene == null || !HololensViewArea.m_instanceInScene.m_use)
            return;

            m_scaleBeforDisabled = m_affected.localScale;
            SetVisible(m_visibilityAtStart);



    }
    public void SetVisible(bool value)
    {
        if (HololensViewArea.m_instanceInScene == null || !HololensViewArea.m_instanceInScene.m_use)
            return;
        if (value)
        {
            m_affected.localScale =
               m_scaleBeforDisabled;
        }
        else 
        {
            if(!m_isHidden)
                m_scaleBeforDisabled = m_affected.localScale;
            m_affected.localScale = Vector3.one*0.001f;
        }
        m_isHidden = !value;
    }
    public void Reset()
    {
        m_affected = this.transform;
    }
}

