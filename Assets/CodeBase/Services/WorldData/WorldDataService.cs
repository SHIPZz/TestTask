using System.Threading.Tasks;
using CodeBase.Services.SaveSystem;

namespace CodeBase.Services.WorldData
{
    public class WorldDataService : IWorldDataService
    {
        public CodeBase.Data.WorldData WorldData { get; private set; }

        private ISaveSystem _saveSystem;

        public WorldDataService(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        public void Save()
        {
            _saveSystem.Save(WorldData);
        }

        public async Task<CodeBase.Data.WorldData> Load()
        {
            WorldData = await _saveSystem.Load();
            return WorldData;
        }
    }
}