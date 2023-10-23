using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Ing;
    public float maxHealth = 50f; // 적의 최대 체력
    private float currentHealth;   // 현재 체력

    public int moneyValue = 10;

    private void Start()
    {
        Ing = gameObject.transform.parent;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameManager.instance.MoneyIncrease(moneyValue);

        Destroy(Ing.gameObject);
        Destroy(gameObject);

    }
}
