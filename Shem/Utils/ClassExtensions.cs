using System;
using System.Reflection;

namespace Shem.Utils
{
    public static class ClassExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            string output = "";
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }

        public static Type GetTypeValue(this Enum value)
        {
            Type output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            TypeValueAttribute[] attrs = fi.GetCustomAttributes(typeof(TypeValueAttribute), false) as TypeValueAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }
}