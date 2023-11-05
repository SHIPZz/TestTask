using DG.Tweening;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _targetCanvasAlpha = 1f;
        [SerializeField] private float _targetDecreaseAlphaDuration = 1f;
        
        public void Show()
        {
            _canvas.enabled = true;
            _canvasGroup.alpha = 1f;
        }

        public void Hide()
        {
            _canvasGroup.DOFade(0f, _targetDecreaseAlphaDuration)
                .OnComplete(() => _canvas.enabled = false);
        }
    }

    public interface ILoadingCurtain
    {
        void Show();
        void Hide();
    }
}