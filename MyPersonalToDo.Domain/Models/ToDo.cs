using MyPersonalToDo.Domain.Enums;

namespace MyPersonalToDo.Domain.Models
{
    public class ToDo
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}
