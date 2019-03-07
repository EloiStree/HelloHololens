using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneMeshMinigun : MonoBehaviour {

    public string _bulletsPoolName="Bullets";
    public OneMeshPool _bulletsPool;
    public Transform _fireSpawner;
    public int _generateByFrame = 2;
    public float _frameDuration = 0.01f;
    public float _randomAngle=15f;

    IEnumerator Start()
    {

        //if (_bulletsPool == null)
        //    _bulletsPool = OneMeshPool.GetPool(_bulletsPoolName);
        //if (_bulletsPool) {
        //    foreach (PoolObject po in _bulletsPool.GetAll())
        //    {
        //        po.AddStateListener(delegate(bool value) { po.gameObject.SetActive(value); });
        //    }
        //}
        

        while (true)
        {
            yield return new WaitForSeconds(_frameDuration);
            if (Input.GetButton("Fire1") ){ 
            if (_bulletsPool == null)
                _bulletsPool = OneMeshPool.GetPool(_bulletsPoolName);
            if (_bulletsPool && _fireSpawner)
                for (int i = 0; i < _generateByFrame; i++)
                {
                    PoolObject obj = _bulletsPool.Next(true, true);
                    if (obj)
                        {
                           
                        obj.gameObject.SetActive(true);
                        obj.transform.position = _fireSpawner.position;
                        obj.transform.rotation = _fireSpawner.rotation * GetRandomNess();
                    }
                }
        }
        }
    }
    

    private Quaternion GetRandomNess()
    {
        return Quaternion.Euler(RandomAngle(), RandomAngle(), 0);
    }
    private float RandomAngle() {return  UnityEngine.Random.Range(-_randomAngle, _randomAngle); }

    private void OnValidate()
    {
        if (_fireSpawner == null)
            _fireSpawner = transform;

    }
}
