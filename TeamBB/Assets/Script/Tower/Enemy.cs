using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform Ing;
    public float maxHealth = 60f;
    public float currentHealth;
    private readonly float initHp = 60f;

    public Canvas hpBarCanvas;
    public Image hpBar;
    public int moneyValue = 10;

    private bool isDamaging = false;

    // 추가: 다양한 레벨의 데미지 감소를 위한 변수들
    public float damageAmountLV1 = 5f;
    public float damageAmountLV2 = 10f;
    public float damageAmountLV3 = 15f;

    void Start()
    {
        Ing = gameObject.transform.parent;
        currentHealth = maxHealth;
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

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void DisplayHealth()
    {
        if (hpBar != null && hpBar.gameObject.activeInHierarchy && currentHealth > 0)
        {
            hpBar.fillAmount = currentHealth / maxHealth;
            Debug.Log("HP Bar Fill Amount: " + hpBar.fillAmount);
        }
        else if (hpBar != null)
        {
            hpBar.fillAmount = 0;
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

        if (hpBar != null)
        {
            Destroy(hpBar.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nutella_LV1"))
        {
            StartCoroutine(DealDamageRepeatedly(damageAmountLV1));
        }
        else if (other.CompareTag("Nutella_LV2"))
        {
            StartCoroutine(DealDamageRepeatedly(damageAmountLV2));
        }
        else if (other.CompareTag("Nutella_LV3"))
        {
            StartCoroutine(DealDamageRepeatedly(damageAmountLV3));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Nutella_LV1") || other.CompareTag("Nutella_LV2") || other.CompareTag("Nutella_LV3"))
        {
            StopCoroutine(DealDamageRepeatedly(0f));
        }
    }

    private IEnumerator DealDamageRepeatedly(float damageAmount)
    {
        while (currentHealth > 0)
        {
            DealDamage(damageAmount);
            yield return new WaitForSeconds(2f); // 예: 2초 간격으로 데미지 적용
        }
    }

    private void DealDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        DisplayHealth();
    }
}
