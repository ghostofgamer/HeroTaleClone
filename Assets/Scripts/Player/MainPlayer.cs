using UnityEngine;

namespace Player
{
    public class MainPlayer : MonoBehaviour
    {
        public Enemy Enemy { get; private set; }

        public void InitEnemy(Enemy enemy)
        {
            Enemy = enemy;
        }

        public void ClearEnemy()
        {
            Enemy = null;
        }
    }
}
