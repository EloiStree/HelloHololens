using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class PlatformSwitch : MonoBehaviour
{
    public bool m_isVR;
    public string[] m_devices;
    public bool hasVirtualRealityDevice = false;
    [Header("Awake")]
    public UnityEvent m_onEditor;
    public UnityEvent m_onAndroid;
    public UnityEvent m_onUWP;

    [Header("Awake VR")]
    public UnityEvent m_onEditorVR;
    public UnityEvent m_onAndroidVR;
    public UnityEvent m_onUWPVR;
    // Start is called before the first frame update
    void Awake()
    {
        m_isVR = XRSettings.isDeviceActive;
        m_devices = XRSettings.supportedDevices;
        for (int i = 0; i < XRSettings.supportedDevices.Length; i++)
        {
            if (!string.IsNullOrEmpty(XRSettings.supportedDevices[i]) && XRSettings.supportedDevices[i].ToLower().Trim()!="none") {
                hasVirtualRealityDevice = true;
                break;
            }
        }
        //if (false)
        {
            if ( hasVirtualRealityDevice)
            {
    #if UNITY_EDITOR
                m_onEditorVR.Invoke();
    #elif UNITY_WSA
                m_onAndroidVR.Invoke();
    #elif UNITY_ANDROID
                m_onUWPVR.Invoke();
    #endif
            }
            else {
    #if UNITY_EDITOR
                m_onEditor.Invoke();
    #elif UNITY_WSA
                m_onUWP.Invoke();
    #elif UNITY_ANDROID
                m_onAndroid.Invoke();
    #endif

        }
        }

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
