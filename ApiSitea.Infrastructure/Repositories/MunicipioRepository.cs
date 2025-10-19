using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.JsonData;

namespace ApiSitea.Infrastructure.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly JsonDataProvider _jsonDataProvider;
        private IEnumerable<Municipio>? _municipiosCache;

        public MunicipioRepository(JsonDataProvider jsonDataProvider)
        {
            _jsonDataProvider = jsonDataProvider;
        }

        private async Task LoadDataIfNeededAsync()
        {
            if (_municipiosCache == null)
            {
                _municipiosCache = await _jsonDataProvider.LoadJsonDataAsync<IEnumerable<Municipio>>("municipios.json");
                _municipiosCache ??= Enumerable.Empty<Municipio>();
            }
        }

        public async Task<IEnumerable<Municipio>> GetByProvinciaIdAsync(int provinciaId)
        {
            await LoadDataIfNeededAsync();
            return _municipiosCache?.Where(m => m.ProvinciaId == provinciaId) ??
                   Enumerable.Empty<Municipio>();
        }

        public async Task<Municipio?> GetByIdAsync(int provinciaId, int municipioId)
        {
            await LoadDataIfNeededAsync();
            return _municipiosCache?.FirstOrDefault(m => m.ProvinciaId == provinciaId && m.Id == municipioId);
        }

        public async Task<bool> ExisteMunicipioEnProvinciaAsync(int provinciaId, int municipioId)
        {
            await LoadDataIfNeededAsync();
            return _municipiosCache?.Any(m => m.ProvinciaId == provinciaId && m.Id == municipioId) ?? false;
        }
    }
}