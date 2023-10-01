using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 launchDirection; // 발사 방향 벡터
    public float bulletSpeed = 30f; // 탄환 속도

    private void Start()
    {
        // 탄환에 속도 설정
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



