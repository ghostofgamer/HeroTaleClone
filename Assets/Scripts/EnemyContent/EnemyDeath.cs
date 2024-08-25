using System;
using System.Collections;
using SO;
using UnityEngine;

namespace EnemyContent
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private ParticleSystem _dieEffect;
        [SerializeField] private Animator _animator;
        
        private Enemy _enemy;
        private int _experience;
        
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
            _experience = _enemyData.Experience;
        }

        private void Die()
        {
            StartCoroutine(StartDie());
        }

        private IEnumerator StartDie()
        {
            _animator.SetTrigger("Die");
            _dieEffect.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            _dieEffect.gameObject.SetActive(false);
            _enemy.Spawner.StartSearch();
            _enemy.Awarding.Init(_experience);
        }
    }
}
