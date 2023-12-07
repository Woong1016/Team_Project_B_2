using UnityEngine;

public class TowerEvolution : MonoBehaviour
{
    public GameObject evolvedTowerPrefab; // 진화된 타워 프리팹

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EvolutionObject")) // 진화를 일으키는 오브젝트의 태그를 사용해 충돌 감지
        {
            EvolveTower(); 
               
        }
    }

    void EvolveTower()
    {
        if (evolvedTowerPrefab != null) // 진화할 프리팹이 존재하는지 확인
        {
            // 진화된 타워로 교체
            GameObject newTower = Instantiate(evolvedTowerPrefab, transform.position, transform.rotation) as GameObject;

            // 필요에 따라 기존 타워 제거
            Destroy(gameObject);
        }
    }
}
