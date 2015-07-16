using System;

namespace Shem.Utils
{
    public static class Utility
    {
        public static T ParseEnum<T>(string value) where T : struct , IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            T tmp = default(T);
            if (!Enum.TryParse<T>(value, true, out tmp))
            {
                Logger.LogWarn(string.Format("Error during the parsing of {0}.", typeof(T).ToString()));
            }
            return tmp;
        }
    }
}
