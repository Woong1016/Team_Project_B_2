using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform Ing;
    public float maxHealth = 60f; // 적의 최대 체력
    private float currentHealth;   // 현재 체력
    private readonly float initHp = 60f;

    public Canvas hpBarCanvas; // HPBar Canvas
    public Image hpBar;
    public int moneyValue = 10;

    void Start()
    {
        Ing = gameObject.transform.parent;
        currentHealth = initHp;

        DisplayHealth();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        DisplayHealth();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void DisplayHealth()
    {
        // hpBar가 null이 아니고 이미지가 활성화된 경우에만 표시
        if (hpBar != null && hpBar.gameObject.activeInHierarchy && currentHealth > 0)
        {
            // 직접 변경
            hpBar.fillAmount = currentHealth / maxHealth;
            // 디버그 문 추가
            Debug.Log("HP Bar Fill Amount: " + hpBar.fillAmount);
        }
        else if (hpBar != null)
        {
            hpBar.fillAmount = 0; // hp가 0이 되면 fillAmount를 0으로 설정하여 표시하지 않음
        }

        if (hpBar != null)
        {
            bool isActive = hpBar.gameObject.activeInHierarchy;
            Debug.Log("HP Bar Active in Hierarchy: " + isActive);
        }
    }

    public void Die()
    {
        GameManager.instance.MoneyIncrease(moneyValue);

        Destroy(Ing.gameObject);
        Destroy(gameObject);

        // hpBar가 null이 아닌 경우에만 파괴
        if (hpBar != null)
        {
            Destroy(hpBar.gameObject);
        }
    }
}