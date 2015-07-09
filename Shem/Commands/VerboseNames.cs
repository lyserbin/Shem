using System;

namespace Shem.Commands
{
    /// <summary>
    /// Replaces ServerID with LongName in events and GETINFO results. LongName provides a Fingerprint for all routers, an indication of Named status, and a Nickname if one is known. LongName is strictly more informative than ServerID, which only provides either a Fingerprint or a Nickname.
    /// </summary>
    public class VerboseNames : TCCommand
    {
        /// <summary>
        /// 
        /// </summary>
        public VerboseNames()
        {
            //TODO: Implement this, currently not documented in control-spec-otr-0.2.6.9.txt
        }

        public override string Raw()
        {
            throw new NotImplementedException();
        }
    }
}