using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    public Material m_fadeMaterial;
    public float m_fadeState=1f;
    public enum FadeWanted { Transparent , Opaque}
    public FadeWanted m_fadeWanted = FadeWanted.Transparent;
    public float m_fadeSpeed = 0.5f;

    public string m_nextScene;
    public UnityEvent m_onRequestNextScene;
    public UnityEvent m_onImmediatSceneLoading;

    void Start()
    {
        SetAlphatTo(1f);

    }
    
    void Update()
    {
        if (m_fadeState <= 1f && m_fadeWanted == FadeWanted.Opaque)
        {
            m_fadeState += Time.deltaTime * m_fadeSpeed;
            m_fadeState = Mathf.Clamp(m_fadeState, 0f, 1f);
            SetAlphatTo(m_fadeState);
        }
        if (m_fadeState >= 0f && m_fadeWanted == FadeWanted.Transparent)
        {
            m_fadeState -= Time.deltaTime * m_fadeSpeed;
            m_fadeState = Mathf.Clamp(m_fadeState, 0f, 1f);
            SetAlphatTo(m_fadeState);
        }

    }

    public void SetNameOfSceneToLoad(string name) {
        m_nextScene = name;
    }
    private void SetAlphatTo(float alpha)
    {
        m_fadeMaterial.color = new Color(0, 0, 0, alpha);
    }
    public void RestartOrLoadLevel(float time=2)
    {
        m_onRequestNextScene.Invoke();
        FadeOut();
        Invoke("RestartOrLoadLevelDirectly", time);
    }

    public void RestartOrLoadLevelDirectly()
    {
        VoidRestart.m_callBackScene = SceneManager.GetActiveScene().name;
        m_onImmediatSceneLoading.Invoke();
        if(!string.IsNullOrEmpty(m_nextScene))
            SceneManager.LoadScene(m_nextScene);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public static void RestartOrLoadLevelFromManagerTheScene(float time = 2)
    {
        SceneLoaderManager manager = GameObject.FindObjectOfType<SceneLoaderManager>();
        if (manager != null)
            manager.RestartOrLoadLevel(time);
    }

    public void FadeOut() {
        m_fadeWanted = FadeWanted.Opaque;
    }
    public static void FadeOutFromManagerTheScene() {
        SceneLoaderManager manager = GameObject.FindObjectOfType<SceneLoaderManager>();
        if (manager != null)
            manager.FadeOut();
    }
}
