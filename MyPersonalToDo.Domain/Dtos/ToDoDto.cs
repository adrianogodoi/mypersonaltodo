using MyPersonalToDo.Domain.Converters;
using MyPersonalToDo.Domain.Enums;
using System.Text.Json.Serialization;

namespace MyPersonalToDo.Domain.Dtos
{
    public class ToDoDto
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DataVencimento { get; set; }
    }
}
