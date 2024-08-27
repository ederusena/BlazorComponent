using BlazorComponent.Models;

namespace BlazorComponent.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public async Task<List<Medico>> GetAllAsync()
        {
           return new List<Medico>
           {
               new Medico { Id = 1, Name = "Dr. John Doe", CRM = 123456 },
               new Medico { Id = 2, Name = "Dr. Jane Doe", CRM = 654321 },
               new Medico { Id = 3, Name = "Dr. John Smith", CRM = 987654 },
               new Medico { Id = 4, Name = "Dr. Jane Smith", CRM = 456789 },
               new Medico { Id = 5, Name = "Dr. John Johnson", CRM = 321654 },
               new Medico { Id = 6, Name = "Dr. Jane Johnson", CRM = 789123 }
           };
        }
    }
}
