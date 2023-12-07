using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform Ing;
    public float maxHealth = 60f; // 적의 최대 체력
    private float currentHealth;   // 현재 체력
    private readonly float initHp = 60f;

    public Canvas hpBarCanvas; // HPBar Canvas
    public Image hpBar;
    public int moneyValue = 10;

    // 추가 변수: 데미지 감소 정도
    public float level1DamageMultiplier = 1f;
    public float level2DamageMultiplier = 3f;
    public float level3DamageMultiplier = 5f;

    void Start()
    {
        Ing = gameObject.transform.parent;
        currentHealth = initHp;

        DisplayHealth();
    }

    public void TakeDamage(float damage)
    {
        // 추가: 레벨에 따른 데미지 감소 적용
        if (gameObject.CompareTag("Nutella_LV1"))
        {
            damage *= level1DamageMultiplier;
        }
        else if (gameObject.CompareTag("Nutella_LV2"))
        {
            damage *= level2DamageMultiplier;
        }
        else if (gameObject.CompareTag("Nutella_LV3"))
        {
            damage *= level3DamageMultiplier;
        }

        currentHealth -= damage;
        DisplayHealth();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Update()
    {
        // ... (이전 코드는 그대로 유지)

        void Update()
        {
            // 추가: Nutella 태그를 가진 오브젝트인 경우에만 초마다 Hp 감소
            if (
                gameObject.CompareTag("Nutella_LV1") ||
                gameObject.CompareTag("Nutella_LV2") ||
                gameObject.CompareTag("Nutella_LV3"))
            {
                currentHealth -= Time.deltaTime;
                DisplayHealth();

                if (currentHealth <= 0)
                {
                    Die();
                }
            }
        }

        // ... (이후 코드는 그대로 유지)

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

        Destroy(gameObject);

        // hpBar가 null이 아닌 경우에만 파괴
        if (hpBar != null)
        {
            Destroy(hpBar.gameObject);
        }
    }
}
