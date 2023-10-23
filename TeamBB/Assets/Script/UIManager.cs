using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject Shop_UnitShopPanel;   // ������ ���� ���� �� �� �� �ִ� �г�
    public GameObject UnitShopPanel;        // ���� ���� �г�
    public GameObject ShopPanel;            // ���� �г�
    public TMP_Text attackDamageText;       // ���ݷ� �ؽ�Ʈ
    public TMP_Text attackSpeedText;        // ���� �ӵ� �ؽ�Ʈ

    private bool isShopPanelActive = false;
    private GameManager gameManager;

    void Start()
    {
        Shop_UnitShopPanel.SetActive(false);
        UnitShopPanel.SetActive(false);
        ShopPanel.SetActive(false);
        gameManager = GameManager.instance;
        UpdateUI();
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0) && isShopPanelActive)
    //    {
    //        CloseShopPanelOnOutsideClick();
    //    }
    //}

    public void ShopButton_Clicked()
    {
        Shop_UnitShopPanel.SetActive(true);
        isShopPanelActive = true;
    }

    public void Shop_Button_Clicked()
    {
        ShopPanel.SetActive(true);
        isShopPanelActive = true;
    }

    public void UnitShopButton_Clicked()
    {
        UnitShopPanel.SetActive(true);
        isShopPanelActive = true;
    }

    public void Close_Button()
    {
        Shop_UnitShopPanel.SetActive(false);
    }

    public void ShopPanel_Close_Button()
    {
        ShopPanel.SetActive(false);
    }

    public void UnitShop_Close_Button()
    {
        UnitShopPanel.SetActive(false);
    }

    public void UpgradeAttackDamage()
    {
        if (gameManager.CanUpgradeAttackDamage())
        {
            gameManager.UpgradeAttackDamage();
            UpdateUI();
        }
    }

    public void UpgradeAttackSpeed()
    {
        if (gameManager.CanUpgradeAttackSpeed())
        {
            gameManager.UpgradeAttackSpeed();
            UpdateUI();
        }
    }

    //private void CloseShopPanelOnOutsideClick()
    //{
    //    if (!EventSystem.current.IsPointerOverGameObject())
    //    {
    //        // ���콺�� UI ��� ������ Ŭ������ �ʾ��� �� �г� �ݱ�
    //        Shop_UnitShopPanel.SetActive(false);
    //        UnitShopPanel.SetActive(false);
    //        ShopPanel.SetActive(false);
    //        isShopPanelActive = false;
    //    }
    //}


    private void UpdateUI()
    {
        attackDamageText.text = "���ݷ�: " + GameManager.instance.GetAttackDamage() + "\n(��ȭ ���: " + GameManager.instance.GetAttackDamageUpgradeCost() + ")";

        attackSpeedText.text = "���� �ӵ�: " + GameManager.instance.GetAttackSpeed().ToString("F1") + "\n(��ȭ ���: " + GameManager.instance.GetAttackSpeedUpgradeCost() + ")";
    }
}
