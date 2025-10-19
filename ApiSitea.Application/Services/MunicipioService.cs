using ApiSitea.Application.Interfaces;
using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;

namespace ApiSitea.Application.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IProvinciaRepository _provinciaRepository;

        public MunicipioService(
            IMunicipioRepository municipioRepository,
            IProvinciaRepository provinciaRepository)
        {
            _municipioRepository = municipioRepository;
            _provinciaRepository = provinciaRepository;
        }

        public async Task<IEnumerable<Municipio>> GetByProvinciaIdAsync(int provinciaId)
        {
            if (!await _provinciaRepository.ExisteProvinciaAsync(provinciaId))
                return Enumerable.Empty<Municipio>();

            return await _municipioRepository.GetByProvinciaIdAsync(provinciaId);
        }

        public async Task<Municipio?> GetByIdAsync(int provinciaId, int municipioId)
        {
            if (!await _provinciaRepository.ExisteProvinciaAsync(provinciaId))
                return null;

            return await _municipioRepository.GetByIdAsync(provinciaId, municipioId);
        }

        public async Task<bool> ExisteMunicipioEnProvinciaAsync(int provinciaId, int municipioId)
        {
            if (!await _provinciaRepository.ExisteProvinciaAsync(provinciaId))
                return false;

            return await _municipioRepository.ExisteMunicipioEnProvinciaAsync(provinciaId, municipioId);
        }
    }
}