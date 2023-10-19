using UnityEngine;
using System.Collections.Generic;

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

    private int currentRound = 0;
    private int objectsSpawned = 0;
    private float nextSpawnTime = 0.0f;

    void Update()
    {
        if (currentRound < rounds.Count)
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
                        currentRound++;
                        objectsSpawned = 0;
                    }
                }
            }
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
            spawnedObject.tag = "SpawnedObject"; // 스폰된 오브젝트에 태그 할당
        }
    }
}
