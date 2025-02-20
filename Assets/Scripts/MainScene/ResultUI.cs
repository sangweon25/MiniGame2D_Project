using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : BaseUI
{
    public TextMeshProUGUI newBestScoreText;
    public TextMeshProUGUI challangeText;

    protected override UIState GetUIState()
    {
        return UIState.ResultUI;
    }
    void Start()
    {
        int newBest = PlayerPrefs.GetInt("NewBestScore");
        if (newBest == 1)
        {
            newBestScoreText.gameObject.SetActive(true);
        }
        else if(newBest == 2)
        {
            challangeText.gameObject.SetActive(true);
        }
    }

    public void CloseResultUI()
    {
        this.gameObject.SetActive(false);
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }

    void Update()
    {
        
    }
}
