
namespace Shem.Replies
{
    public class GetInfoReply : Reply
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        
        public GetInfoReply(Reply reply) : base(reply)
        {
            Name = this.ReplyLine.Substring(0, this.ReplyLine.IndexOf("="));
            Value = this.ReplyLine.Substring(this.ReplyLine.IndexOf("=")+1);
        }
    }
}
