using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamaEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    private bool m_isPlayerExit;
    public float displayDuration;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImgaeCanvasGroup;
    bool m_IsPlayerCatch;
    bool m_HasAudioPlayed;
    float m_Timer;
    public GameObject player;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isPlayerExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if( m_IsPlayerCatch)
        {
            EndLevel(caughtBackgroundImgaeCanvasGroup, true, caughtAudio);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_isPlayerExit = true;
        }
    }
    public void CaughtPlayer()
    {
        m_IsPlayerCatch = true;
    }
    void EndLevel( CanvasGroup imageCanvasGroup, bool doRestart , AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }    
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if(m_Timer > (fadeDuration + displayDuration))
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
