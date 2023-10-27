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
    public GameObject clearScreen; // Ŭ���� ȭ�� GameObject

    private int currentRound = -1;
    private int objectsSpawned = 0;
    private float nextSpawnTime = 0.0f;
    private bool allRoundsSpawned = false;

    void Start()
    {
        // Ŭ���� ȭ�� ��Ȱ��ȭ �� ���� ��ü ��Ȱ��ȭ
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
                    // ��� ������Ʈ�� �����Ǿ����� Ȯ��
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
            // ��� ���尡 ������ �� Ŭ���� ȭ�� Ȱ��ȭ
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

    // Ŭ���� ȭ�� �� ���� ��ü Ȱ��ȭ/��Ȱ��ȭ�� ó���ϴ� �޼���
    private void SetClearScreenActive(bool isActive)
    {
        clearScreen.SetActive(isActive);
    }
}
