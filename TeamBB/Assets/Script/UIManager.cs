using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject UnitShopPanel;        // 유닛 구매 패널
    public GameObject ShopPanel;            // 상점 패널
    public GameObject Panel;            
    public TMP_Text attackDamageText;       // 공격력 텍스트
    public TMP_Text attackDamageUpgradeCostText;       // 공격력 비용 텍스트
    public TMP_Text attackSpeedText;        // 공격 속도 텍스트
    public TMP_Text attackSpeedUpgradeCostText;        // 공격 속도 비용 텍스트
    //public TMP_Text fbUpgradeCostText;        // 불닭 비용 텍스트
    //public TMP_Text nbUpgradeCostText;
    //public TMP_Text mbUpgradeCostText;


    private bool isShopPanelActive = false;
    private GameManager gameManager;

    void Start()
    {
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
        if (Panel.activeSelf)
        {
            // 상점 패널이 이미 활성화되어 있으면 끕니다.
            isShopPanelActive = false;
            UnitShopPanel.SetActive(false);
            ShopPanel.SetActive(false);
            Panel.SetActive(false);
        }
        else
        {
            // 상점 패널이 비활성화되어 있으면 켭니다.
            isShopPanelActive = true;
            UnitShopPanel.SetActive(true);
            Panel.SetActive(true);
        }
    }

    public void Shop_Button_Clicked()
    {
        ShopPanel.SetActive(true);
        isShopPanelActive = true;
        UnitShopPanel.SetActive(false);
    }

    public void UnitShopButton_Clicked()
    {
        UnitShopPanel.SetActive(true);
        isShopPanelActive = true;
        ShopPanel.SetActive(false);
    }


    public void ShopPanel_Close_Button()
    {
        ShopPanel.SetActive(false);
    }

    //public void UnitShop_Close_Button()
    //{
    //    UnitShopPanel.SetActive(false);
    //}

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
        attackSpeedText.text = "" + GameManager.instance.GetAttackSpeed();
        attackSpeedUpgradeCostText.text = "" + GameManager.instance.GetAttackSpeedUpgradeCost();

        attackDamageText.text = "" + GameManager.instance.GetAttackDamage();
        attackDamageUpgradeCostText.text = "" + GameManager.instance.GetAttackDamageUpgradeCost();

        //fbUpgradeCostText.text = "" + GameManager.instance.GetFBUpgradeCost();
        //nbUpgradeCostText.text = "" + GameManager.instance.GetNBUpgradeCost();
        //mbUpgradeCostText.text = "" + GameManager.instance.GetMBUpgradeCost();
    }
}