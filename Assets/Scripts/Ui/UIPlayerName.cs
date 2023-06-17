using MyFisrtGame.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerName : MonoBehaviour
{
    public class UiInGameManager : Singleton<UiInGameManager>
    {

        public TextMeshProUGUI uiPlayerName;

        public void updateTextCoin(string s)
        {
            uiPlayerName.text = s;
        }
    }
}
