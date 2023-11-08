using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject currentTower; // 현재 따라다니는 타워
    private bool isPlacingTower = false; // 타워 설치 중인지 여부

    void Update()
    {
        if (isPlacingTower)
        {
            // 마우스 위치로 타워 이동
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentTower.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);

            // 마우스 클릭 시 타워 설치
            if (Input.GetMouseButtonDown(0))
            {
                // 클릭한 위치를 기준으로 타워 설치
                // 이때, 충돌을 검사하고 중복 설치를 방지하는 로직을 추가해야 합니다.
                isPlacingTower = false; // 타워 설치 완료
                currentTower = null; // 현재 따라다니는 타워 초기화
            }
        }
    }

    // 상점에서 타워를 구매할 때 호출되는 메서드
    public void PurchaseTower(GameObject towerPrefab)
    {
        if (!isPlacingTower)
        {
            currentTower = Instantiate(towerPrefab);
            isPlacingTower = true;
        }
    }
}
