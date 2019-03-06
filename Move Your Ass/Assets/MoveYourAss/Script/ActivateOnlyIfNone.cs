using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateOnlyIfNone : MonoBehaviour
{
    public string m_objectName = "MixedRealityCameraParent";
    public GameObject[] m_objectToActivate;
    public UnityEvent m_toDo;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject obj = GameObject.Find(m_objectName);
        if (obj == null)
        {
            m_toDo.Invoke();
        }
    }
    
}
