using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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
    public Text roundText;
    public GameObject clearScreen; // 클리어 화면 GameObject

    private int currentRound = -1;
    private int objectsSpawned = 0;
    private float nextSpawnTime = 0.0f;
    private bool allRoundsSpawned = false;

    void Start()
    {
        // 클리어 화면 비활성화 및 하위 객체 비활성화
        SetClearScreenActive(false);
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
        else
        {
            // 모든 라운드가 끝났을 때 클리어 화면 활성화
            SetClearScreenActive(true);
        }
    }

    private void NextRound()
    {
        currentRound++;
        if (currentRound < rounds.Count)
        {
            objectsSpawned = 0;
            nextSpawnTime = Time.time + rounds[currentRound].timeBetweenSpawns;
            roundText.text = " " + (currentRound + 1);
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
            Vector3 spawnPosition = new Vector3(0, 0, 0);
            Quaternion spawnRotation = Quaternion.identity;
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);
            spawnedObject.tag = "SpawnedObject";
        }
    }

    // 클리어 화면 및 하위 객체 활성화/비활성화를 처리하는 메서드
    private void SetClearScreenActive(bool isActive)
    {
        clearScreen.SetActive(isActive);
    }
}
