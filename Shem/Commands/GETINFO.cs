
using System;
namespace Shem.Commands
{
    public class GETINFO : TCCommand
    {
        string[] keywords;
        public GETINFO(params string[] keywords)
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

            return string.Format("GETINFO{0}\r\n", keys);
        }
    }
}
