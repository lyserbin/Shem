using System;

namespace Shem.Exceptions
{
    /// <summary>
    /// This is thrown when the server replied with a message
    /// without a reply code.
    /// </summary>
    public class NullReplyCodeException : Exception {

        /// <summary>
        /// Create a null reply exception from a given raw string.
        /// </summary>
        /// <param name="rawmessage">The raw reply of the server.</param>
        /// <param name="position">The position where the code was parsed.</param>
        public NullReplyCodeException(string rawmessage, int position) : base (String.Format("No reply code found for \"{0}\" position {1}.", rawmessage, position)) { }
    }
}
