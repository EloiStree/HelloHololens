using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnlyIfNone : MonoBehaviour
{
    public string m_objectName = "MixedRealityCameraParent";
    public GameObject[] m_objectToActivate;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject obj = GameObject.Find(m_objectName);
        if (obj == null)
        {
            foreach (var toActivate in m_objectToActivate)
            {
                toActivate.SetActive(true);

            }
        }
    }
    
}
