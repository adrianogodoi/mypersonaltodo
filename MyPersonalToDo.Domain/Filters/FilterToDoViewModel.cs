using MyPersonalToDo.Domain.Converters;
using MyPersonalToDo.Domain.Enums;
using System.Text.Json.Serialization;

namespace MyPersonalToDo.Domain.Filters
{
    public class FilterToDoViewModel
    {
        public StatusEnum? StatusId { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? DataVencimento { get; set; }

    }
}
