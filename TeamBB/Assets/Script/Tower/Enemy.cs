using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform Ing;
    public float maxHealth = 60f; // ���� �ִ� ü��
    private float currentHealth;   // ���� ü��
    private readonly float initHp = 60f;

    public Canvas hpBarCanvas; // HPBar Canvas
    public Image hpBar;
    public int moneyValue = 10;

    // �߰� ����: ������ ���� ����
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
        // �߰�: ������ ���� ������ ���� ����
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
        // ... (���� �ڵ�� �״�� ����)

        void Update()
        {
            // �߰�: Nutella �±׸� ���� ������Ʈ�� ��쿡�� �ʸ��� Hp ����
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

        // ... (���� �ڵ�� �״�� ����)

    }

    void DisplayHealth()
    {
        // hpBar�� null�� �ƴϰ� �̹����� Ȱ��ȭ�� ��쿡�� ǥ��
        if (hpBar != null && hpBar.gameObject.activeInHierarchy && currentHealth > 0)
        {
            // ���� ����
            hpBar.fillAmount = currentHealth / maxHealth;
            // ����� �� �߰�
            Debug.Log("HP Bar Fill Amount: " + hpBar.fillAmount);
        }
        else if (hpBar != null)
        {
            hpBar.fillAmount = 0; // hp�� 0�� �Ǹ� fillAmount�� 0���� �����Ͽ� ǥ������ ����
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

        // hpBar�� null�� �ƴ� ��쿡�� �ı�
        if (hpBar != null)
        {
            Destroy(hpBar.gameObject);
        }
    }
}
