using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    [SerializeField] private TextMeshProUGUI MoneyDisplayText;
    [SerializeField] private TextMeshProUGUI LivesDisplayText;
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20; 

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
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

    public void DecrementLives() {
    if (Lives > 0) {
        Lives--;
        LivesDisplayText.SetText($"Lives: {Lives}");
    }

    if (Lives <= 0) {
        Debug.Log("Game Over!");
        // Add game-over logic here, such as pausing the game or showing a game-over screen.
    }
}
}
