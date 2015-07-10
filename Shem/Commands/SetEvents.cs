
namespace Shem.Commands
{
    /// <summary>
    /// Request the server to inform the client about interesting events.
    /// </summary>
    public class SetEvents : TCCommand
    {
        private bool extended;
        private Shem.AsyncEvents.AsyncEvents[] events;

        /// <summary>
        /// Request the server to inform the client about interesting events. Any events *not* listed in the SETEVENTS line are turned off, sending SETEVENTS without events turns off all event reporting.
        /// </summary>
        /// <param name="extended"></param>
        /// <param name="events">If "EXTENDED" is provided, Tor may provide extra information with events for this connection.</param>
        public SetEvents(bool extended = false, params Shem.AsyncEvents.AsyncEvents[] events)
        {
            this.events = events;
            this.extended = extended;
        }

        public override string Raw()
        {
            string formattedEvents = "";
            foreach (var e in events)
            {
                formattedEvents += " " + e.ToString();
            }
            return string.Format("SETEVENTS{0}{1}\r\n", extended ? " EXTENDED" : "", formattedEvents);
        }
    }
}