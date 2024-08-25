using UnityEngine;

namespace Test
{
    public class SpawnButton : AbstractionButton
    {
        [SerializeField] private Spawner _spawner;

        public override void OnClick()
        {
            _spawner.StartSearch();
            gameObject.SetActive(false);
        }
    }
}