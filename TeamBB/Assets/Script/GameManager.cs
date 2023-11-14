using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ���� �Ŵ��� �ν��Ͻ�

    public TMP_Text moneyText;
    public int money = 0;

    private int attackDamage = 10;          // �ʱ� ���ݷ�
    private int attackDamageUpgradeCost = 50; // ���ݷ� ���׷��̵� ���
    private float attackSpeed = 1.0f;       // �ʱ� ���� �ӵ�
    private int attackSpeedUpgradeCost = 50; // ���� �ӵ� ���׷��̵� ���

    private int fbUpgradeCost = 250;        //�Ҵ� �ؾ ���

    public List<Tower> towers; // Ÿ�� ��ũ��Ʈ ���

    private void Awake()
    {
        // ���� �Ŵ��� �ν��Ͻ��� ����
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // �ٸ� �ν��Ͻ��� �ı�
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
        attackDamageUpgradeCost += 50; // ���׷��̵� ��� ����
    }

    public void DeductAttackSpeedUpgradeCost()
    {
        money -= attackSpeedUpgradeCost;
        attackSpeedUpgradeCost += 50; // ���׷��̵� ��� ����
    }

    public void DeductFBUpgradeCost()
    {
        money -= fbUpgradeCost;
        fbUpgradeCost += 50; // ���׷��̵� ��� ����
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
        return attackDamageUpgradeCost; // ���ݷ� ���׷��̵� ��� ��ȯ
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    public int GetAttackSpeedUpgradeCost()
    {
        return attackSpeedUpgradeCost; // ���� �ӵ� ���׷��̵� ��� ��ȯ
    }

    public int GetFBUpgradeCost()
    {
        return fbUpgradeCost; // ���� �ӵ� ���׷��̵� ��� ��ȯ
    }
}