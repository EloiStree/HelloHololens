using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePrefab : MonoBehaviour {

    public GameObject _prefab;
    public Transform _where;
    public int _numberToGenerate=200;

    void Start () {
        if(_prefab && _where)
            for (int i = 0; i < _numberToGenerate; i++)
            {
                GameObject.Instantiate(_prefab,_where.position, _where.rotation);
            }
	}
	
}
