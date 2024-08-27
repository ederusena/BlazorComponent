using BlazorComponent.Models;

namespace BlazorComponent.Repositories
{
    public interface IMedicoRepository
    {
        Task<List<Medico>> GetAllAsync();
        
    }
}
