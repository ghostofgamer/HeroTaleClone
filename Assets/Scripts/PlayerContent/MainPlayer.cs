using EnemyContent;
using UnityEngine;

namespace PlayerContent
{
    public class MainPlayer : MonoBehaviour
    {
        public Enemy Enemy { get; private set; }

        public void InitEnemy(Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}
