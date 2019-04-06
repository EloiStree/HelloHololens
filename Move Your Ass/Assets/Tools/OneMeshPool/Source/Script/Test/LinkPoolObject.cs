using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkPoolObject : MonoBehaviour {

    public string _poolIdName="Default";
    public OneMeshPool _linkedPool;
    public PoolObject _linkedObject;
    void Start ()
    {
        if(_linkedPool==null)
          _linkedPool = OneMeshPool.GetPool(_poolIdName);
        if (_linkedPool != null) { 
            _linkedObject = _linkedPool.Next(true,true);
            if (_linkedObject != null)
            {
                _linkedObject.transform.parent = this.transform;
                _linkedObject.transform.localPosition = Vector3.zero;
                return;
            }
        }
        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void OnDestroy () {
        if (_linkedObject) {

            _linkedObject.transform.parent = null;
            _linkedObject.SetAsActive(false);
        }

    }
}
