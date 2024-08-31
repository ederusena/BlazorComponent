using BlazorComponent.Models;
using BlazorComponent.Repositories;

namespace BlazorComponent.Services
{
    public class MedicoService
    {
        private readonly MedicoRepository _medicoRepository;

        public MedicoService(MedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task AddMedicoAsync(Medico medico)
        {
            if (string.IsNullOrEmpty(medico.Name) || string.IsNullOrEmpty(medico.CRM))
            {
                throw new Exception("Todos os campos são obrigatórios");
            }

            await _medicoRepository.AddAsync(medico);
        }

        public async Task<List<Medico>> GetAllMedicosAsync()
        {
            return await _medicoRepository.GetAllAsync();
        }

        public async Task<Medico?> GetMedicoByIdAsync(int id)
        {
            return await _medicoRepository.GetByIdAsync(id);
        }

        public async Task UpdateMedicoAsync(int id, Medico medico)
        {
            var existingMedico = await _medicoRepository.GetByIdAsync(id);
            if (existingMedico == null)
            {
                throw new Exception("Médico não encontrado");
            }

            await _medicoRepository.UpdateAsync(medico);
        }

        public async Task RemoveMedicoAsync(int id)
        {
            await _medicoRepository.RemoveAsync(id);
        }
    }
}
