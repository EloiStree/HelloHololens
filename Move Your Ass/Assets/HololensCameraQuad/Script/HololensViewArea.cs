using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HololensViewArea : MonoBehaviour
{
    public bool m_use;
    public static HololensViewArea m_instanceInScene;
    public void Awake()
    {
        m_instanceInScene = this;
    }
 
    public void OnTriggerEnter(Collider other)
    {
        HololensViewAffectable affectable = other.GetComponent<HololensViewAffectable>();
        if (affectable != null)
            affectable.SetVisible(true);
    }
    public void OnTriggerExit(Collider other)
    {

        HololensViewAffectable affectable = other.GetComponent<HololensViewAffectable>();
        if (affectable != null)
            affectable.SetVisible(false);
    }

    public void OnValidate()
    {

        GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();
        for (int i = 0; i < objs.Length; i++)
        {
        HololensViewAffectable affectable = objs[i].GetComponent<HololensViewAffectable>();
            if (affectable!=null)
            {
                affectable.SetVisible(m_use);
            }
        }
    }
}

public interface HololensViewAffectable
{

    void SetVisible(bool value);

}