using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCameraView : MonoBehaviour
{
    public Transform m_border;
    public Camera m_linkedCamera;
    public float m_distance=0.5f;
    public bool useAntiCheat;

    [Header("Debug")]
    public float m_height;
    public float m_width;
    void Start()
    {
        UpdateScale();
    }

    private void UpdateScale()
    {
        if (useAntiCheat)
        {
            m_height = PlayerPrefs.GetFloat("CamHeight");
            m_width = PlayerPrefs.GetFloat("CamWidth");
            m_border.localScale = new Vector3(m_width, m_height, 1);

        }
    }

    void LateUpdate()
    {
        Refresh();
    }

    private void Refresh()
    {
        Camera cam = m_linkedCamera == null ? Camera.main : m_linkedCamera;
        if (cam == null)
            return;
        m_border.rotation = cam.transform.rotation;
        Vector3 botLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, m_distance));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, m_distance));
        Vector3 center = (botLeft + topRight) / 2f;
        m_border.position = cam.transform.position + cam.transform.forward * m_distance;
        Debug.DrawLine(botLeft, topRight, Color.green); Vector3 localBotLeft = cam.transform.InverseTransformPoint(botLeft);
        Vector3 localTopRight = cam.transform.InverseTransformPoint(topRight);
        float height = Mathf.Abs(localBotLeft.y - localTopRight.y);
        float width = Mathf.Abs(localBotLeft.x - localTopRight.x);
        if (useAntiCheat)
        {
            if (PlayerPrefs.GetFloat("CamHeight") == 0f)
            {

                PlayerPrefs.SetFloat("CamHeight", height);
                PlayerPrefs.SetFloat("CamWidth", width);
                UpdateScale();
            }

        }
        else {
            m_height = height;
            m_width = width;
            m_border.localScale = new Vector3(m_width, m_height, 1);
        }

    }
    public void OnValidate()
    {
        Refresh();
    }
}
