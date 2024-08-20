using System.Collections;
using EnemyContent;
using Interfaces;
using PlayerContent;
using SO;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField]private Animator _animator;

    private float _delay;
    private int _damage;
    private Enemy _enemy;

    private void Start()
    {
    }

    public void Init()
    {
        _enemy = GetComponent<Enemy>();
        _delay = _enemyData.AttackDelay;
        _damage = _enemyData.Damage;
    }

    public void ApplyAttack()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        // PlayerHealth playerHealth = _enemy.Player.GetComponent<PlayerHealth>();

        while (_enemy.Player.GetComponent<PlayerHealth>().CurrentHealth > 0)
        {
            yield return new WaitForSeconds(_delay);
            _animator.SetTrigger("Attack");
            _enemy.Player.GetComponent<PlayerHealth>().TakeDamage(_damage);
        }
    }
}