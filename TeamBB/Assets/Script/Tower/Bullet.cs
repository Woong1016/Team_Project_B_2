using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 launchDirection; // �߻� ���� ����
    public float bulletSpeed = 30f; // źȯ �ӵ�

    private void Start()
    {
        // źȯ�� �ӵ� ����
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = launchDirection * bulletSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(10f); 
            }

            Destroy(gameObject);
        }
    }
}



