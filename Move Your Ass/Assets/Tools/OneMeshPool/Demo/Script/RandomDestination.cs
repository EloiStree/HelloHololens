using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestination : MonoBehaviour {

    public Vector3 _nextPosition;
    public Transform _affectedObject;
    public float _rotationSpeed = 0.5f;
    public float _movingSpeed = 2f;

    public Repositioning _repositioning = new Repositioning(1,10,50);   
    [Serializable]
    public struct Repositioning {
        public Repositioning(float minTime, float maxTime, float range) {
            _minTime = minTime;
            _maxTime = maxTime;
            _localRange = range;
        }
        public float _minTime;
        public float _maxTime;
        public float _localRange;

        public Vector3 RandomPoint() { return new Vector3(RandomRange(), RandomRange(), RandomRange()); }
        public float RandomRange() { return UnityEngine.Random.Range(-_localRange, _localRange); }

        public float NextDirectionChange()
        {
            return UnityEngine.Random.Range(_minTime, _maxTime);
        }
    }
    public IEnumerator Start()
    {
        while (true)
        {
            RepositionTheDestination();
            yield return new WaitForSeconds(_repositioning.NextDirectionChange());
        }
    }

    private void RepositionTheDestination()
    {
        _nextPosition = _repositioning.RandomPoint();
    }

    public void Update()
    {
        if (Vector3.Distance(_nextPosition, transform.position) < 1f)
            RepositionTheDestination();

        Vector3 direction = (_nextPosition - transform.position).normalized; 
        _affectedObject.rotation = Quaternion.Slerp(_affectedObject.rotation, Quaternion.LookRotation(direction), Time.deltaTime* _rotationSpeed);
        _affectedObject.position +=(_affectedObject.forward* _movingSpeed*Time.deltaTime);
    }

    private void OnValidate()
    {
        if (_affectedObject == null)
            _affectedObject = this.transform;
    }
	
}
