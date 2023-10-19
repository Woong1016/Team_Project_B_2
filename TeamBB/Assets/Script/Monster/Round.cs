using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Round
{
    public List<GameObject> monsterPrefabs; // 몬스터 프리팹의 리스트
    public List<int> numberOfMonsters;     // 몬스터 수량의 리스트
    public float timeBetweenSpawns;
}

