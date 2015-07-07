namespace Shem.Commands
{
    public class QUIT : TCCommand
    {

        public override string Raw()
        {
            return "QUIT\r\n";
        }
    }
}
