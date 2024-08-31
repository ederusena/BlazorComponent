    using BlazorComponent.Models;

namespace BlazorComponent.Repositories
{
    public class MedicoRepository : IRepository<Medico>
    {
        private readonly List<Medico> _medicos = new();

        public Task AddAsync(Medico entity)
        {
            _medicos.Add(entity);
            return Task.CompletedTask;
        }

        public Task<List<Medico>> GetAllAsync()
        {
            return Task.FromResult(_medicos.ToList());
        }

        public Task<Medico?> GetByIdAsync(int id)
        {
            return Task.FromResult(_medicos.FirstOrDefault(x => x.Id == id));
        }

        public Task RemoveAsync(int id)
        {
            var medico = _medicos.FirstOrDefault(x => x.Id == id);
            if (medico != null)
            {
                _medicos.Remove(medico);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Medico medico)
        {
            var existingMedico = _medicos.FirstOrDefault(x => x.Id == medico.Id);
            if (existingMedico != null)
            {
                existingMedico.Update(medico.Name, medico.CRM);
            }
            return Task.CompletedTask;
        }
    }
}
