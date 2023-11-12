using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; // 탄환 프리팹
    public float bulletSpeed = 10f; // 탄환 속도
    public float fireRate = 1f;     // 발사 속도
    public Transform gunTransform;  // 포탑의 총구 위치
    public float attackRange = 50f; // 포탑의 공격 사거리
    public float rotationSpeed = 50f; // 포탑의 회전 속도
    public float baseDamage = 10f;   // 초기 공격력
    public float baseAttackSpeed = 1.0f; // 초기 공격 속도
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
            if (col.CompareTag("SpawnedObject"))
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
            bulletScript.damage = baseDamage; // 총알의 공격력 설정
            Quaternion rotatedRotation = gunTransform.rotation * Quaternion.Euler(0f, 180f, 0f);
            bulletScript.launchDirection = rotatedRotation * Vector3.forward;
            bulletScript.bulletSpeed = bulletSpeed;
        }
    }

    public void UpdateAttackInfo(float newDamage, float newAttackSpeed)
    {
        // 공격력 및 공격 속도 업데이트
        baseDamage = newDamage;
        baseAttackSpeed = newAttackSpeed;
        fireRate = newAttackSpeed; // 발사 속도를 공격 속도와 동일하게 설정
    }
}
