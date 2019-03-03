using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class LaunchMissileOnHandClick : MonoBehaviour
{
    public GameObject m_missilePrefab;
    public MoveTowardGivenTarget m_missileToLaunch;
    public Transform m_missileSpawnPosition;
    public float m_spawnTime=3f;
    public void Start()
    {
        SpawnNewMissile();
    }
  
    private void Update()
    {

        //Debug
        if (Input.GetMouseButtonDown(2)  || Input.GetKeyDown(KeyCode.Space))
            LaunchMissileOnTarget();
        
    }
    public void LaunchMissileOnTarget()
    {
        if (!m_missileToLaunch)
            return;
        m_missileToLaunch.Move();
        TargetableByHololensFocus focus = TargetableByHololensFocus.GetLastFocused();
        if (focus)
        {
            m_missileToLaunch.m_target = focus.transform;
        }
        Invoke("SpawnNewMissile", m_spawnTime);
    }
     void SpawnNewMissile()
    {
        GameObject missile = GameObject.Instantiate(m_missilePrefab, m_missileSpawnPosition.position, m_missileSpawnPosition.rotation);
        missile.transform.localScale = m_missileSpawnPosition.localScale;
        missile.transform.parent = m_missileSpawnPosition;
        m_missileToLaunch = missile.GetComponent<MoveTowardGivenTarget>();
    }

    

}
