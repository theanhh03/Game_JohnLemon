using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgame : MonoBehaviour
{
    public float imgDuration = 1f;
    public float fadeDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBgrd;
    public CanvasGroup caughtBgrd;

    float m_Timer;
    bool m_IsAtExit;
    bool m_IsCaught;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsAtExit = true;
        }
    }
    public void CaughtPlayer()
    {
        m_IsCaught = true;
    }
    void Update()
    {
        if (m_IsAtExit)
        {
            EndLevel(exitBgrd, false);
        }
        else if (m_IsCaught)
        {
            EndLevel(caughtBgrd, true);
        }
    } 
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;
        exitBgrd.alpha = m_Timer / fadeDuration;
        if(m_Timer > fadeDuration + imgDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
