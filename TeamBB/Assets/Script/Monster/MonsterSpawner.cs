using UnityEngine;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab; // Monster 프리팹을 참조하기 위한 변수
    void Start()
    {
        // 'Monster' 프리팹을 생성할 위치와 방향을 설정
        Vector3 spawnPosition = new Vector3(0, 0, 0); // 원하는 위치로 변경
        Quaternion spawnRotation = Quaternion.identity; // 원하는 방향으로 변경

        // 'Monster' 프리팹을 인스턴스화하여 'monsterPrefab' 변수에 할당
        GameObject monster = Instantiate(monsterPrefab, spawnPosition, spawnRotation);
    }


    

     public List<Round> rounds = new List<Round>
    {
        // 1라운드
        new Round
        {
            monsterPrefabs = new List<GameObject> { monsterPrefab }, // 'Monster' 프리팹을 몬스터 리스트에 추가
            numberOfMonsters = new List<int> { 5 }, // 1라운드에 5마리의 'Monster'
            timeBetweenSpawns = 3.0f // 스폰 간격 설정
        },
        // 2라운드 (예시)
        new Round
        {
            monsterPrefabs = new List<GameObject> { monsterPrefab }, // 'Monster' 프리팹을 몬스터 리스트에 추가
            numberOfMonsters = new List<int> { 2 }, // 2라운드에 2마리의 'Monster'
            timeBetweenSpawns = 3.0f // 스폰 간격 설정
        },
    // 이후 라운드 설정 계속...
};


    private int currentRound = 0;
    private int monstersSpawned = 0;
    private float nextSpawnTime = 0.0f;

    private void Update()
    {
        // 현재 라운드가 모두 스폰되면 다음 라운드로 진행
        if (currentRound < rounds.Count)
        {
            if (Time.time >= nextSpawnTime)
            {
                if (monstersSpawned < rounds[currentRound].monsterPrefabs.Count)
                {
                    GameObject monsterPrefab = rounds[currentRound].monsterPrefabs[monstersSpawned];
                    int numberOfMonsters = rounds[currentRound].numberOfMonsters[monstersSpawned];

                    for (int i = 0; i < numberOfMonsters; i++)
                    {
                        SpawnMonster(monsterPrefab);
                    }

                    monstersSpawned++;
                    nextSpawnTime = Time.time + rounds[currentRound].timeBetweenSpawns;
                }
                else
                {
                    // 모든 몬스터가 스폰되었는지 확인
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                    if (enemies.Length == 0)
                    {
                        // 현재 라운드의 몬스터를 모두 제거한 경우 다음 라운드로 진행
                        currentRound++;
                        monstersSpawned = 0;
                    }
                }
            }
        }
    }

    private void SpawnMonster(GameObject monsterPrefab)
    {
        if (monsterPrefab != null)
        {
            // 몬스터를 스폰 위치에 생성
            GameObject monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity);
        }
    }
}
