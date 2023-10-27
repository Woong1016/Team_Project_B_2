using UnityEngine;
using System.Collections.Generic;

public class ObjectPathController : MonoBehaviour
{
    public PathManager PathManager; // PathManager ��ũ��Ʈ�� ���� ���� ������Ʈ�� Inspector â���� �����ϼ���.
    private List<Vector3> currentPath;
    private int currentWaypointIndex = 0;
    public float movementSpeed = 7.0f; // ������ �ӵ� ����

    private void Start()
    {
        // PathManager���� ������ ��θ� �����ɴϴ�.
        currentPath = PathManager.GetRandomPath();

        if (currentPath != null && currentPath.Count > 0)
        {
            // �ʱ� ��ġ�� ù ��° ��������Ʈ�� ����
            transform.position = currentPath[0];
        }
    }

    private void Update()
    {
        if (currentPath == null || currentPath.Count == 0)
            return;

        // ���� ��������Ʈ�� �̵��մϴ�.
        Vector3 targetPosition = currentPath[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

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
                movementSpeed = 0.0f;
            }
        }
    }
}