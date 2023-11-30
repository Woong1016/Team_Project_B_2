using UnityEngine;
using System.Collections.Generic;

public class ObjectPathController : MonoBehaviour
{
    public PathManager PathManager; // PathManager ��ũ��Ʈ�� ���� ���� ������Ʈ�� Inspector â���� �����ϼ���.
    private List<Vector3> currentPath;
    private int currentWaypointIndex = 0;
    public float originalMovementSpeed = 7.0f; // �ʱ� �̵� �ӵ� ����
    private float currentMovementSpeed; // ���� �̵� �ӵ�

    private void Start()
    {
        // PathManager���� ������ ��θ� �����ɴϴ�.
        currentPath = PathManager.GetRandomPath();

        if (currentPath != null && currentPath.Count > 0)
        {
            // �ʱ� ��ġ�� ù ��° ��������Ʈ�� ����
            transform.position = currentPath[0];
        }

        // �ʱ� �̵� �ӵ� ����
        currentMovementSpeed = originalMovementSpeed;
    }

    private void Update()
    {
        if (currentPath == null || currentPath.Count == 0)
            return;

        // ���� ��������Ʈ�� �̵��մϴ�.
        Vector3 targetPosition = currentPath[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentMovementSpeed * Time.deltaTime);

        // ��������Ʈ�� �ٶ󺸵��� ȸ��
        transform.LookAt(targetPosition);

        // ���� ��ġ�� ��ǥ ��ġ ���� �Ÿ��� ����մϴ�.
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // ���� �Ÿ�(��: 0.1f) ���Ϸ� ��������� ���� ��������Ʈ�� �̵��մϴ�.
        if (distanceToTarget < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= currentPath.Count)
            {
                // ��� ���� ������ ��� ��������Ʈ �ε����� �ʱ�ȭ�ϰ� �������� ����ϴ�.
                currentWaypointIndex = 0;
                // �������� ���߷��� �Ʒ� ������ �ּ� �����ϼ���.
                // currentMovementSpeed = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Ư�� ������Ʈ�� ��쿡 ���� �̵� �ӵ��� �����մϴ�.
        if (other.CompareTag("Mint"))
        {
            Debug.Log("��Ʈ ���");
            currentMovementSpeed = originalMovementSpeed * 2.0f; // �̵� �ӵ��� 1/8�� �����մϴ�.
        }
        else if (other.CompareTag("Mint1"))
        {
            Debug.Log("��Ʈ ���1");
            currentMovementSpeed = originalMovementSpeed * 0.1667f; // �̵� �ӵ��� 1/6�� �����մϴ�.
        }
        else if (other.CompareTag("Mint2"))
        {
            Debug.Log("��Ʈ ���2");
            currentMovementSpeed = originalMovementSpeed * 0.25f; // �̵� �ӵ��� 1/4�� �����մϴ�.
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // �浹�� ������Ʈ�� Ư�� ������Ʈ���� ����� ���� �̵� �ӵ��� ���ư�
        if (other.CompareTag("Mint") || other.CompareTag("Mint1") || other.CompareTag("Mint2"))
        {
            Debug.Log("��Ʈ ���");
            currentMovementSpeed = originalMovementSpeed;
        }
    }


}
