using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipPanel;

    private bool isMouseOver;

    private void Start()
    {
        tooltipPanel.SetActive(false);
        isMouseOver = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        //UpdateTooltip();
        tooltipPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
        tooltipPanel.SetActive(false);
    }
}