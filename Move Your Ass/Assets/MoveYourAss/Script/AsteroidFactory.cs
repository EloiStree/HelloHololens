using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory : MonoBehaviour
{
    public Transform m_spawnDirection;
    public Transform m_spawnCenter;
    public float m_maxRange=5;
    public GameObject[] m_prefabs;
    public float m_minTimeBetweenSpawn=0.1f;
    public float m_maxTimeBetweenSpawn=3f;

    public float m_minSize=1;
    public float m_maxSize=5;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(UnityEngine.Random.Range(m_minTimeBetweenSpawn, m_maxTimeBetweenSpawn));
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject asteroid =  GameObject.Instantiate(GetRandomAsteroid(), GetRandomPosition(), m_spawnDirection.rotation);
        asteroid.transform.localScale = Vector3.one * GetRandomFloat(m_minSize, m_maxSize);
        
    }

    private float GetRandomFloat(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    private Vector3 GetRandomPosition()
    {
       return  m_spawnCenter.position + m_maxRange* new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }

    private GameObject GetRandomAsteroid()
    {
        return m_prefabs[UnityEngine.Random.Range(0, m_prefabs.Length)];
    }
}
