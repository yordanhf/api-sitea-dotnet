using ApiSitea.Infrastructure.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace ApiSitea.Infrastructure.JsonData
{
    public class JsonDataProvider
    {
        private readonly string _basePath;
        private readonly ILogger<JsonDataProvider> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public JsonDataProvider(
            IOptions<JsonDataSettings> settings,
            ILogger<JsonDataProvider> logger)
        {
            _logger = logger;
            var contentPath = settings.Value.BasePath;
            if (string.IsNullOrEmpty(contentPath))
            {
                contentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonData");
            }
            _basePath = contentPath;

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public async Task<T?> LoadJsonDataAsync<T>(string fileName)
        {
            var filePath = Path.Combine(_basePath, fileName);

            if (!File.Exists(filePath))
            {
                _logger.LogError("Archivo no encontrado: {FilePath}", filePath);
                throw new FileNotFoundException($"Archivo JSON no encontrado: {fileName}", filePath);
            }

            try
            {
                var jsonString = await File.ReadAllTextAsync(filePath);
                _logger.LogInformation("Contenido del archivo {FileName}: {Content}", fileName, jsonString);

                var result = JsonSerializer.Deserialize<T>(jsonString, _jsonOptions);

                if (result == null)
                {
                    _logger.LogWarning("La deserialización resultó en null para {FileName}", fileName);
                }

                return result;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error al deserializar el archivo {FileName}", fileName);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al leer el archivo {FileName}", fileName);
                throw;
            }
        }
    }
}