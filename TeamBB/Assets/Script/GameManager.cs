using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 게임 매니저 인스턴스

    public TMP_Text moneyText;
    public int money = 0;

    private int attackDamage = 10;          // 초기 공격력
    private int attackDamageUpgradeCost = 50; // 공격력 업그레이드 비용
    private float attackSpeed = 1.0f;       // 초기 공격 속도
    private int attackSpeedUpgradeCost = 50; // 공격 속도 업그레이드 비용

    private int fbUpgradeCost = 250;        //불닭 붕어빵 비용

    public List<Tower> towers; // 타워 스크립트 목록

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

    public void DeductMoney(int amount)
    {
        money -= amount;
        ShowInfo();
    }

    public int GetMoney()
    {
        return money;
    }

    public bool CanUpgradeAttackDamage()
    {
        return attackDamageUpgradeCost <= money;
    }

    public bool CanUpgradeAttackSpeed()
    {
        return attackSpeedUpgradeCost <= money;
    }

    public bool CanFBUpgrade()
    {
        return fbUpgradeCost <= money;
    }

    public void DeductAttackDamageUpgradeCost()
    {
        money -= attackDamageUpgradeCost;
        attackDamageUpgradeCost += 50; // 업그레이드 비용 증가
    }

    public void DeductAttackSpeedUpgradeCost()
    {
        money -= attackSpeedUpgradeCost;
        attackSpeedUpgradeCost += 50; // 업그레이드 비용 증가
    }

    public void DeductFBUpgradeCost()
    {
        money -= fbUpgradeCost;
        fbUpgradeCost += 50; // 업그레이드 비용 증가
    }

    private void ShowInfo()
    {
        moneyText.text = " " + money;
    }

    public void UpgradeAttackDamage()
    {
        if (CanUpgradeAttackDamage())
        {
            attackDamage += 10;
            DeductAttackDamageUpgradeCost();
            ShowInfo();
            foreach (var tower in towers)
            {
                tower.UpdateAttackInfo(attackDamage, attackSpeed);
            }
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (CanUpgradeAttackSpeed())
        {
            attackSpeed += 0.1f;
            DeductAttackSpeedUpgradeCost();
            ShowInfo();
            foreach (var tower in towers)
            {
                tower.UpdateAttackInfo(attackDamage, attackSpeed);
            }
        }
    }

    public int GetAttackDamage()
    {
        return attackDamage;
    }

    public int GetAttackDamageUpgradeCost()
    {
        return attackDamageUpgradeCost; // 공격력 업그레이드 비용 반환
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public int GetAttackSpeedUpgradeCost()
    {
        return attackSpeedUpgradeCost; // 공격 속도 업그레이드 비용 반환
    }

    public int GetFBUpgradeCost()
    {
        return fbUpgradeCost; // 공격 속도 업그레이드 비용 반환
    }
}