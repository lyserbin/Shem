using Shem.Utils;
using System;
using System.Text;

namespace Shem.Commands
{
    /// <summary>
    /// The command used to authenticate with TOR
    /// </summary>
    public class AUTHENTICATE : TCCommand
    {
        private bool ishex = false;
        private string password = "";

        /// <summary>
        /// Create a new Authentication message
        /// </summary>
        /// <param name="password">The give password as plain text or hex</param>
        /// <param name="ishex">If you provided an hex password you have to set 'true' here</param>
        public AUTHENTICATE(string password = "", bool ishex = false)
        {
            this.password = password;
            this.ishex = ishex;
        }

        public override string Raw()
        {
            // TODO: autohash unhashed password (hard to implement s2k on .NET)
            return password == "" ? "AUTHENTICATE\r\n" :
                string.Format("AUTHENTICATE {0}\r\n", ishex ? password :
                BitConverter.ToString(Encoding.UTF8.GetBytes(password)).Replace("-", "")); // << this fucking sucks
        }
    }
}
