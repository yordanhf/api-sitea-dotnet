using System.Text.Json.Serialization;

namespace ApiSitea.Domain.Entities
{
    public class Municipio
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("provinciaId")]
        public int ProvinciaId { get; set; }
    }
}