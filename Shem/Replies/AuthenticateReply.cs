
namespace Shem.Replies
{
    
    public class AuthenticateReply : Reply
    {
        internal AuthenticateReply(Reply reply) : base(reply) { }

        /// <summary>
        /// Check if you are authenticated or not.
        /// </summary>
        /// <returns>Returns true if the given password was good.</returns>
        public bool IsAuthenticated()
        {
            return this.Code == ReplyCodes.OK;
        }
    }
}
