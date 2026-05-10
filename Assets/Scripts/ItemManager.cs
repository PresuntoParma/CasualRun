using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;


    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int ammount = 1)
    {
        coins.value += ammount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //UIInGameManager.Instance.UpdateCoins(coins.value.ToString());
    }

}
