
using Shem.Utils;
namespace Shem.AsyncEvents
{
    public enum AsyncEvents
    {
        ADDRMAP,
        AUTHDIR_NEWDESCS,
        BUILDTIMEOUT_SET,
        BW,
        [TypeValue(typeof(CircEvent))]
        CIRC,
        CIRC_MINOR,
        CLIENTS_SEEN,
        CONF_CHANGED,
        DEBUG,
        DESCCHANGED,
        ERR,
        GUARD,
        INFO,
        NEWCONSENSUS,
        NEWDESC,
        NOTICE,
        NS,
        ORCONN,
        SIGNAL,
        STATUS_CLIENT,
        STATUS_GENERAL,
        STATUS_SERVER,
        STREAM,
        STREAM_BW,
        WARN,
        STATUS_SEVER
    }
}
