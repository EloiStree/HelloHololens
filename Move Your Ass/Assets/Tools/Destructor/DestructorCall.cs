using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface DestructorCallInterface {
    void ProcessedToDestroy();
}
public class DestructorCall : MonoBehaviour, DestructorCallInterface
{
    public UnityEvent m_toDoBeforeDestruction;
    public bool m_useUnityDestroyAfter=true;
    public void ProcessedToDestroy()
    {
        m_toDoBeforeDestruction.Invoke();
        if (m_useUnityDestroyAfter)
            CallUnityDestructor();
    }


    public void CallUnityDestructor() {
        Destroy(this.gameObject);
    }

    internal static void TryToDestroy(GameObject gameObject)
    {
        DestructorCallInterface destoryable = gameObject.GetComponent<DestructorCallInterface>();
        if (destoryable != null)
            destoryable.ProcessedToDestroy();
        else Destroy(gameObject);

    }

    public void DestroyTarget(GameObject obj) {
        Destroy(obj);
    }
}
