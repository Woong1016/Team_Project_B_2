using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject UnitShopPanel;        // ���� ���� �г�
    public GameObject ShopPanel;            // ���� �г�
    public GameObject Panel;            
    public TMP_Text attackDamageText;       // ���ݷ� �ؽ�Ʈ
    public TMP_Text attackDamageUpgradeCostText;       // ���ݷ� ��� �ؽ�Ʈ
    public TMP_Text attackSpeedText;        // ���� �ӵ� �ؽ�Ʈ
    public TMP_Text attackSpeedUpgradeCostText;        // ���� �ӵ� ��� �ؽ�Ʈ
    //public TMP_Text fbUpgradeCostText;        // �Ҵ� ��� �ؽ�Ʈ
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
            // ���� �г��� �̹� Ȱ��ȭ�Ǿ� ������ ���ϴ�.
            isShopPanelActive = false;
            UnitShopPanel.SetActive(false);
            ShopPanel.SetActive(false);
            Panel.SetActive(false);
        }
        else
        {
            // ���� �г��� ��Ȱ��ȭ�Ǿ� ������ �մϴ�.
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
    //        // ���콺�� UI ��� ������ Ŭ������ �ʾ��� �� �г� �ݱ�
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