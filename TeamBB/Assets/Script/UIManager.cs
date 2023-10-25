using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject Shop_UnitShopPanel;   // 상점과 유닛 구매 중 고를 수 있는 패널
    public GameObject UnitShopPanel;        // 유닛 구매 패널
    public GameObject ShopPanel;            // 상점 패널
    public TMP_Text attackDamageText;       // 공격력 텍스트
    public TMP_Text attackSpeedText;        // 공격 속도 텍스트

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
    //        // 마우스가 UI 요소 위에서 클릭되지 않았을 때 패널 닫기
    //        Shop_UnitShopPanel.SetActive(false);
    //        UnitShopPanel.SetActive(false);
    //        ShopPanel.SetActive(false);
    //        isShopPanelActive = false;
    //    }
    //}


    private void UpdateUI()
    {
        attackDamageText.text = "공격력: " + GameManager.instance.GetAttackDamage() + "\n(강화 비용: " + GameManager.instance.GetAttackDamageUpgradeCost() + ")";

        attackSpeedText.text = "공격 속도: " + GameManager.instance.GetAttackSpeed().ToString("F1") + "\n(강화 비용: " + GameManager.instance.GetAttackSpeedUpgradeCost() + ")";
    }
}
