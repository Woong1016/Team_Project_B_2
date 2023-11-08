using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject currentTower; // ���� ����ٴϴ� Ÿ��
    private bool isPlacingTower = false; // Ÿ�� ��ġ ������ ����

    void Update()
    {
        if (isPlacingTower)
        {
            // ���콺 ��ġ�� Ÿ�� �̵�
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentTower.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);

            // ���콺 Ŭ�� �� Ÿ�� ��ġ
            if (Input.GetMouseButtonDown(0))
            {
                // Ŭ���� ��ġ�� �������� Ÿ�� ��ġ
                // �̶�, �浹�� �˻��ϰ� �ߺ� ��ġ�� �����ϴ� ������ �߰��ؾ� �մϴ�.
                isPlacingTower = false; // Ÿ�� ��ġ �Ϸ�
                currentTower = null; // ���� ����ٴϴ� Ÿ�� �ʱ�ȭ
            }
        }
    }

    // �������� Ÿ���� ������ �� ȣ��Ǵ� �޼���
    public void PurchaseTower(GameObject towerPrefab)
    {
        if (!isPlacingTower)
        {
            currentTower = Instantiate(towerPrefab);
            isPlacingTower = true;
        }
    }
}
