using System.Text.Json.Serialization;

namespace ApiSitea.Domain.Entities
{
    public class Provincia
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}