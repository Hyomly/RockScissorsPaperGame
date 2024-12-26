using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEvent : MonoBehaviour
{
    int m_gameSet;
    bool m_isRestart = false;

    public int GameSet => m_gameSet;
    public bool IsRestart => m_isRestart;
    

    [SerializeField]
    Toggle m_oneToggle;    
    [SerializeField]
    Toggle m_threeToggle;
    [SerializeField]
    Toggle m_fiveToggle;
    [SerializeField]
    Toggle m_restartToggle;


    public void RestartCheck()
    {
        if (m_restartToggle.isOn)
            m_isRestart = true;
    }

    void IsOnCheck()
    {
        if (m_oneToggle.isOn)
            m_gameSet = 1;
        else if (m_threeToggle.isOn)
            m_gameSet = 3;
        else if (m_fiveToggle.isOn)
            m_gameSet = 5;
       
    }

    public void OnceSet(bool value)
    {
        if (value)
            m_gameSet = 1;
    }
    public void ThreeSet(bool value)
    {
        if (value)
            m_gameSet = 3;
    }
    public void FiveSet(bool value)
    {
        if (value)
            m_gameSet = 5;
    }
    private void Start()
    {
        IsOnCheck();

    }
    private void Update()
    {
        RestartCheck();
    }
}
