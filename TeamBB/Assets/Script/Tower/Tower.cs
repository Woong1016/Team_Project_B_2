using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab; // źȯ ������
    public float bulletSpeed = 10f; // źȯ �ӵ�
    public float fireRate = 1f;     // �߻� �ӵ�
    public Transform gunTransform;  // ��ž�� �ѱ� ��ġ
    public float attackRange = 50f; // ��ž�� ���� ��Ÿ�
    public float rotationSpeed = 50f; // ��ž�� ȸ�� �ӵ�
    public float baseDamage = 10f;   // �ʱ� ���ݷ�
    public float baseAttackSpeed = 1.0f; // �ʱ� ���� �ӵ�
    private float nextFireTime;     // ���� �߻� �ð�
    private Transform target;       // ���� ���� ���

    void Update()
    {
        FindNearestEnemy();

        if (target != null)
        {
            // ��ž�� �� ���� �ٶ󺸵��� ȸ��
            Vector3 directionToEnemy = target.position - transform.position;
            directionToEnemy.y = 0f; // ���� ����(Y ��) ȸ���� �����Ͽ� ���� ���⸸ ���
            Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);

            // Y �� ȸ���� 180���� ����
            targetRotation *= Quaternion.Euler(0f, 180f, 0f);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // ���� źȯ�� �߻��� �� �ִ� �����̸� �߻�
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
            bulletScript.damage = baseDamage; // �Ѿ��� ���ݷ� ����
            Quaternion rotatedRotation = gunTransform.rotation * Quaternion.Euler(0f, 180f, 0f);
            bulletScript.launchDirection = rotatedRotation * Vector3.forward;
            bulletScript.bulletSpeed = bulletSpeed;
        }
    }

    public void UpdateAttackInfo(float newDamage, float newAttackSpeed)
    {
        // ���ݷ� �� ���� �ӵ� ������Ʈ
        baseDamage = newDamage;
        baseAttackSpeed = newAttackSpeed;
        fireRate = newAttackSpeed; // �߻� �ӵ��� ���� �ӵ��� �����ϰ� ����
    }
}
