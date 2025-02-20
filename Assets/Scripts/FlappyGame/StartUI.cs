using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{

    private void Start()
    {
        this.gameObject.SetActive(true);
    }
    public void GameStart()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }
}
