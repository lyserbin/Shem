using System;

namespace Shem.Utils
{
    class TypeValueAttribute : Attribute
    {
        private Type _value;

        public TypeValueAttribute(Type value)
        {
            _value = value;
        }

        public Type Value
        {
            get { return _value; }
        }
    }
}