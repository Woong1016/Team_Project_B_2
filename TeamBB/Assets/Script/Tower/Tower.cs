using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; // 탄환 프리팹
    public float bulletSpeed = 10f; // 탄환 속도
    public float fireRate = 1f;     // 발사 속도
    public Transform gunTransform;  // 포탑의 총구 위치
    public float attackRange = 10f; // 포탑의 공격 사거리
    public float rotationSpeed = 10f; // 포탑의 회전 속도
    private float nextFireTime;     // 다음 발사 시간
    private Transform target;       // 현재 공격 대상

    void Update()
    {
        FindNearestEnemy();

        if (target != null)
        {
            // 포탑이 적 쪽을 바라보도록 회전
            Vector3 directionToEnemy = target.position - transform.position;
            directionToEnemy.y = 0f; // 수직 방향(Y 축) 회전을 제거하여 수평 방향만 고려
            Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);

            // Y 축 회전을 180도로 변경
            targetRotation *= Quaternion.Euler(0f, 180f, 0f);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 만약 탄환을 발사할 수 있는 상태이면 발사
            if (Time.time > nextFireTime)
            {
                FireBullet();
            }
        }
    }

    void FindNearestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);

        float nearestDistance = float.MaxValue;
        Transform nearestEnemy = null;

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = col.transform;
                }
            }
        }

        target = nearestEnemy;
    }

    void FireBullet()
    {
        nextFireTime = Time.time + 1f / fireRate;

        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            // 총구의 방향을 Y 축 180도 회전
            Quaternion rotatedRotation = gunTransform.rotation * Quaternion.Euler(0f, 180f, 0f);

            // 탄환의 방향을 총구의 회전 방향으로 설정
            bulletScript.launchDirection = rotatedRotation * Vector3.forward; // 회전된 방향을 곱하여 설정
            bulletScript.bulletSpeed = bulletSpeed;
        }
    }

}
