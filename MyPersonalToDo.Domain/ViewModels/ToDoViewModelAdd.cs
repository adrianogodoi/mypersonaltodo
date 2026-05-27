
using MyPersonalToDo.Domain.Converters;
using System.Text.Json.Serialization;

namespace MyPersonalToDo.Domain.ViewModels
{
    public class ToDoViewModelAdd
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DataVencimento { get; set; }
    }
}
