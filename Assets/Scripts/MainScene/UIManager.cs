using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    EbestScoreUI, ResultUI,
}

public class UIManager : MonoBehaviour
{
    BestScoreUI bestScoreUI;
    ResultUI resultUI;
    public BestScoreUI BestScoreUI { get { return bestScoreUI; } }
    public ResultUI ResultUI { get { return resultUI; } }

    private UIState currentState;

    private void Awake()
    {
        bestScoreUI = GetComponentInChildren<BestScoreUI>(true);
        resultUI = GetComponentInChildren<ResultUI>(true);
    }
    private void Start()
    {
   
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        bestScoreUI.SetActive(currentState);
        resultUI.SetActive(currentState);
    }



}
