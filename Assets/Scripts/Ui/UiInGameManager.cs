using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFisrtGame.Core.Singleton;
using TMPro;

public class UiInGameManager : Singleton<UiInGameManager>
{
    
    public TextMeshProUGUI uiCoins;

    public void updateTextCoin(string s)
    {
        uiCoins.text = s;
    }
}
