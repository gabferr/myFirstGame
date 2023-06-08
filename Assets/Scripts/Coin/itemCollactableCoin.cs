using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollactableCoin : itemCollactableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        itemManager.Instance.AddCoins();
    }
}
