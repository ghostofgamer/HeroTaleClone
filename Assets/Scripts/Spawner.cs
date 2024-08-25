using System;
using System.Collections;
using EnemyContent;
using PlayerContent;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private GameObject _loupe;
    [SerializeField] private MainPlayer _player;
    [SerializeField] private StageUI _stageUI;
    [SerializeField] private Awarding _awarding;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    private Coroutine _coroutine;
    private float _totalChance;
    private float _randomValue;
    private float _cumulativeChance;
    
    public event Action<Enemy> EnemySpawned;

    public Enemy CurrentEnemy { get; private set; }

    private void Start()
    {
        foreach (var enemyData in _enemies)
            enemyData.Init();
    }

    public void StartSearch()
    {
        _stageUI.SearchStage();

        foreach (var enemy in _enemies)
            enemy.gameObject.SetActive(false);
        
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SearchEnemy());
    }

    private void SpawnEnemy()
    {
        _totalChance = 0f;

        foreach (var enemy in _enemies)
            _totalChance += enemy.SpawnChance;

        _randomValue = Random.value * _totalChance;
        _cumulativeChance = 0f;

        foreach (var enemy in _enemies)
        {
            _cumulativeChance += enemy.SpawnChance;

            if (_randomValue <= _cumulativeChance)
            {
                CurrentEnemy = enemy;
                return;
            }
        }

        CurrentEnemy = _enemies[0];
    }

    private void Initialization()
    {
        _player.InitEnemy(CurrentEnemy);
        CurrentEnemy.gameObject.SetActive(true);
        CurrentEnemy.InitPlayer(_player, this, _awarding);
        EnemySpawned?.Invoke(CurrentEnemy);
    }

    private IEnumerator SearchEnemy()
    {
        _loupe.gameObject.SetActive(true);
        yield return _waitForSeconds;
        _loupe.gameObject.SetActive(false);
        SpawnEnemy();
        Initialization();
    }
}