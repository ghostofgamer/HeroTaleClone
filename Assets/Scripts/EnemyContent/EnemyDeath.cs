using System;
using UnityEngine;

namespace EnemyContent
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        private Enemy _enemy;

        private void OnEnable()
        {
            _enemyHealth.Died += Die;
        }

        private void OnDisable()
        {
            _enemyHealth.Died -= Die;
        }

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void Die()
        {
            _enemy.Spawner.StartSearch();
        }
    }
}
