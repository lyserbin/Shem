namespace Shem.Commands
{
    /// <summary>
    /// Configs availables for GETCONF command.
    /// </summary>
    public enum Configs
    {
        SocksPort,

        SocksPolicy,

        MaxMemInQueues,

        Log,

        RunAsDaemon,

        DataDirectory,

        ControlPort,

        HashedControlPassword,

        CookieAuthentication,

        HiddenServiceDir,

        HiddenServicePort,

        ORPort,

        Address,

        OutboundBindAddress,

        Nickname,

        RelayBandwidthRate,

        RelayBandwidthBurst,

        AccountingMax,

        AccountingStart,

        ContactInfo,

        DirPort,

        DirPortFrontPage,

        MyFamily,

        ExitPolicy,

        BridgeRelay,

        PublishServerDescriptor
    }
}
