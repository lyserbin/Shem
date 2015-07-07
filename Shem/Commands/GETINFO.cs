using System;
using Shem.Utils;

namespace Shem.Commands
{
    public class GETINFO : TCCommand
    {
        private string info = "";

        /// <summary>
        /// Returns requested informations about tor instance.
        /// </summary>
        /// <param name="informations"></param>
        public GETINFO(params Informations[] informations)
        {
            this.info = (new Func<string>(() =>
            {
                string ks = "";
                foreach (var k in informations)
                {
                    ks += " " + k.GetStringValue();
                }
                return ks;
            }))();
        }

        /// <summary>
        /// Returns requested informations about tor instance.
        /// </summary>
        /// <param name="informations"></param>
        public GETINFO(string informations)
        {
            this.info = informations;
        }

        public override string Raw()
        {
            return string.Format("GETINFO{0}\r\n", info);
        }
    }
}