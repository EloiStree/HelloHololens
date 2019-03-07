using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMissileOnHandClick : MonoBehaviour
{
    public GameObject m_missilePrefab;
    public MoveTowardGivenTarget m_missileToLaunch;
    public GameObject m_missilReadyVisual;
    public Transform m_missileSpawnPosition;
    public float m_spawnTime=3f;
    public bool m_missileReady;
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
        Invoke("SpawnNewMissile", m_spawnTime);
        m_missileToLaunch.Move();
        m_missileToLaunch.gameObject.SetActive(true);
        m_missileReady = false;
        TargetableByHololensFocus focus = TargetableByHololensFocus.GetLastFocused();
        if (focus)
        {
            m_missileToLaunch.m_target = focus.transform;
        }
    }
     void SpawnNewMissile()
    {
        GameObject missile = GameObject.Instantiate(m_missilePrefab, m_missileSpawnPosition.position, m_missileSpawnPosition.rotation);
        missile.transform.localScale = m_missileSpawnPosition.localScale;
        missile.transform.parent = m_missileSpawnPosition;
        m_missileToLaunch = missile.GetComponent<MoveTowardGivenTarget>();
        missile.SetActive(false);
        m_missileReady = true;
    }

    

}
