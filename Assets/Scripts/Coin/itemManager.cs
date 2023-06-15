using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyFisrtGame.Core.Singleton;

public class itemManager : Singleton<itemManager> 
{
    public SOint coins;
    public TextMeshProUGUI uiCoins;

    private void Start()
    {
        Reset();
    }
    public void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        updateUI();
    }
    private void updateUI()
    {
        //uiCoins.text = coins.ToString();
        //UiInGameManager.Instance.updateTextCoin(coins.value.ToString());
    }
}
