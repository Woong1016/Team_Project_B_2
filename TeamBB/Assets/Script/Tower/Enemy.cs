using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform Ing;
    public float maxHealth = 60f; // ���� �ִ� ü��
    private float currentHealth;   // ���� ü��
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

        Destroy(Ing.gameObject);
        Destroy(gameObject);

        // hpBar�� null�� �ƴ� ��쿡�� �ı�
        if (hpBar != null)
        {
            Destroy(hpBar.gameObject);
        }
    }
}