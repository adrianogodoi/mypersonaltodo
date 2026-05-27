
using MyPersonalToDo.Domain.Converters;
using MyPersonalToDo.Domain.Enums;
using System.Text.Json.Serialization;

namespace MyPersonalToDo.Domain.ViewModels
{
    public class ToDoViewModelUpdate
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusEnum StatusId { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DataVencimento { get; set; }
    }
}
