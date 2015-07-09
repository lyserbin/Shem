using System;

namespace Shem.Commands
{
    /// <summary>
    /// Change the value of one configuration variables if the value is empty set the default value.
    /// </summary>
    public class ResetConf : TCCommand
    {
        private Configs[] configs;
        private string[] values;

        /// <summary>
        /// Change the value of one configuration variables if the value is empty set the default value.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        public ResetConf(Configs config, string value = "")
        {
            this.configs = new Configs[] { config };
            this.values = new string[] { value };
        }

        public override string Raw()
        {
            string command = (new Func<string>(() =>
            {
                string ks = "";
                for (var i = 0; i < configs.Length; i++)
                {
                    ks += string.Format(" {0}=\"{1}\"", configs[i], values[i]);
                }
                return ks;
            }))();
            return string.Format("RESETCONF{0}\r\n", command);
        }
    }
}