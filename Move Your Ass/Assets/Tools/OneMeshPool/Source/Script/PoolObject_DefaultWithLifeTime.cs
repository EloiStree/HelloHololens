using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PoolObject_DefaultWithLifeTime : PoolObject_Default
{

    [Space(10)]
    [Header("Params", order = 0)]
    [SerializeField]
    public bool _useLifeTime;
    public float _lifeTime = 5;
    [SerializeField]
    private float _countDown = 5;


    public void Update()
    {
        if (_countDown > 0f)
            _countDown -= Time.deltaTime;

        if (_countDown < 0f) {
            _countDown = 0f;
            SetAsActive(false);
        }
 

    }

    public override void ResetToDefaultValue() {
        _countDown = _lifeTime;
    }


}


