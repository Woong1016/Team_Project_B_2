using UnityEngine;
using System.Collections.Generic;

public class ObjectPathController : MonoBehaviour
{
    public PathManager PathManager; // PathManager 스크립트를 가진 게임 오브젝트를 Inspector 창에서 연결하세요.
    private List<Vector3> currentPath;
    private int currentWaypointIndex = 0;
    private float movementSpeed = 50.0f; // 움직임 속도 설정

    private void Start()
    {
        // PathManager에서 무작위 경로를 가져옵니다.
        currentPath = PathManager.GetRandomPath();

        if (currentPath != null && currentPath.Count > 0)
        {
            // 초기 위치를 첫 번째 웨이포인트로 설정
            transform.position = currentPath[0];
        }
    }

    private void Update()
    {
        if (currentPath == null || currentPath.Count == 0)
            return;

        // 다음 웨이포인트로 이동합니다.
        Vector3 targetPosition = currentPath[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // 현재 위치와 목표 위치 간의 거리를 계산합니다.
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // 일정 거리(예: 0.1f) 이하로 가까워지면 다음 웨이포인트로 이동합니다.
        if (distanceToTarget < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= currentPath.Count)
            {
                // 경로 끝에 도달한 경우 웨이포인트 인덱스를 초기화하고 움직임을 멈춥니다.
                currentWaypointIndex = 0;
                // 움직임을 멈추려면 아래 라인을 주석 해제하세요.
               movementSpeed = 0.0f;
            }
        }
    }
}
