using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 launchDirection; // �߻� ���� ���� ����
    public float bulletSpeed = 10000f; // źȯ �ӵ�
    public float damage = 10f;      // źȯ�� ���ݷ�

    private void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = launchDirection * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Floor"))
        {
            //Debug.Log("�浹: " + other.gameObject.name);
            Destroy(gameObject);
        }
        else if (other.CompareTag("SpawnedObject"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                // ���ݷ¿� ���� ������ ������
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
