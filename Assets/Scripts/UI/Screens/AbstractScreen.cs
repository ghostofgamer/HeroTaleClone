using UnityEngine;

namespace UI.Screens
{
    public abstract class AbstractScreen : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private float _fullAlpha = 1;
        private float _zeroAlpha = 0;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        protected void Open()
        {
            _canvasGroup.alpha = _fullAlpha;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void Close()
        {
            _canvasGroup.alpha = _zeroAlpha;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}