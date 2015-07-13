
namespace Shem.Commands
{
    /// <summary>
    /// Same as passing 'EXTENDED' to SETEVENTS; this is the preferred way to request the extended event syntax.
    /// </summary>
    public class ExtendedEvents : TCCommand
    {
        private Shem.AsyncEvents.TorEvents[] events;

        /// <summary>
        /// Same as passing 'EXTENDED' to SETEVENTS; this is the preferred way to request the extended event syntax.
        /// </summary>
        /// <param name="events"></param>
        public ExtendedEvents(params Shem.AsyncEvents.TorEvents[] events)
        {
            this.events = events;
        }

        public override string Raw()
        {
            string formattedEvents = "";
            foreach (var e in events)
            {
                formattedEvents += " " + e.ToString();
            }
            return string.Format("EXTENDED_EVENTS{1}\r\n", formattedEvents);
        }
    }
}