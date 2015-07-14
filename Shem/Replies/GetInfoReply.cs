using Shem.Exceptions;
using System;

namespace Shem.Replies
{
    public class GetInfoReply : Reply
    {
        private bool _isvalid;
        private string _name;
        private string _value;

        /// <summary>
        /// The name of the config.
        /// <exception cref="Shem.Exceptions.BadTorReplyException">Thrown when the server returned a bad response.
        /// Try parsing the rawstring / replyline and code for debug.</exception>
        /// </summary>
        public string Name
        { 
            get
            {
                if (!_isvalid)
                    throw new BadTorReplyException();
                return _name;
            }
        }

        /// <summary>
        /// The value of the config.
        /// <exception cref="Shem.Exceptions.BadTorReplyException">Thrown when the server returned a bad response.
        /// Try parsing the rawstring / replyline and code for debug.</exception>
        /// </summary>
        public string Value
        {
            get
            {
                if (!_isvalid)
                    throw new BadTorReplyException();
                return _value;
            }
        }
        
        internal GetInfoReply(Reply reply) : base(reply)
        {
            _isvalid = this.Code == ReplyCodes.OK;
            if (_isvalid)
            {
                try
                {
                    _name = this.ReplyLine.Substring(0, this.ReplyLine.IndexOf("="));
                    _value = this.ReplyLine.Substring(this.ReplyLine.IndexOf("=") + 1);
                }
                catch (ArgumentNullException ex)
                {
                    _isvalid = false;
                }
            }
        }
    }
}
