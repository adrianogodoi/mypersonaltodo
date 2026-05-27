using System.ComponentModel;
using System.Reflection;

namespace MyPersonalToDo.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();

            string name = Enum.GetName(type, value);

            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attribute =
                        Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    return attribute == null ? value.ToString() : attribute.Description;
                }
            }
            return value.ToString();
        }
    }
}
