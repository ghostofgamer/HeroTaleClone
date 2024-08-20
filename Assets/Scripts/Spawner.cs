using System;
using System.Collections;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private GameObject _loupe;
    [SerializeField] private GameObject _overBattleButton;
    [SerializeField] private MainPlayer _player;

    public event Action<Enemy> EnemySpawned;

    private void Start()
    {
        foreach (var enemyData in _enemies)
            enemyData.Init();
    }

    private void SpawnEnemy()
    {
        float totalChance = 0f;

        foreach (var enemy in _enemies)
            totalChance += enemy.SpawnChance;

        if (totalChance <= 0f)
        {
            Debug.LogError("Total spawn chance must be greater than 0.");
        }

        float randomValue = Random.value * totalChance;
        float cumulativeChance = 0f;

        foreach (var enemy in _enemies)
        {
            cumulativeChance += enemy.SpawnChance;

            if (randomValue <= cumulativeChance)
            {
                enemy.gameObject.SetActive(true);
                _overBattleButton.SetActive(true);
                _player.InitEnemy(enemy);
                // EnemySpawned?.Invoke(enemy);
                return;
            }
        }

        _enemies[0].gameObject.SetActive(true);
        _player.InitEnemy( _enemies[0]);
        // EnemySpawned?.Invoke(_enemies[0]);
        _overBattleButton.SetActive(true);
    }

    public void StartSearch()
    {
        foreach (var enemy in _enemies)
            enemy.gameObject.SetActive(false);

        StartCoroutine(SearchEnemy());
    }

    private IEnumerator SearchEnemy()
    {
        _loupe.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        _loupe.gameObject.SetActive(false);
        SpawnEnemy();
    }
}