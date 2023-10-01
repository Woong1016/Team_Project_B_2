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
    private Rigidbody towerRigidbody; // Tower의 Rigidbody

    void Start()
    {
        towerRigidbody = GetComponent<Rigidbody>();
        towerRigidbody.isKinematic = true; // 외부 힘에 영향을 받지 않도록 설정
    }

    void Update()
    {
        FindNearestEnemy();

        if (target != null)
        {
            RotateTowardsEnemy();
        }

        if (target != null && Time.time > nextFireTime)
        {
            FireBullet();
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

    void RotateTowardsEnemy()
    {
        Vector3 directionToEnemy = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void FireBullet()
    {
        nextFireTime = Time.time + 1f / fireRate;

        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
 
        if (bulletScript != null)
        {
            bulletScript.launchDirection = gunTransform.forward;
            bulletScript.bulletSpeed = bulletSpeed; 
        }
    }
}