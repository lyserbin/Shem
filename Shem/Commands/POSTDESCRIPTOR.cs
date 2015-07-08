
namespace Shem.Commands
{
    /// <summary>
    /// This message informs the server about a new descriptor.
    /// </summary>
    class POSTDESCRIPTOR : TCCommand
    {
        private POSTDESCRIPTOR_Purpose purpose;
        private bool cache;
        private string descriptor;

        /// <summary>
        /// This message informs the server about a new descriptor.
        /// </summary>
        /// <param name="purpose"></param>
        /// <param name="cache"></param>
        /// <param name="descriptor">The descriptor, when parsed, must contain a number of well-specified fields, including fields for its nickname and identity.</param>
        public POSTDESCRIPTOR(string descriptor, POSTDESCRIPTOR_Purpose purpose = POSTDESCRIPTOR_Purpose.general, bool cache = false)
        {
            this.purpose = purpose;
            this.cache = cache;
            this.descriptor = descriptor;
        }

        public override string Raw()
        {
            return string.Format("+POSTDESCRIPTOR purpose={0} cache={1}\r\n{2}\r\n.\r\n", purpose.ToString(), cache ? "yes" : "no", descriptor);
        }
    }
}