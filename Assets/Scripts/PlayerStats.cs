using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyDisplayText;
    [SerializeField] private TextMeshProUGUI LivesDisplayText;
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20; 

    private void Start () {
        Money = startMoney;
        MoneyDisplayText.SetText($"${Money}");

        Lives = startLives;
        LivesDisplayText.SetText($"Lives: {Lives}");
    }

    public void AddMoney(int MoneyToAdd) {
        Money += MoneyToAdd;
        MoneyDisplayText.SetText($"${Money}");
    }

    public int GetMoney() {
        return Money;
    }
}
