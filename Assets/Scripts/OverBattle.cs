using EnemyContent;
using PlayerContent;
using UnityEngine;

public class OverBattle : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PlayerAttack _playerAttack;

    private Enemy _enemy;

    public void EscapeFromBattle()
    {
        _enemy = _spawner.CurrentEnemy;
        _enemy.gameObject.SetActive(false);
        _playerAttack.StopAttack();
    }
}
