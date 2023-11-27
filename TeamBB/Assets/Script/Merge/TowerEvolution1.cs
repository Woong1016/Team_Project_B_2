using UnityEngine;

public class TowerEvolution1 : MonoBehaviour
{
    public GameObject evolvedTowerPrefab; // ��ȭ�� Ÿ�� ������

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EvolutionObject1")) // ��ȭ�� ����Ű�� ������Ʈ�� �±׸� ����� �浹 ����
        {
            EvolveTower();
        }
    }

    void EvolveTower()
    {
        if (evolvedTowerPrefab != null) // ��ȭ�� �������� �����ϴ��� Ȯ��
        {
            // ��ȭ�� Ÿ���� ��ü
            GameObject newTower = Instantiate(evolvedTowerPrefab, transform.position, transform.rotation) as GameObject;

            // �ʿ信 ���� ���� Ÿ�� ����
            Destroy(gameObject);
        }
    }
}