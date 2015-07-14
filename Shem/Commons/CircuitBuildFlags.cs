using System;

namespace Shem.Commons
{
    [Flags]
    public enum CircuitBuildFlags
    {
        ONEHOP_TUNNEL,
        IS_INTERNAL,
        NEED_CAPACITY,
        NEED_UPTIME
    }
}
