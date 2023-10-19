using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Shop_UnitShopPanel;   // 상점과 유닛 구매 중 고를 수 있는 패널
    public GameObject UnitShopPanel;        // 유닛 구매 패널
    public GameObject ShopPanel;            // 상점 패널

    private bool isShopPanelActive = false; 

    void Start()
    {
        Shop_UnitShopPanel.SetActive(false);
        UnitShopPanel.SetActive(false);
        ShopPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isShopPanelActive)
        {
            CloseShopPanelOnOutsideClick();
        }
    }

    public void ShopButton_Clicked()
    {
        Shop_UnitShopPanel.SetActive(true);         //상점과 유닛 구매 버튼이 있는 패널 활성화
        isShopPanelActive = true; 
    }

    public void UnitShopButton_Clicked()
    {
        UnitShopPanel.SetActive(true);              //유닛 구매 버튼이 있는 패널 활성화
        isShopPanelActive = true; 
    }

    public void Shop_Button_Clicked()
    {
        ShopPanel.SetActive(true);                  //상점 패널 활성화
        isShopPanelActive = true; 
    }

    void CloseShopPanelOnOutsideClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject != ShopPanel)
            {
                // 마우스 클릭 위치가 상점 패널 바깥이면 패널을 닫음
                Shop_UnitShopPanel.SetActive(false);
                UnitShopPanel.SetActive(false);
                ShopPanel.SetActive(false);

                isShopPanelActive = false; // 패널이 닫힐 때 상태 업데이트
            }
        }
    }
}
