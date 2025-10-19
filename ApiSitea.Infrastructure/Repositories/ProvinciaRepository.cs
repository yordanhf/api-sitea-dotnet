using ApiSitea.Domain.Entities;
using ApiSitea.Domain.Interfaces;
using ApiSitea.Infrastructure.JsonData;
using Microsoft.Extensions.Logging;

namespace ApiSitea.Infrastructure.Repositories
{
    public class ProvinciaRepository : IProvinciaRepository
    {
        private readonly JsonDataProvider _jsonDataProvider;
        private IEnumerable<Provincia>? _provinciasCache;
        private readonly ILogger<ProvinciaRepository> _logger;


        public ProvinciaRepository(
         JsonDataProvider jsonDataProvider,
         ILogger<ProvinciaRepository> logger)
        {
            _jsonDataProvider = jsonDataProvider;
            _logger = logger;
        }

        private async Task LoadDataIfNeededAsync()
        {
            if (_provinciasCache == null)
            {
                _provinciasCache = await _jsonDataProvider.LoadJsonDataAsync<IEnumerable<Provincia>>("provincias.json");

                if (_provinciasCache != null)
                {
                    foreach (var provincia in _provinciasCache)
                    {
                        _logger.LogInformation("Provincia cargada: Id={Id}, Nombre={Nombre}",
                            provincia.Id, provincia.Nombre);
                    }
                }

                _provinciasCache ??= Enumerable.Empty<Provincia>();
            }
        }

        public async Task<IEnumerable<Provincia>> GetAllAsync()
        {
            await LoadDataIfNeededAsync();
            return _provinciasCache ?? Enumerable.Empty<Provincia>();
        }

        public async Task<Provincia?> GetByIdAsync(int id)
        {
            await LoadDataIfNeededAsync();
            return _provinciasCache?.FirstOrDefault(p => p.Id == id);
        }

        public async Task<bool> ExisteProvinciaAsync(int id)
        {
            await LoadDataIfNeededAsync();
            return _provinciasCache?.Any(p => p.Id == id) ?? false;
        }
    }
}