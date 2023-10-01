using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; // źȯ ������
    public float bulletSpeed = 10f; // źȯ �ӵ�
    public float fireRate = 1f;     // �߻� �ӵ�
    public Transform gunTransform;  // ��ž�� �ѱ� ��ġ
    public float attackRange = 10f; // ��ž�� ���� ��Ÿ�
    public float rotationSpeed = 10f; // ��ž�� ȸ�� �ӵ�
    private float nextFireTime;     // ���� �߻� �ð�
    private Transform target;       // ���� ���� ���
    private Rigidbody towerRigidbody; // Tower�� Rigidbody

    void Start()
    {
        towerRigidbody = GetComponent<Rigidbody>();
        towerRigidbody.isKinematic = true; // �ܺ� ���� ������ ���� �ʵ��� ����
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