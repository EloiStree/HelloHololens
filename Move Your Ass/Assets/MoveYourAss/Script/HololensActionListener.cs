using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HololensActionListener : MonoBehaviour, IInputHandler, ISpeechHandler
{
    public UnityEvent m_onClickDown;
    public UnityEvent m_onClickUp;

    public string [] m_listenToWords;
    public UnityEvent m_onOneWordRecognized;
    public string m_lastWord;
    public void OnInputDown(InputEventData eventData)
    {
        m_onClickDown.Invoke();
    }

    public void OnInputUp(InputEventData eventData)
    {
        m_onClickUp.Invoke();
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        m_lastWord = eventData.RecognizedText;
        for (int i = 0; i < m_listenToWords.Length; i++)
        {
            string word = m_listenToWords[i];
            if (word.ToLower() == eventData.RecognizedText.ToLower())
                m_onOneWordRecognized.Invoke();
        }
    }
}
