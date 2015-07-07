
namespace Shem.Commands
{
    public class SETCONF : TCCommand
    {
        /// <summary>
        /// Configurations availables for SETCONF command.
        /// </summary>
        public enum Configs
        {
            SocksPort,

            SocksPolicy,

            MaxMemInQueues,

            Log,

            RunAsDaemon,

            DataDirectory,

            ControlPort,

            HashedControlPassword,

            CookieAuthentication,

            HiddenServiceDir,

            HiddenServicePort,

            ORPort,

            Address,

            OutboundBindAddress,

            Nickname,

            RelayBandwidthRate,

            RelayBandwidthBurst,

            AccountingMax,

            AccountingStart,

            ContactInfo,

            DirPort,

            DirPortFrontPage,

            MyFamily,

            ExitPolicy,

            BridgeRelay,

            PublishServerDescriptor
        }

        private Configs configs;

        private string value;

        /// <summary>
        /// Change the value of one configuration variables.
        /// </summary>
        /// <param name="configs"></param>
        /// <param name="value"></param>
        public SETCONF(Configs configs, string value)
        {
            this.configs = configs;

            this.value = value;
        }

        public override string Raw()
        {
            return string.Format("SETCONF {0}=\"{1}\"\r\n", configs.ToString(), value);
        }
    }
}
