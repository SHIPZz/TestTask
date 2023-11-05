using System.Threading.Tasks;
using CodeBase.Data;
using CodeBase.Services.Pause;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace CodeBase.Infrastructure
{
    public class LevelLoadState : IState, IPayloadedEnter<WorldData>
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IPauseService _pauseService;

        public LevelLoadState(ILoadingCurtain loadingCurtain, IPauseService pauseService)
        {
            _pauseService = pauseService;
            _loadingCurtain = loadingCurtain;
        }

        public async void Enter(WorldData payload)
        {
            _pauseService.UnPause();
            
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(payload.LevelData.Id);

            while (!loadSceneAsync.isDone)
            {
                await Task.Yield();
            }

            _loadingCurtain.Hide();
        }

        public void Exit() { }
    }
}