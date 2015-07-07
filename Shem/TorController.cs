namespace Shem
{
    public class TorController : BaseController
    {
        public TorController(string address = "127.0.0.1", uint port = 9051, bool connect = true) : base(address, port, connect) { }

    }
}
