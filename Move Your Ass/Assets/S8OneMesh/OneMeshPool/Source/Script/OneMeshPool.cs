using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMeshPool : MonoBehaviour {

    private static Dictionary<string, OneMeshPool> PoolsInScene=new Dictionary<string, OneMeshPool>();
    public static OneMeshPool GetPool(string poolName)
    {
        if (PoolsInScene.ContainsKey(poolName))
            return PoolsInScene[poolName];
        return null;
    }

    internal PoolObject Next(bool autoReset = true, bool autoActivate=true)
    {
        if (_anchorPoints.Length == 0)
            return null;

        int noNextAvailaible = _anchorPoints.Length ;
        PoolObject next = null;

        while (next == null && noNextAvailaible > 0) {
            noNextAvailaible--;
            nextIndex++;
            if (nextIndex >= _anchorPoints.Length)
                nextIndex = 0;

            if (_anchorPoints[nextIndex].IsRecyclable()) {
                next = _anchorPoints[nextIndex];
                if (autoReset)
                    next.ResetToDefaultValue();
                if (autoActivate)
                    next.SetAsActive(true);
                break;
            }
        }
        return next;
    }

   

    [SerializeField]
    [Tooltip("Identity name of the pool")]
    private string _poolName="Default Pool";


    [Tooltip("Link here all the bones of your one mesh you want to access as object view")]
    [SerializeField]
    private PoolObject[] _anchorPoints;

    [Tooltip("Next to be accessed")]
    [SerializeField]
    private int nextIndex;


    public  IEnumerable<PoolObject> GetAll()
    {
        return _anchorPoints;
    }


    // Use this for initialization
    void Awake () {
        if(_poolName!="")
            PoolsInScene.Add(_poolName,this);
	}
	
	// Update is called once per frame
	void OnDestroy ()
    {
        if (_poolName != "")
            PoolsInScene.Remove(_poolName);
    }
}
