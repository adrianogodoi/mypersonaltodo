using System.ComponentModel;

namespace MyPersonalToDo.Domain.Enums
{
    public enum StatusEnum
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Em Andamento")]
        EmAndamento = 2,

        [Description("Concluído")]
        Concluido = 3
    }
}
