using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonEvent : MonoBehaviour
{

    [SerializeField]
    private Button m_startbtn;
    [SerializeField]
    private Button m_rock;
    [SerializeField]
    private Button m_sciccers;
    [SerializeField]
    private Button m_paper;
    [SerializeField]
    private Button m_restart;    
    [SerializeField]
    TextMeshProUGUI m_result;
    [SerializeField]
    ToggleEvent m_gameSet;    
    [SerializeField]
    GameObject m_resultPop;
    [SerializeField]
    Button m_restartBtn;

    int m_count = 0;
    bool m_isGameStart = false;

    public void GameOverPopup()
    {

        if (m_count == m_gameSet.GameSet)
        {
            if (GameManager.Instance.Win > GameManager.Instance.Lose)
                m_result.text = "YOU WIN";
            else if (GameManager.Instance.Win < GameManager.Instance.Lose)
                m_result.text = "YOU LOSE";
            else if (GameManager.Instance.Win == GameManager.Instance.Lose)
                m_result.text = "DRAW";
            m_resultPop.SetActive(true);
            if (m_gameSet.IsRestart)
            {
                m_restartBtn.gameObject.SetActive(true);
            }
            else
            {
                m_restartBtn.gameObject.SetActive(false);
                Invoke("ExitGame", 3f);
            }
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnClickStart()
    {
        GameManager.Instance.StartCoroutine("CoChangeRSP");
        m_isGameStart = true;
    }

    public void OnClickRock()
    {
        if(m_isGameStart)
        {
            GameManager.Instance.PlayerRSP(GameManager.eRSP.Rock);
            GameManager.Instance.CpuRSP();
            GameManager.Instance.Result();
            m_count++;
            GameOverPopup();
        }
        
    }
    public void OnClickScissors()
    {
        if (m_isGameStart)
        {
            GameManager.Instance.PlayerRSP(GameManager.eRSP.Scissors);
            GameManager.Instance.CpuRSP();
            GameManager.Instance.Result();
            m_count++;
            GameOverPopup();
        }
        
    }
    
    public void OnClickPaper()
    {
        if(m_isGameStart)
        {
            GameManager.Instance.PlayerRSP(GameManager.eRSP.Paper);
            GameManager.Instance.CpuRSP();
            GameManager.Instance.Result();
            m_count++;
            GameOverPopup();
        }        
    }
    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void Awake()
    {
        m_resultPop.SetActive(false);        
    }
    // Start is called before the first frame update
    void Start()
    {
        m_startbtn.onClick.AddListener(OnClickStart);
        m_rock.onClick.AddListener(OnClickRock);
        m_sciccers.onClick.AddListener(OnClickScissors);
        m_paper.onClick.AddListener(OnClickPaper);
        m_restart.onClick.AddListener(Restart);
       
    }

    
}
