using PlayerContent;
using SO;
using UnityEngine;

namespace EnemyContent
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        [SerializeField]private Spawner _spawner;
        [SerializeField]private EnemyHealth _enemyHealth;
        [SerializeField] private Awarding _awarding;

        public Awarding Awarding => _awarding;
        
        public Spawner Spawner => _spawner;
        
        public float SpawnChance { get; private set; }

        public MainPlayer Player { get; private set; }

        public void Init()
        {
            SpawnChance = _enemyData.SpawnChance;
        }

        public void InitPlayer(MainPlayer player,Spawner spawner,Awarding awarding)
        {
            Player = player;
            _spawner = spawner;
            _awarding = awarding;
        }
    }
}
