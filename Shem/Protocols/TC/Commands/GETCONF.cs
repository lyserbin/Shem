using System;

namespace Shem.Protocols.TC.Commands
{
    public class GETCONF : TCCommand
    {
        string[] keywords;
        public GETCONF(params string[] keywords)
        {
            this.keywords = keywords;
        }

        public override string Raw()
        {
            string keys = (new Func<string>(() =>
            {
                string ks = "";
                foreach (var k in keywords)
                {
                    ks += " " + k;
                }
                return ks;
            }))();

            return string.Format("GETCONF{0}\r\n", keys);
        }
    }
}
