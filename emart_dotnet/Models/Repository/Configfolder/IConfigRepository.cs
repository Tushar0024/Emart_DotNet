using Emart_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Configfolder
{
    public interface IConfigRepository
    {
        Task<Config> AddConfig(Config config);

        Task<Config?> DeleteConfig(int configId);

        Task<IEnumerable<Config>> GetAllConfigs();

        Task<Config?> GetConfigById(int configId);

        Task<Config?> UpdateConfig(int configId, Config updatedConfig);
    }
}
