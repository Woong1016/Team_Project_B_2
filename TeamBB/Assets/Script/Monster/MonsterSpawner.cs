using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; // UI �ؽ�Ʈ�� ����ϱ� ���� �߰�

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

    public Text roundText; // UI Text ������Ʈ

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
                    // ��� ������Ʈ�� �����Ǿ����� Ȯ��
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

            // ���� ���� �ؽ�Ʈ ������Ʈ
            roundText.text = " " + (currentRound + 1); // ����� 0���� �����ϹǷ� 1�� ���ؼ� ǥ��
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
            // ���ϴ� ���� ��ġ�� ������ �����ϰ� �������� ����
            Vector3 spawnPosition = new Vector3(0, 0, 0); // ���ϴ� ��ġ�� ����
            Quaternion spawnRotation = Quaternion.identity; // ���ϴ� �������� ����

            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);
            spawnedObject.tag = "SpawnedObject"; // �����ѵ� ������Ʈ�� �±� �Ҵ�
        }
    }
}
