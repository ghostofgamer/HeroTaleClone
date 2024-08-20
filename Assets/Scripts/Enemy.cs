using Player;
using SO;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private EnemyData _enemyData;
    

    public float SpawnChance { get; private set; } 
    
    public void Init()
    {
        SpawnChance = _enemyData.SpawnChance;
    } 
    
}
