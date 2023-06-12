using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFisrtGame.Core.Singleton;

public class itemManager : Singleton<itemManager> 
{
    public int coins;

    private void Start()
    {
        Reset();
    }
    public void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
    }
}
