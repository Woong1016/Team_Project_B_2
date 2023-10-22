using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 launchDirection; // 발사 방향 벡터 선언
    public float bulletSpeed = 10000f; // 탄환 속도
    public float damage = 10f;      // 탄환의 공격력

    private void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = launchDirection * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Floor"))
        {
            //Debug.Log("충돌: " + other.gameObject.name);
            Destroy(gameObject);
        }
        else if (other.CompareTag("SpawnedObject"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                // 공격력에 따라 데미지 입히기
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
