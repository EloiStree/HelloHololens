using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class TargetableByHololensFocus :MonoBehaviour, IFocusable
{
     static TargetableByHololensFocus m_lastTarget;
     static List<TargetableByHololensFocus> m_targetsFocus = new List<TargetableByHololensFocus> ();

    public static TargetableByHololensFocus GetLastFocused() { return m_lastTarget; }
    public static List<TargetableByHololensFocus> GetAllFocused() { return m_targetsFocus; }

    public bool m_useDebugColor;

    public void OnFocusEnter()
    {
        m_lastTarget = this;
        m_targetsFocus.Add(this);
        if(m_useDebugColor)
            GetComponentInChildren<Renderer>().material.color = Color.green;
    }

    public void OnFocusExit()
    {

        m_lastTarget = null;
        m_targetsFocus.Remove(this);
        if (m_useDebugColor)
            GetComponentInChildren<Renderer>().material.color = Color.white;
    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(TargetableByHololensFocus))]
public class TargetableByHololensFocusEditor : Editor
{
    public Object source;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (TargetableByHololensFocus.GetLastFocused())
        {
            GUILayout.Label("Last Focus");
            EditorGUILayout.BeginHorizontal();
            source = EditorGUILayout.ObjectField(TargetableByHololensFocus.GetLastFocused(), typeof(Object), true);
            EditorGUILayout.EndHorizontal();

        }
        if (TargetableByHololensFocus.GetAllFocused().Count>0)
        {
            GUILayout.Label("Focused");
            foreach (var item in TargetableByHololensFocus.GetAllFocused())
            {
            EditorGUILayout.BeginHorizontal();
            source = EditorGUILayout.ObjectField(item, typeof(Object), true);
            EditorGUILayout.EndHorizontal();

            }

        }

    }
}

#endif
