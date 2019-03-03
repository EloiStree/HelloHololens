using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidRestart : MonoBehaviour
{
    public static string m_callBackScene;
    public float m_timeToRelaunchScene= 1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindObjectsOfType<GameObject>();

        foreach (var obj in objs)
        {
            if (obj != this.gameObject)
                Destroy(obj);
        }
        //Debug.LogError("Hey test");
        Invoke("LoadNextScene", m_timeToRelaunchScene);
    }
    public int m_levelIndex;
    
    void LoadNextScene() {
        if( !string.IsNullOrWhiteSpace(m_callBackScene))
            SceneManager.LoadScene(m_callBackScene);
        else
            SceneManager.LoadScene(m_levelIndex);

    }
}
