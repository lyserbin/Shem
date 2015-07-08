using Shem.Commands.Enums;

namespace Shem.Commands
{
    /// <summary>
    /// Tells the server to create a new Onion ("Hidden") Service
    /// </summary>
    public class ADD_ONION : TCCommand
    {
        private ONION_KeyTypes keyType;
        private ONION_KeyBlobs keyBlob;
        private string privateKey;
        private ONION_Flags[] flags;
        private string virtualPort;
        private string targetPort = "";

        /// <summary>
        /// Tells the server to create a new Onion ("Hidden") Service
        /// </summary>
        /// <param name="keyType"></param>
        /// <param name="keyBlob"></param>
        /// <param name="privateKey">A serialized private key (without whitespace) (leave it blank if not ketType = NEW and keyBlob = String)</param>
        /// <param name="flags"></param>
        /// <param name="virtualPort">The virtual TCP Port for the Onion Service (As in the HiddenServicePort "VIRTPORT" argument).</param>
        /// <param name="targetPort">he (optional) target for the given VirtPort (As in the optional HiddenServicePort "TARGET" argument).</param>
        public ADD_ONION(ONION_KeyTypes keyType, ONION_KeyBlobs keyBlob, string privateKey, string virtualPort, string targetPort = "", params ONION_Flags[] flags)
        {
            this.keyType = keyType;
            this.keyBlob = keyBlob;
            this.privateKey = privateKey;
            this.flags = flags;
            this.virtualPort = virtualPort;
            this.targetPort = targetPort;
        }

        public override string Raw()
        {
            string formattedKeyBlob = "";
            if (keyBlob != ONION_KeyBlobs.String)
            {
                formattedKeyBlob = keyBlob.ToString();
            }
            else
            {
                formattedKeyBlob = privateKey;
            }

            string formattedFlags = "";
            if (flags.Length > 0)
            {
                formattedFlags += " Flags=" + flags[0].ToString();
                if (flags.Length > 1)
                {
                    for (int i = 1; i < flags.Length; i++)
                    {
                        formattedFlags += "," + flags[i];
                    }
                }
            }

            return string.Format("ADD_ONION {0}:{1}{2} Port={3}{4}\r\n", keyType.ToString(), formattedKeyBlob, formattedFlags, virtualPort, targetPort == "" ? "" : "," + targetPort);
        }
    }
}