using EnemyContent;
using PlayerContent;
using UnityEngine;

namespace FightContent
{
    public class Fight : MonoBehaviour
    {
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField]private StageUI _stageUI;
        [SerializeField]private Spawner _spawner;
        
        private Enemy _enemy;

        private void OnEnable()
        {
            _spawner.EnemySpawned += Init;
        }

        private void OnDisable()
        {
            _spawner.EnemySpawned -= Init;
        }

        private void Init(Enemy enemy)
        {
            _enemy = enemy;
            StartBattle();
        }

        private void StartBattle()
        {
            if (_enemy == null)
                return;

            _playerAttack.ApplyAttack();
            _enemy.GetComponent<EnemyAttack>().ApplyAttack();
            _stageUI.BattleStage();
        }
    }
}