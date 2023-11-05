using System.Threading.Tasks;

namespace CodeBase.Services.SaveSystem
{
    public interface ISaveSystem
    {
        void Save(CodeBase.Data.WorldData worldData);
        Task<CodeBase.Data.WorldData> Load();
    }
}