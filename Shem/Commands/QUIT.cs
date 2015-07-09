namespace Shem.Commands
{
    public class Quit : TCCommand
    {

        public override string Raw()
        {
            return "QUIT\r\n";
        }
    }
}
