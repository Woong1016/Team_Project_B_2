using UnityEngine;
using System.Collections.Generic;

public class ObjectPathController : MonoBehaviour
{
    public PathManager PathManager; // PathManager ��ũ��Ʈ�� ���� ���� ������Ʈ�� Inspector â���� �����ϼ���.
    public string slowDownObjectName = "Mint_LV1"; // Ư�� ������Ʈ�� �̸�
    private List<Vector3> currentPath;
    private int currentWaypointIndex = 0;
    public float normalMovementSpeed = 7.0f; // ���� �̵� �ӵ� ����
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
        currentMovementSpeed = normalMovementSpeed;
    }

    private void Update()
    {
        Debug.Log("Update called");

        if (currentPath == null || currentPath.Count == 0)
            return;
        Debug.Log("Path available");

        // Ư�� ������Ʈ�� �̸��� Mint_LV1���� Ȯ��
        if (gameObject.name == slowDownObjectName)
        {
            Debug.Log("Mint_LV1 detected");
            // ������Ʈ�� �̸��� Mint_LV1�̶�� �̵� �ӵ��� ���ҽ�ŵ�ϴ�
            currentMovementSpeed = normalMovementSpeed * 0.1f; // ���� ������ ������ �� �ֽ��ϴ�
        }
        else
        {
            Debug.Log("Not Mint_LV1");
            // ������Ʈ�� �̸��� Mint_LV1�� �ƴ϶�� ���� �̵� �ӵ��� ����մϴ�
            currentMovementSpeed = normalMovementSpeed;
        }

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
                // ��� ���� ������ ��� ��������Ʈ �ε����� �ʱ�ȭ�ϰ� �̵��� ����ϴ�.
                currentWaypointIndex = 0;
            }
        }
    }
}
