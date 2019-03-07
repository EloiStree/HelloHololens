using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperspaceObjectFactory : MonoBehaviour
{
    public OneMeshPool m_objectPool;
    public Transform m_spawnDirection;
    public Transform m_spawnCenter;
    public float m_maxRange=5;
    public float m_minTimeBetweenSpawn=0.1f;
    public float m_maxTimeBetweenSpawn=3f;

    public float m_minSize=1;
    public float m_maxSize=5;

    public float m_minSpeed=10;
    public float m_maxSpeed=30;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(UnityEngine.Random.Range(m_minTimeBetweenSpawn, m_maxTimeBetweenSpawn));
            Spawn();
        }
    }

    void Spawn()
    {
        PoolObject obj = GetRandomAsteroid();
        obj.transform.position = GetRandomPosition();
        obj.transform.rotation = m_spawnDirection.rotation;
        obj.transform.localScale = Vector3.one * GetRandomFloat(m_minSize, m_maxSize);
        MoveForward moveForward = obj.GetComponent<MoveForward>();
        if (moveForward == null)
        {
            moveForward =   obj.gameObject.AddComponent<MoveForward>();
            moveForward.m_affected = obj.transform;
        }
        moveForward.m_speed = GetRandomFloat(m_minSpeed, m_maxSpeed);
        obj.SetAsActive(true);
        
        
    }

    private float GetRandomFloat(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    private Vector3 GetRandomPosition()
    {
       return  m_spawnCenter.position + m_maxRange* new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }

    private PoolObject GetRandomAsteroid()
    {
        return m_objectPool.Next(true, true);
    }
}
