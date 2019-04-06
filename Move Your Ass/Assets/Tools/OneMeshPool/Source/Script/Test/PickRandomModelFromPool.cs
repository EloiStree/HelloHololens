using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRandomModelFromPool : MonoBehaviour
{
    [SerializeField] string m_poolName;
    [SerializeField] PoolObject obj;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        OneMeshPool pool = OneMeshPool.GetPool(m_poolName);
        if (pool == null)
            yield break;
        obj = pool.Next(true, true);
        if (obj != null) {
            obj.transform.parent = transform;
            obj.transform.rotation = transform.rotation  ;
            //obj.transform.localScale = transform.localScale  ;
            obj.transform.position = transform  .position ;

        }

    }
    public void OnDisable()
    {
        if (obj != null)
            obj.SetAsActive(false);
    }
}
