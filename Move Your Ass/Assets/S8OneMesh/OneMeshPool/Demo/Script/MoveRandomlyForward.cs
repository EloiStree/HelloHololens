using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomlyForward : MonoBehaviour {
    
    public Transform _affectedObject;
    public float _randomRange = 15;
    public float _movingSpeed = 10f;
    
    public void Awake()
    {
        ApplyRandomNess();
    }

    public void ApplyRandomNess()
    {
        _affectedObject.rotation=Quaternion.Euler(new Vector3(RandomRange(), RandomRange(), 0)) *_affectedObject.rotation;
    }

    public float RandomRange() { return UnityEngine.Random.Range(-_randomRange, _randomRange); }
    public void Update()
    {
        _affectedObject.position += _affectedObject.forward * _movingSpeed * Time.deltaTime;
    }

    private void OnValidate()
    {
        if (_affectedObject == null)
            _affectedObject = this.transform;
    }
	
}
