using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services.SaveSystem
{
    public class PlayerPrefsSaveSystem : ISaveSystem
    {
        public void Save(CodeBase.Data.WorldData worldData)
        {
            string jsonData = JsonUtility.ToJson(worldData);
            PlayerPrefs.SetString(nameof(CodeBase.Data.WorldData), jsonData);
            PlayerPrefs.Save();
        }

        public async Task<CodeBase.Data.WorldData> Load()
        {
            if (PlayerPrefs.HasKey(nameof(CodeBase.Data.WorldData)))
            {
                var jsonDataKey = PlayerPrefs.GetString(nameof(CodeBase.Data.WorldData));
                return JsonUtility.FromJson<CodeBase.Data.WorldData>(jsonDataKey);
            }

            await Task.Yield();

            return new CodeBase.Data.WorldData();
        }
    }
}