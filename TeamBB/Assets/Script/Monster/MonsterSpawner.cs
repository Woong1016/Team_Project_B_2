using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; // UI 텍스트를 사용하기 위해 추가

public class MonsterSpawner : MonoBehaviour
{
    [System.Serializable]
    public class RoundInfo
    {
        public string roundName;
        public List<GameObject> objectsToSpawn;
        public float timeBetweenSpawns;
    }

    public List<RoundInfo> rounds = new List<RoundInfo>();

    public Text roundText; // UI Text 컴포넌트

    private int currentRound = -1;
    private int objectsSpawned = 0;
    private float nextSpawnTime = 0.0f;
    private bool allRoundsSpawned = false;

    void Start()
    {
        NextRound();
    }

    void Update()
    {
        if (!allRoundsSpawned)
        {
            if (Time.time >= nextSpawnTime)
            {
                if (objectsSpawned < rounds[currentRound].objectsToSpawn.Count)
                {
                    GameObject objectPrefab = rounds[currentRound].objectsToSpawn[objectsSpawned];
                    SpawnObject(objectPrefab);

                    objectsSpawned++;
                    nextSpawnTime = Time.time + rounds[currentRound].timeBetweenSpawns;
                }
                else
                {
                    // 모든 오브젝트가 스폰되었는지 확인
                    GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnedObject");
                    if (spawnedObjects.Length == 0)
                    {
                        NextRound();
                    }
                }
            }
        }
    }

    private void NextRound()
    {
        currentRound++;
        if (currentRound < rounds.Count)
        {
            objectsSpawned = 0;
            nextSpawnTime = Time.time + rounds[currentRound].timeBetweenSpawns;

            // 현재 라운드 텍스트 업데이트
            roundText.text = " " + (currentRound + 1); // 라운드는 0부터 시작하므로 1을 더해서 표시
        }
        else
        {
            allRoundsSpawned = true;
        }
    }

    private void SpawnObject(GameObject objectPrefab)
    {
        if (objectPrefab != null)
        {
            // 원하는 스폰 위치와 방향을 설정하고 프리팹을 생성
            Vector3 spawnPosition = new Vector3(0, 0, 0); // 원하는 위치로 변경
            Quaternion spawnRotation = Quaternion.identity; // 원하는 방향으로 변경

            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);
            spawnedObject.tag = "SpawnedObject"; // 스포닌된 오브젝트에 태그 할당
        }
    }
}
