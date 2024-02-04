using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTestScript : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        ItemPlacement.OnMoneyChanged += UpdateMoney;
    }

    public void UpdateMoney(int newMoney)
    {
        moneyText.text = $"Money: {newMoney}";
    }
}
