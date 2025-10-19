using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;

namespace ApiSitea.Application.Services
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly IProvinciaRepository _provinciaRepository;

        public ProvinciaService(IProvinciaRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
        }

        public async Task<IEnumerable<Provincia>> GetAllAsync()
        {
            return await _provinciaRepository.GetAllAsync();
        }

        public async Task<Provincia?> GetByIdAsync(int id)
        {
            return await _provinciaRepository.GetByIdAsync(id);
        }

        public async Task<bool> ExisteProvinciaAsync(int id)
        {
            return await _provinciaRepository.ExisteProvinciaAsync(id);
        }
    }
}