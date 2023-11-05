using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class VictoryView : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        public event Action ButtonPressed;

        private void OnEnable() =>
            _restartButton.onClick.AddListener(OnRestartClicked);

        private void OnDisable() =>
            _restartButton.onClick.RemoveListener(OnRestartClicked);

        private void OnRestartClicked() =>
            ButtonPressed?.Invoke();
    }
}