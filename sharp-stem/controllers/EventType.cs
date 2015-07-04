using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp_stem.controllers
{

    public enum EventType
    {
        ADDRMAP,
        AUTHDIR_NEWDESCS,
        BUILDTIMEOUT_SET,
        BW,
        CELL_STATS,
        CIRC,
        CIRC_BW,
        CIRC_MINOR,
        CONF_CHANGED,
        CONN_BW,
        CLIENTS_SEEN,
        DEBUG,
        DESCCHANGED,
        ERR,
        GUARD,
        HS_DESC,
        HS_DESC_CONTENT,
        INFO,
        NETWORK_LIVENESS,
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
        TB_EMPTY,
        TRANSPORT_LAUNCHED,
        WARN
    }
}
