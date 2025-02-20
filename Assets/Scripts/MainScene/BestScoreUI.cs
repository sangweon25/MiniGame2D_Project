using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreUI : BaseUI
{
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
     
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
    }

    protected override UIState GetUIState()
    {
        return UIState.EbestScoreUI;
    }

    public void ChangeBestScoreUIState()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        }
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
 
}
