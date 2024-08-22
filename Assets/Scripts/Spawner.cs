using System;
using System.Collections;
using EnemyContent;
using PlayerContent;
using SO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private GameObject _loupe;
    [SerializeField] private GameObject _overBattleButton;
    [SerializeField] private MainPlayer _player;
    [SerializeField]private StageUI _stageUI;

    public Enemy CurrentEnemy { get; private set; }

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
                CurrentEnemy = enemy;
                return;
            }
        }

        CurrentEnemy = _enemies[0];
    }

    public void StartSearch()
    {
        _stageUI.SearchStage();
        foreach (var enemy in _enemies)
            enemy.gameObject.SetActive(false);

        StartCoroutine(SearchEnemy());
    }

    private void Initialization()
    {
        _player.InitEnemy(CurrentEnemy);
        CurrentEnemy.gameObject.SetActive(true);
        CurrentEnemy.InitPlayer(_player,this);
        _player.GetComponent<PlayerAttack>().ApplyAttack();
        CurrentEnemy.GetComponent<EnemyAttack>().ApplyAttack();
        _stageUI.BattleStage();
    }

    private IEnumerator SearchEnemy()
    {
        _loupe.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        _loupe.gameObject.SetActive(false);
        SpawnEnemy();
        Initialization();
    }
}