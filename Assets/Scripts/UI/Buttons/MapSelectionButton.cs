using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MapSelectionButton : AbstractionButton
    {
        [SerializeField] private int _indexMap;
    
        public override void OnClick()
        {
            SceneManager.LoadScene(_indexMap);
        }
    }
}
