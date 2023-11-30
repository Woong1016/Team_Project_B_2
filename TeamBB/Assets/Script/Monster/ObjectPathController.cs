using UnityEngine;
using System.Collections.Generic;

public class ObjectPathController : MonoBehaviour
{
    public PathManager PathManager; // PathManager 스크립트를 가진 게임 오브젝트를 Inspector 창에서 연결하세요.
    public string slowDownObjectName = "Mint_LV1"; // 특정 오브젝트의 이름
    private List<Vector3> currentPath;
    private int currentWaypointIndex = 0;
    public float normalMovementSpeed = 7.0f; // 원래 이동 속도 설정
    private float currentMovementSpeed; // 현재 이동 속도

    private void Start()
    {
        // PathManager에서 무작위 경로를 가져옵니다.
        currentPath = PathManager.GetRandomPath();

        if (currentPath != null && currentPath.Count > 0)
        {
            // 초기 위치를 첫 번째 웨이포인트로 설정
            transform.position = currentPath[0];  
        }

        // 초기 이동 속도 설정
        currentMovementSpeed = normalMovementSpeed;
    }

    private void Update()
    {
        Debug.Log("Update called");

        if (currentPath == null || currentPath.Count == 0)
            return;
        Debug.Log("Path available");

        // 특정 오브젝트의 이름이 Mint_LV1인지 확인
        if (gameObject.name == slowDownObjectName)
        {
            Debug.Log("Mint_LV1 detected");
            // 오브젝트의 이름이 Mint_LV1이라면 이동 속도를 감소시킵니다
            currentMovementSpeed = normalMovementSpeed * 0.1f; // 감속 정도를 조절할 수 있습니다
        }
        else
        {
            Debug.Log("Not Mint_LV1");
            // 오브젝트의 이름이 Mint_LV1이 아니라면 정상 이동 속도를 사용합니다
            currentMovementSpeed = normalMovementSpeed;
        }

        // 다음 웨이포인트로 이동합니다.
        Vector3 targetPosition = currentPath[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentMovementSpeed * Time.deltaTime);

        // 웨이포인트를 바라보도록 회전
        transform.LookAt(targetPosition);

        // 현재 위치와 목표 위치 간의 거리를 계산합니다.
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // 일정 거리(예: 0.1f) 이하로 가까워지면 다음 웨이포인트로 이동합니다.
        if (distanceToTarget < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= currentPath.Count)
            {
                // 경로 끝에 도달한 경우 웨이포인트 인덱스를 초기화하고 이동을 멈춥니다.
                currentWaypointIndex = 0;
            }
        }
    }
}
