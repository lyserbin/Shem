using System;

namespace Shem.Commands
{
    /// <summary>
    /// This command was disabled and made obsolete as of Tor 0.2.0.8-alpha. It doesn't exist anymore, and is listed here only for historical interest.
    /// </summary>
    public class SetRouterPurpose : TCCommand
    {
        /// <summary>
        /// This command was disabled and made obsolete as of Tor 0.2.0.8-alpha. It doesn't exist anymore, and is listed here only for historical interest.
        /// </summary>
        public SetRouterPurpose()
        {

        }

        public override string Raw()
        {
            throw new NotImplementedException();
        }
    }
}