using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<GameManager>();

            return m_instance;
        }

    }
    public enum eRSP
    {
        Rock = 0,
        Scissors,
        Paper,
        None
    }
    public eRSP m_cpu = eRSP.None;
    public eRSP m_player = eRSP.None;
    
    [SerializeField]
    TextMeshProUGUI m_resultText;
    [SerializeField]
    Sprite[] m_rspImg;
    [SerializeField]
    Image m_img;

    int m_win;
    int m_draw;
    int m_lose;
    
    public int Win => m_win;
    public int Lose => m_lose;

    


    public void PlayerRSP(eRSP rsp)
    {
        m_player = rsp;
    }
    public void CpuRSP()
    {
        m_cpu = (eRSP)Random.Range((int)eRSP.Rock, (int)eRSP.None);
    }
    public void Result()
    {
        
        switch (m_cpu)
        {
            case eRSP.Rock:
                StopCoroutine("CoChangeRSP");
                m_img.sprite = m_rspImg[0];
                if (m_player == eRSP.Paper)
                {
                    
                    Debug.Log("You Win!");
                    m_win++;
                }
                else if(m_player == eRSP.Scissors)
                {
                    Debug.Log("You Lose");
                    m_lose++;
                }
                else if(m_player == eRSP.Rock)
                {
                    Debug.Log("Draw");
                    m_draw++;
                }
                break;
            case eRSP.Scissors:
                StopCoroutine("CoChangeRSP");
                m_img.sprite = m_rspImg[1];
                
                if (m_player == eRSP.Rock)
                {
                    Debug.Log("You Win!");
                    m_win++;
                }
                else if (m_player == eRSP.Paper)
                {
                    Debug.Log("You Lose");
                    m_lose++;
                }
                else if (m_player == eRSP.Scissors)
                {
                    Debug.Log("Draw");
                    m_draw++;
                }
                break;
            case eRSP.Paper:
                StopCoroutine("CoChangeRSP");
                m_img.sprite = m_rspImg[2];
                
                if (m_player == eRSP.Scissors)
                {
                    Debug.Log("You Win!");
                    m_win++;
                }
                else if (m_player == eRSP.Rock)
                {
                    Debug.Log("You Lose");
                    m_lose++;
                }
                else if (m_player == eRSP.Paper)
                {
                    Debug.Log("Draw");
                    m_draw++;
                }
                break;

        }
        m_resultText.text = "Win : " + m_win + "  /  " + "Draw : " + m_draw + "  /  " + "Lose : " + m_lose;
    }
    IEnumerator CoChangeRSP()
    {
        while (true)
        {
            for (int i = 0; i < m_rspImg.Length; i++)
            {
                m_img.sprite = m_rspImg[i];
                yield return new WaitForSeconds(0.1f);
            }
            
        }
    }

}
