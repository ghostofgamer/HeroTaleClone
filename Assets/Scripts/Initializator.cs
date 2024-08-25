using EnemyContent;
using UnityEngine;

public class Initializator : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    private void Awake()
    {
        Initialization();
    }

    private void Initialization()
    {
        foreach (Enemy enemy in _enemies)
            enemy.GetComponent<EnemyAttack>().Init();
    }
}