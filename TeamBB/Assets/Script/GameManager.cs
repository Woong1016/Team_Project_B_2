using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 게임 매니저 인스턴스

    public TMP_Text moneyText;
    private int money = 0;

    private void Awake()
    {
        // 게임 매니저 인스턴스를 설정
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 다른 인스턴스를 파괴
        }
    }

    public void MoneyIncrease(int amount)
    {
        money += amount;
        ShowInfo();
    }

    private void ShowInfo()
    {
        moneyText.text = " " + money;
    }
}