using System;
using SO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private EnemyData[] _enemyDatas;

    private void Start()
    {
        foreach (var enemyData in _enemies)
            enemyData.Init();
    }

    public Enemy SpawnEnemy()
    {
        float totalChance = 0f;
        
        foreach (var enemyData in _enemies)
            enemyData.gameObject.SetActive(false);
        
        foreach (var enemyData in _enemies)
        {
            totalChance += enemyData.SpawnChance;
        }

        if (totalChance <= 0f)
        {
            Debug.LogError("Total spawn chance must be greater than 0.");
            return null;
        }

        float randomValue = Random.value * totalChance;
        float cumulativeChance = 0f;

        foreach (var enemyData in _enemies)
        {
            cumulativeChance += enemyData.SpawnChance;

            if (randomValue <= cumulativeChance)
            {
                return enemyData;
            }
        }

        return _enemies[0];
    }
}