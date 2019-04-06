using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectListener_SetActivate : MonoBehaviour
{
    void Awake()
    {
        GetComponent<PoolObject>()
            .AddStateListener(
            delegate (bool value) {
                gameObject.SetActive(value);
            });
    }

}
