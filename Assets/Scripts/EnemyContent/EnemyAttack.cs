using System.Collections;
using EnemyContent;
using Interfaces;
using PlayerContent;
using SO;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour, IAttackable
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _stateIdle;
    [SerializeField] private GameObject _stateAttack;
    [SerializeField] private Image _imageStateAttack;
    [SerializeField] private Image _imageStateIdle;
    [SerializeField] private float _delayAttack;

    private float _delay;
    private int _damage;
    private Enemy _enemy;

    private void OnEnable()
    {
        _stateIdle.SetActive(true);
        _stateAttack.SetActive(false);
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
            float elapsedTime = 0;
            _imageStateIdle.fillAmount = 0;
            float targetFillAmount = 1f;
            
            while (elapsedTime < _delay)
            {
                elapsedTime += Time.deltaTime;
                _imageStateIdle.fillAmount = Mathf.Lerp(0, targetFillAmount, elapsedTime / _delay);
                yield return null;
            }

            _imageStateIdle.fillAmount = targetFillAmount;
            _stateAttack.SetActive(true);
            _stateIdle.SetActive(false);
            _animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.4f);
            _enemy.Player.GetComponent<PlayerHealth>().TakeDamage(_damage);
            elapsedTime = 0;
            _imageStateAttack.fillAmount = 0;
            targetFillAmount = 1f;
            
            while (elapsedTime < _delayAttack)
            {
                elapsedTime += Time.deltaTime;
                _imageStateAttack.fillAmount = Mathf.Lerp(0, targetFillAmount, elapsedTime / _delayAttack);
                yield return null;
            }

            _imageStateAttack.fillAmount = targetFillAmount;
            _stateAttack.SetActive(false);
            _stateIdle.SetActive(true);
        }
    }
}