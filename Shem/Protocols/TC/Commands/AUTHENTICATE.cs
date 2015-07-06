
namespace Shem.Protocols.TC.Commands
{
    public class AUTHENTICATE : TCCommand
    {
        private string token = "";

        public AUTHENTICATE(string token = "")
        {
            this.token = token;
        }

        public override string Raw()
        {
            return token == "" ? "AUTHENTICATE\r\n" : string.Format("AUTHENTICATE {0}\r\n", token);
        }
    }
}
