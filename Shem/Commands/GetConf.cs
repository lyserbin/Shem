using System;

namespace Shem.Commands
{
    /// <summary>
    /// Request the value of a configuration variable.
    /// </summary>
    public class GetConf : TCCommand
    {
        private string configs;

        /// <summary>
        /// Request the value of a configuration variable.
        /// </summary>
        /// <param name="configs"></param>
        public GetConf(string configs)
        {
            this.configs = configs;
        }

        /// <summary>
        /// Request the value of a configuration variable.
        /// </summary>
        /// <param name="configs"></param>
        public GetConf(params Configs[] configs)
        {
            this.configs = new Func<string>(() =>
            {
                string ks = "";
                foreach (var k in configs)
                {
                    ks += " " + k.ToString();
                }
                return ks;
            })();
        }

        public override string Raw()
        {
            return string.Format("GETCONF{0}\r\n", configs);
        }
    }
}
