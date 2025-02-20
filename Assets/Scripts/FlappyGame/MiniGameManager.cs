using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    //미니게임 매니저를 싱글톤으로 만듬.
    static MiniGameManager miniGameManager;
    public static MiniGameManager Instance { get { return miniGameManager; } }

    //게임매니저를 가지고 있는 클래스에서 UI 클래스를 가져가 쓰기위함.
    MiniGameUIManager miniGameUIManager;
    public MiniGameUIManager MiniGameUIManager { get { return miniGameUIManager; } }

    //현재 스코어 변수
    private int currentScore = 0;
    private int bestScore = 0;

    private const string BestScoreKey = "BestScore";
    private const string NewBestScoreKey = "NewBestScore";

    private void Awake()
    {
        //static인 인스턴스
        miniGameManager = this;
        //씬에서 UIManager 찾기
        miniGameUIManager = FindObjectOfType<MiniGameUIManager>();
    }

    void Start()
    {
        //gameManager가 생성되면 score UI를 0으로 리셋
        miniGameUIManager.UpdateScoreToUI(0);
        bestScore = PlayerPrefs.GetInt(BestScoreKey);
        miniGameUIManager.UpdateBestScoreToUI(bestScore);
        PlayerPrefs.SetInt(NewBestScoreKey, 2);
        Time.timeScale = 0;
    }

    public void AddScore(int score)
    {
        //플레이어가 장애물을 통과할때마다 score가 증가하고 UI에도 반영
        currentScore += score;
        miniGameUIManager.UpdateScoreToUI(currentScore);
        PlayerPrefs.SetInt(NewBestScoreKey, 2);

        if(currentScore > bestScore)
        {
            bestScore = currentScore;
            miniGameUIManager.UpdateBestScoreToUI(bestScore);
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
            PlayerPrefs.SetInt(NewBestScoreKey, 1);
        }
    }
    public void QuitText()
    {
        miniGameUIManager.QuitText();
    }

    public void Quit_MiniGame()
    {
        //미니게임 종료하고 메인씬으로
        SceneManager.LoadScene("MainScene");
    }
 
}
