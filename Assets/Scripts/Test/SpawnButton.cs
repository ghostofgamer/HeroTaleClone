using UnityEngine;

namespace Test
{
    public class SpawnButton : AbstractionButton
    {
        [SerializeField] private Spawner _spawner;
        
        public override void OnClick()
        {
           Enemy enemy =  _spawner.SpawnEnemy();
           enemy.gameObject.SetActive(true);
        }
    }
}
