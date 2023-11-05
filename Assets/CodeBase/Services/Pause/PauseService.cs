using UnityEngine;

namespace CodeBase.Services.Pause
{
    public class PauseService : IPauseService
    {
        public void Pause() => 
            Time.timeScale = 0;

        public void UnPause() => 
            Time.timeScale = 1f;
    }
}