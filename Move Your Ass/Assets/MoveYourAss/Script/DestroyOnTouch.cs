using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    public LayerMask m_destroyObjectOfType;

   
    private void OnCollisionEnter(Collision collision)
    {
        if (IsInLayerMask(collision.gameObject, m_destroyObjectOfType))
            DestructorCall.TryToDestroy(collision.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(IsInLayerMask(other.gameObject, m_destroyObjectOfType))
            DestructorCall.TryToDestroy(other.gameObject);
    }
    public static bool IsInLayerMask( GameObject gameObject, LayerMask layerMask)
    {
        LayerMask gameObjectMask = (1 << gameObject.layer);
        return ((gameObjectMask & layerMask) == gameObjectMask);
    }

}
