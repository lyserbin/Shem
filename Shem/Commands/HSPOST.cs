
namespace Shem.Commands
{
    /// <summary>
    ///  This command launches a hidden service descriptor upload to the specified HSDirs. If one or more Server arguments are provided, an upload is triggered on each of them in parallel. If no Server options are provided, it behaves like a normal HS descriptor upload and will upload to the set of responsible HS directories.
    /// </summary>
    public class HSPost : TCCommand
    {
        private string[] servers;
        private string descriptor;

        /// <summary>
        /// This command launches a hidden service descriptor upload to the specified HSDirs. If one or more Server arguments are provided, an upload is triggered on each of them in parallel. If no Server options are provided, it behaves like a normal HS descriptor upload and will upload to the set of responsible HS directories.
        /// </summary>
        /// <param name="servers">The LongName (Fingerprint [~/=Nickname]) of the servers.</param>
        /// <param name="descriptor">The text of the descriptor formatted as specified in rend-spec.txt section 1.3.</param>
        public HSPost(string descriptor, params string[] servers)
        {
            this.servers = servers;
            this.descriptor = descriptor;
        }

        public override string Raw()
        {
            string servers_formatted = "";
            foreach (var s in servers)
            {
                servers_formatted += " SERVER=" + s;
            }
            return string.Format("+HSPOST{0}\r\n{1}\r\n.\r\n", servers_formatted, descriptor);
        }
    }
}