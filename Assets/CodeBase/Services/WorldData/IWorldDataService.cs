using System.Threading.Tasks;

namespace CodeBase.Services.WorldData
{
    public interface IWorldDataService
    {
        CodeBase.Data.WorldData WorldData { get; }

        void Save();
        Task<CodeBase.Data.WorldData> Load();
    }
}