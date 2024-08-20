using SO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyData _enemyData;

    public float SpawnChance { get; private set; } 

    /*private void Awake()
    {
        SpawnChance = _enemyData.SpawnChance;
    }*/

    public void Init()
    {
        SpawnChance = _enemyData.SpawnChance;
    }
    /*private void Start()
    {
        SpawnChance = _enemyData.SpawnChance;
    }*/
}
