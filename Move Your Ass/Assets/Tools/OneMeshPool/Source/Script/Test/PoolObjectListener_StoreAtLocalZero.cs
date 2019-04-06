using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class PoolObjectListener_StoreAtLocalZero : MonoBehaviour
{

    void Awake()
    {
   
        GetComponent<PoolObject>()
            .AddStateListener(
            delegate (bool value) {
                transform.localPosition =Vector3.zero;
            });
    }

}
