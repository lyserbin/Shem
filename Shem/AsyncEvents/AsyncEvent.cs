using Shem.Replies;

namespace Shem.AsyncEvents
{
    public class AsyncEvent : Reply
    {
        public AsyncEvent(Reply reply)
            : base(reply)
        {

        }

        public static AsyncEvent Parse(Reply reply)
        {
            //TODO: parsing the reply and return the right event
            return new AsyncEvent(reply);
        }
    }
}