using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI quitText;
    void Start()
    {
        if (scoreText == null)
            Debug.LogError("scoreText is null");
        if (bestScoreText == null)
            Debug.LogError("bestScoreText is null");
        if (quitText == null)
            Debug.LogError("quitText is null");

        scoreText.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        quitText.gameObject.SetActive(false);
    }
    public void UpdateScoreToUI(int score)
    {
        scoreText.text = score.ToString();
    }
    public void UpdateBestScoreToUI(int score)
    {
        bestScoreText.text = score.ToString();
    }


    public void QuitText()
    {
        quitText.gameObject.SetActive(true);
    }
}
