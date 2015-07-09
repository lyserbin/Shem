
using System;
namespace Shem.Commands
{
    public class SetConf : TCCommand
    {
        private Configs[] configs;
        private string[] values;

        /// <summary>
        /// Change the value of one configuration variables.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        public SetConf(Configs config, string value)
        {
            this.configs = new Configs[] { config };
            this.values = new string[] { value };
        }

        //TODO: Find a solution to set multiple parameters
        /// <summary>
        /// Change the values of one or more configuration variables.
        /// </summary>
        /// <param name="configs"></param>
        /// <param name="values"></param>
        //public SETCONF(params Configs[] configs, params string[] values)
        //{
        //    this.configs = configs;
        //    this.values = values;
        //}

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
            return string.Format("SETCONF{0}\r\n", command);
        }
    }
}
