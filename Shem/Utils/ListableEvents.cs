using System;

namespace Shem.Utils
{
    public class ListableEvents<T>
    {
        public event Action<T> Event;

        internal void Dispatch(T args)
        {
            if (Event != null)
            {
                Event(args);
            }
        }

        public static ListableEvents<T> operator +(ListableEvents<T> le, Action<T> d)
        {
            le.Event += d;
            return le;
        }

        public static ListableEvents<T> operator -(ListableEvents<T> le, Action<T> d)
        {
            le.Event -= d;
            return le;
        }
    }
}
