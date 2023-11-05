using System;
using CodeBase.Data;
using CodeBase.Gameplay.TriggerObservers;
using CodeBase.Infrastructure;
using CodeBase.Services.Pause;
using CodeBase.Services.WorldData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Gameplay.Triggers
{
    public class FinishTrigger : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private IWorldDataService _worldDataService;
        private IPauseService _pauseService;

        public event Action PlayerEntered;

        [Inject]
        private void Construct(IWorldDataService worldDataService, IPauseService pauseService)
        {
            _pauseService = pauseService;
            _worldDataService = worldDataService;
        }
        
        private void OnEnable() => 
            _triggerObserver.TriggerEntered += OnEntered;

        private void OnDisable() => 
            _triggerObserver.TriggerEntered -= OnEntered;

        private void OnEntered(Collider player)
        {
            WorldData worldData = _worldDataService.WorldData;

            worldData.LevelData.Id++;

            if (worldData.LevelData.Id >= SceneManager.sceneCountInBuildSettings)
                worldData.LevelData.Id--;
            
            _worldDataService.Save();
            _pauseService.Pause();
            PlayerEntered?.Invoke();
        }
    }
}