namespace Shem.Commands
{
    /// <summary>
    /// Configs availables for *CONF commands.
    /// </summary>
    public enum Configs
    {
        /// <summary>
        /// <para>BandwidthRate N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>A token bucket limits the average incoming bandwidth usage on this node to</para>
        /// <para>the specified number of bytes per second, and the average outgoing</para>
        /// <para>bandwidth usage to that same value.  If you want to run a relay in the</para>
        /// <para>public network, this needs to be at the very least 30 KBytes (that is,</para>
        /// <para>30720 bytes). (Default: 1 GByte)</para>
        /// <para>&#160;</para>
        /// <para>With this option, and in other options that take arguments in bytes,</para>
        /// <para>KBytes, and so on, other formats are also supported. Notably, "KBytes" can</para>
        /// <para>also be written as "kilobytes" or "kb"; "MBytes" can be written as</para>
        /// <para>"megabytes" or "MB"; "kbits" can be written as "kilobits"; and so forth.</para>
        /// <para>Tor also accepts "byte" and "bit" in the singular.</para>
        /// <para>The prefixes "tera" and "T" are also recognized.</para>
        /// <para>If no units are given, we default to bytes.</para>
        /// <para>To avoid confusion, we recommend writing "bytes" or "bits" explicitly,</para>
        /// <para>since it's easy to forget that "B" means bytes, not bits.</para>
        /// </summary>
        BandwidthRate,

        /// <summary>
        /// <para>BandwidthBurst N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>Limit the maximum token bucket size (also known as the burst) to the given</para>
        /// <para>number of bytes in each direction. (Default: 1 GByte)</para>
        /// </summary>
        BandwidthBurst,

        /// <summary>
        /// <para>MaxAdvertisedBandwidth N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>If set, we will not advertise more than this amount of bandwidth for our</para>
        /// <para>BandwidthRate. Server operators who want to reduce the number of clients</para>
        /// <para>who ask to build circuits through them (since this is proportional to</para>
        /// <para>advertised bandwidth rate) can thus reduce the CPU demands on their server</para>
        /// <para>without impacting network performance.</para>
        /// </summary>
        MaxAdvertisedBandwidth,

        /// <summary>
        /// <para>RelayBandwidthRate N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>If not 0, a separate token bucket limits the average incoming bandwidth</para>
        /// <para>usage for relayed traffic on this node to the specified number of bytes</para>
        /// <para>per second, and the average outgoing bandwidth usage to that same value.</para>
        /// <para>Relayed traffic currently is calculated to include answers to directory</para>
        /// <para>requests, but that may change in future versions. (Default: 0)</para>
        /// </summary>
        RelayBandwidthRate,

        /// <summary>
        /// <para>RelayBandwidthBurst N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>If not 0, limit the maximum token bucket size (also known as the burst) for</para>
        /// <para>relayed traffic to the given number of bytes in each direction.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        RelayBandwidthBurst,

        /// <summary>
        /// <para>PerConnBWRate N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>If set, do separate rate limiting for each connection from a non-relay.</para>
        /// <para>You should never need to change this value, since a network-wide value is</para>
        /// <para>published in the consensus and your relay will use that value. (Default: 0)</para>
        /// </summary>
        PerConnBWRate,

        /// <summary>
        /// <para>PerConnBWBurst N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>If set, do separate rate limiting for each connection from a non-relay.</para>
        /// <para>You should never need to change this value, since a network-wide value is</para>
        /// <para>published in the consensus and your relay will use that value. (Default: 0)</para>
        /// </summary>
        PerConnBWBurst,

        /// <summary>
        /// <para>ClientTransportPlugin transport socks4|socks5 IP:PORT</para>
        /// <para>&#160;</para>
        /// <para>In its first form, when set along with a corresponding Bridge line, the Tor</para>
        /// <para>client forwards its traffic to a SOCKS-speaking proxy on "IP:PORT". It's the</para>
        /// <para>duty of that proxy to properly forward the traffic to the bridge.</para>
        /// <para>&#160;</para>
        /// <para>In its second form, when set along with a corresponding Bridge line, the Tor</para>
        /// <para>client launches the pluggable transport proxy executable in</para>
        /// <para>path-to-binary using options as its command-line options, and</para>
        /// <para>forwards its traffic to it. It's the duty of that proxy to properly forward</para>
        /// <para>the traffic to the bridge.</para>
        /// </summary>
        ClientTransportPlugin,

        /// <summary>
        /// <para>ServerTransportPlugin transport exec path-to-binary [options]</para>
        /// <para>&#160;</para>
        /// <para>The Tor relay launches the pluggable transport proxy in path-to-binary</para>
        /// <para>using options as its command-line options, and expects to receive</para>
        /// <para>proxied client traffic from it.</para>
        /// </summary>
        ServerTransportPlugin,

        /// <summary>
        /// <para>ServerTransportListenAddr transport IP:PORT</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, Tor will suggest IP:PORT as the</para>
        /// <para>listening address of any pluggable transport proxy that tries to</para>
        /// <para>launch transport.</para>
        /// </summary>
        ServerTransportListenAddr,

        /// <summary>
        /// <para>ServerTransportOptions transport k=v k=v ...</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, Tor will pass the k=v parameters to</para>
        /// <para>any pluggable transport proxy that tries to launch transport.</para>
        /// <para>(Example: ServerTransportOptions obfs45 shared-secret=bridgepasswd cache=/var/lib/tor/cache)</para>
        /// </summary>
        ServerTransportOptions,

        /// <summary>
        /// <para>ExtORPort ['address':]port|auto</para>
        /// <para>&#160;</para>
        /// <para>Open this port to listen for Extended ORPort connections from your</para>
        /// <para>pluggable transports.</para>
        /// </summary>
        ExtORPort,

        /// <summary>
        /// <para>ExtORPortCookieAuthFile Path</para>
        /// <para>&#160;</para>
        /// <para>If set, this option overrides the default location and file name</para>
        /// <para>for the Extended ORPort's cookie file -- the cookie file is needed</para>
        /// <para>for pluggable transports to communicate through the Extended ORPort.</para>
        /// </summary>
        ExtORPortCookieAuthFile,

        /// <summary>
        /// <para>ExtORPortCookieAuthFileGroupReadable 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 0, don't allow the filesystem group to read the</para>
        /// <para>Extended OR Port cookie file. If the option is set to 1, make the cookie</para>
        /// <para>file readable by the default GID. [Making the file readable by other</para>
        /// <para>groups is not yet implemented; let us know if you need this for some</para>
        /// <para>reason.] (Default: 0)</para>
        /// </summary>
        ExtORPortCookieAuthFileGroupReadable,

        /// <summary>
        /// <para>ConnLimit NUM</para>
        /// <para>&#160;</para>
        /// <para>The minimum number of file descriptors that must be available to the Tor</para>
        /// <para>process before it will start. Tor will ask the OS for as many file</para>
        /// <para>descriptors as the OS will allow (you can find this by "ulimit -H -n").</para>
        /// <para>If this number is less than ConnLimit, then Tor will refuse to start.</para>
        /// <para>&#160;</para>
        /// <para>You probably don't need to adjust this. It has no effect on Windows</para>
        /// <para>since that platform lacks getrlimit(). (Default: 1000)</para>
        /// </summary>
        ConnLimit,

        /// <summary>
        /// <para>DisableNetwork 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, we don't listen for or accept any connections</para>
        /// <para>other than controller connections, and we close (and don't reattempt)</para>
        /// <para>any outbound</para>
        /// <para>connections.  Controllers sometimes use this option to avoid using</para>
        /// <para>the network until Tor is fully configured. (Default: 0)</para>
        /// </summary>
        DisableNetwork,

        /// <summary>
        /// <para>ConstrainedSockets 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set, Tor will tell the kernel to attempt to shrink the buffers for all</para>
        /// <para>sockets to the size specified in ConstrainedSockSize. This is useful for</para>
        /// <para>virtual servers and other environments where system level TCP buffers may</para>
        /// <para>be limited. If you're on a virtual server, and you encounter the "Error</para>
        /// <para>creating network socket: No buffer space available" message, you are</para>
        /// <para>likely experiencing this problem.</para>
        /// <para>&#160;</para>
        /// <para>The preferred solution is to have the admin increase the buffer pool for</para>
        /// <para>the host itself via /proc/sys/net/ipv4/tcpmem or equivalent facility;</para>
        /// <para>this configuration option is a second-resort.</para>
        /// <para>&#160;</para>
        /// <para>The DirPort option should also not be used if TCP buffers are scarce. The</para>
        /// <para>cached directory requests consume additional sockets which exacerbates</para>
        /// <para>the problem.</para>
        /// <para>&#160;</para>
        /// <para>You should not enable this feature unless you encounter the "no buffer</para>
        /// <para>space available" issue. Reducing the TCP buffers affects window size for</para>
        /// <para>the TCP stream and will reduce throughput in proportion to round trip</para>
        /// <para>time on long paths. (Default: 0)</para>
        /// </summary>
        ConstrainedSockets,

        /// <summary>
        /// <para>ConstrainedSockSize N bytes|KBytes</para>
        /// <para>&#160;</para>
        /// <para>When ConstrainedSockets is enabled the receive and transmit buffers for</para>
        /// <para>all sockets will be set to this limit. Must be a value between 2048 and</para>
        /// <para>262144, in 1024 byte increments. Default of 8192 is recommended.</para>
        /// </summary>
        ConstrainedSockSize,

        /// <summary>
        /// <para>ControlPort PORT|unix:path|auto</para>
        /// <para>&#160;</para>
        /// <para>If set, Tor will accept connections on this port and allow those</para>
        /// <para>connections to control the Tor process using the Tor Control Protocol</para>
        /// <para>(described in control-spec.txt). Note: unless you also specify one or</para>
        /// <para>more of HashedControlPassword or CookieAuthentication,</para>
        /// <para>setting this option will cause Tor to allow any process on the local</para>
        /// <para>host to control it. (Setting both authentication methods means either</para>
        /// <para>method is sufficient to authenticate to Tor.) This</para>
        /// <para>option is required for many Tor controllers; most use the value of 9051.</para>
        /// <para>Set it to "auto" to have Tor pick a port for you. (Default: 0)</para>
        /// </summary>
        ControlPort,

        /// <summary>
        /// <para>ControlListenAddress IP[:PORT]</para>
        /// <para>&#160;</para>
        /// <para>Bind the controller listener to this address. If you specify a port, bind</para>
        /// <para>to this port rather than the one specified in ControlPort. We strongly</para>
        /// <para>recommend that you leave this alone unless you know what you're doing,</para>
        /// <para>since giving attackers access to your control listener is really</para>
        /// <para>dangerous. This directive can be specified multiple</para>
        /// <para>times to bind to multiple addresses/ports.  (Default: 127.0.0.1)</para>
        /// </summary>
        ControlListenAddress,

        /// <summary>
        /// <para>ControlSocket Path</para>
        /// <para>&#160;</para>
        /// <para>Like ControlPort, but listens on a Unix domain socket, rather than a TCP</para>
        /// <para>socket. '0' disables ControlSocket (Unix and Unix-like systems only.)</para>
        /// </summary>
        ControlSocket,

        /// <summary>
        /// <para>ControlSocketsGroupWritable 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 0, don't allow the filesystem group to read and</para>
        /// <para>write unix sockets (e.g. ControlSocket). If the option is set to 1, make</para>
        /// <para>the control socket readable and writable by the default GID. (Default: 0)</para>
        /// </summary>
        ControlSocketsGroupWritable,

        /// <summary>
        /// <para>HashedControlPassword hashedpassword</para>
        /// <para>&#160;</para>
        /// <para>Allow connections on the control port if they present</para>
        /// <para>the password whose one-way hash is hashedpassword. You</para>
        /// <para>can compute the hash of a password by running "tor --hash-password</para>
        /// <para>password". You can provide several acceptable passwords by using more</para>
        /// <para>than one HashedControlPassword line.</para>
        /// </summary>
        HashedControlPassword,

        /// <summary>
        /// <para>CookieAuthentication 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 1, allow connections on the control port</para>
        /// <para>when the connecting process knows the contents of a file named</para>
        /// <para>"controlauthcookie", which Tor will create in its data directory. This</para>
        /// <para>authentication method should only be used on systems with good filesystem</para>
        /// <para>security. (Default: 0)</para>
        /// </summary>
        CookieAuthentication,

        /// <summary>
        /// <para>CookieAuthFile Path</para>
        /// <para>&#160;</para>
        /// <para>If set, this option overrides the default location and file name</para>
        /// <para>for Tor's cookie file. (See CookieAuthentication above.)</para>
        /// </summary>
        CookieAuthFile,

        /// <summary>
        /// <para>CookieAuthFileGroupReadable 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 0, don't allow the filesystem group to read the</para>
        /// <para>cookie file. If the option is set to 1, make the cookie file readable by</para>
        /// <para>the default GID. [Making the file readable by other groups is not yet</para>
        /// <para>implemented; let us know if you need this for some reason.] (Default: 0)</para>
        /// </summary>
        CookieAuthFileGroupReadable,

        /// <summary>
        /// <para>ControlPortWriteToFile Path</para>
        /// <para>&#160;</para>
        /// <para>If set, Tor writes the address and port of any control port it opens to</para>
        /// <para>this address.  Usable by controllers to learn the actual control port</para>
        /// <para>when ControlPort is set to "auto".</para>
        /// </summary>
        ControlPortWriteToFile,

        /// <summary>
        /// <para>ControlPortFileGroupReadable 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 0, don't allow the filesystem group to read the</para>
        /// <para>control port file. If the option is set to 1, make the control port</para>
        /// <para>file readable by the default GID. (Default: 0)</para>
        /// </summary>
        ControlPortFileGroupReadable,

        /// <summary>
        /// <para>DataDirectory DIR</para>
        /// <para>&#160;</para>
        /// <para>Store working data in DIR (Default: @LOCALSTATEDIR@/lib/tor)</para>
        /// </summary>
        DataDirectory,

        /// <summary>
        /// <para>FallbackDir address:port orport=port id=fingerprint [weight=num]</para>
        /// <para>&#160;</para>
        /// <para>When we're unable to connect to any directory cache for directory info</para>
        /// <para>(usually because we don't know about any yet) we try a FallbackDir.</para>
        /// <para>By default, the directory authorities are also FallbackDirs.</para>
        /// </summary>
        FallbackDir,

        /// <summary>
        /// <para>DirAuthority [nickname] [flags] address:port fingerprint</para>
        /// <para>&#160;</para>
        /// <para>Use a nonstandard authoritative directory server at the provided address</para>
        /// <para>and port, with the specified key fingerprint. This option can be repeated</para>
        /// <para>many times, for multiple authoritative directory servers. Flags are</para>
        /// <para>separated by spaces, and determine what kind of an authority this directory</para>
        /// <para>is. By default, an authority is not authoritative for any directory style</para>
        /// <para>or version unless an appropriate flag is given.</para>
        /// <para>Tor will use this authority as a bridge authoritative directory if the</para>
        /// <para>"bridge" flag is set. If a flag "orport=port" is given, Tor will use the</para>
        /// <para>given port when opening encrypted tunnels to the dirserver. If a flag</para>
        /// <para>"weight=num" is given, then the directory server is chosen randomly</para>
        /// <para>with probability proportional to that weight (default 1.0). Lastly, if a</para>
        /// <para>flag "v3ident=fp" is given, the dirserver is a v3 directory authority</para>
        /// <para>whose v3 long-term signing key has the fingerprint fp.</para>
        /// <para>&#160;</para>
        /// <para>If no DirAuthority line is given, Tor will use the default directory</para>
        /// <para>authorities. NOTE: this option is intended for setting up a private Tor</para>
        /// <para>network with its own directory authorities. If you use it, you will be</para>
        /// <para>distinguishable from other users, because you won't believe the same</para>
        /// <para>authorities they do.</para>
        /// </summary>
        DirAuthority,

        /// <summary>
        /// <para>DirAuthorityFallbackRate NUM</para>
        /// <para>&#160;</para>
        /// <para>When configured to use both directory authorities and fallback</para>
        /// <para>directories, the directory authorities also work as fallbacks. They are</para>
        /// <para>chosen with their regular weights, multiplied by this number, which</para>
        /// <para>should be 1.0 or less. (Default: 1.0)</para>
        /// </summary>
        DirAuthorityFallbackRate,

        /// <summary>
        /// <para>AlternateDirAuthority [nickname] [flags] address:port fingerprint</para>
        /// <para>&#160;</para>
        /// </summary>
        AlternateDirAuthority,

        /// <summary>
        /// <para>AlternateBridgeAuthority [nickname] [flags] address:port  fingerprint</para>
        /// <para>&#160;</para>
        /// <para>These options behave as DirAuthority, but they replace fewer of the</para>
        /// <para>default directory authorities. Using</para>
        /// <para>AlternateDirAuthority replaces the default Tor directory authorities, but</para>
        /// <para>leaves the default bridge authorities in</para>
        /// <para>place.  Similarly,</para>
        /// <para>AlternateBridgeAuthority replaces the default bridge authority,</para>
        /// <para>but leaves the directory authorities alone.</para>
        /// </summary>
        AlternateBridgeAuthority,

        /// <summary>
        /// <para>DisableAllSwap 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor will attempt to lock all current and future memory pages,</para>
        /// <para>so that memory cannot be paged out. Windows, OS X and Solaris are currently</para>
        /// <para>not supported. We believe that this feature works on modern Gnu/Linux</para>
        /// <para>distributions, and that it should work on BSD systems (untested). This</para>
        /// <para>option requires that you start your Tor as root, and you should use the</para>
        /// <para>User option to properly reduce Tor's privileges. (Default: 0)</para>
        /// </summary>
        DisableAllSwap,

        /// <summary>
        /// <para>DisableDebuggerAttachment 0|1</para>
        /// <para>&#160;</para>
        /// <para>f set to 1, Tor will attempt to prevent basic debugging attachment attempts</para>
        /// <para>y other processes. This may also keep Tor from generating core files if</para>
        /// <para>t crashes. It has no impact for users who wish to attach if they</para>
        /// <para>ave CAPSYSPTRACE or if they are root.  We believe that this feature</para>
        /// <para>orks on modern Gnu/Linux distributions, and that it may also work on BSD</para>
        /// <para>ystems (untested).  Some modern Gnu/Linux systems such as Ubuntu have the</para>
        /// <para>ernel.yama.ptracescope sysctl and by default enable it as an attempt to</para>
        /// <para>imit the PTRACE scope for all user processes by default. This feature will</para>
        /// <para>ttempt to limit the PTRACE scope for Tor specifically - it will not attempt</para>
        /// <para>o alter the system wide ptrace scope as it may not even exist. If you wish</para>
        /// <para>o attach to Tor with a debugger such as gdb or strace you will want to set</para>
        /// <para>his to 0 for the duration of your debugging. Normal users should leave it</para>
        /// <para>n. Disabling this option while Tor is running is prohibited. (Default: 1)</para>
        /// </summary>
        DisableDebuggerAttachment,

        /// <summary>
        /// <para>FetchDirInfoEarly 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor will always fetch directory information like other</para>
        /// <para>directory caches, even if you don't meet the normal criteria for fetching</para>
        /// <para>early. Normal users should leave it off. (Default: 0)</para>
        /// </summary>
        FetchDirInfoEarly,

        /// <summary>
        /// <para>FetchDirInfoExtraEarly 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor will fetch directory information before other directory</para>
        /// <para>caches. It will attempt to download directory information closer to the</para>
        /// <para>start of the consensus period. Normal users should leave it off.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        FetchDirInfoExtraEarly,

        /// <summary>
        /// <para>FetchHidServDescriptors 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 0, Tor will never fetch any hidden service descriptors from the</para>
        /// <para>rendezvous directories. This option is only useful if you're using a Tor</para>
        /// <para>controller that handles hidden service fetches for you. (Default: 1)</para>
        /// </summary>
        FetchHidServDescriptors,

        /// <summary>
        /// <para>FetchServerDescriptors 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 0, Tor will never fetch any network status summaries or server</para>
        /// <para>descriptors from the directory servers. This option is only useful if</para>
        /// <para>you're using a Tor controller that handles directory fetches for you.</para>
        /// <para>(Default: 1)</para>
        /// </summary>
        FetchServerDescriptors,

        /// <summary>
        /// <para>FetchUselessDescriptors 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor will fetch every non-obsolete descriptor from the</para>
        /// <para>authorities that it hears about. Otherwise, it will avoid fetching useless</para>
        /// <para>descriptors, for example for routers that are not running. This option is</para>
        /// <para>useful if you're using the contributed "exitlist" script to enumerate Tor</para>
        /// <para>nodes that exit to certain addresses. (Default: 0)</para>
        /// </summary>
        FetchUselessDescriptors,

        /// <summary>
        /// <para>HTTPProxy host[:port]</para>
        /// <para>&#160;</para>
        /// <para>Tor will make all its directory requests through this host:port (or host:80</para>
        /// <para>if port is not specified), rather than connecting directly to any directory</para>
        /// <para>servers.</para>
        /// </summary>
        HTTPProxy,

        /// <summary>
        /// <para>HTTPProxyAuthenticator username:password</para>
        /// <para>&#160;</para>
        /// <para>If defined, Tor will use this username:password for Basic HTTP proxy</para>
        /// <para>authentication, as in RFC 2617. This is currently the only form of HTTP</para>
        /// <para>proxy authentication that Tor supports; feel free to submit a patch if you</para>
        /// <para>want it to support others.</para>
        /// </summary>
        HTTPProxyAuthenticator,

        /// <summary>
        /// <para>HTTPSProxy host[:port]</para>
        /// <para>&#160;</para>
        /// <para>Tor will make all its OR (SSL) connections through this host:port (or</para>
        /// <para>host:443 if port is not specified), via HTTP CONNECT rather than connecting</para>
        /// <para>directly to servers. You may want to set FascistFirewall to restrict</para>
        /// <para>the set of ports you might try to connect to, if your HTTPS proxy only</para>
        /// <para>allows connecting to certain ports.</para>
        /// </summary>
        HTTPSProxy,

        /// <summary>
        /// <para>HTTPSProxyAuthenticator username:password</para>
        /// <para>&#160;</para>
        /// <para>If defined, Tor will use this username:password for Basic HTTPS proxy</para>
        /// <para>authentication, as in RFC 2617. This is currently the only form of HTTPS</para>
        /// <para>proxy authentication that Tor supports; feel free to submit a patch if you</para>
        /// <para>want it to support others.</para>
        /// </summary>
        HTTPSProxyAuthenticator,

        /// <summary>
        /// <para>Sandbox 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor will run securely through the use of a syscall sandbox.</para>
        /// <para>Otherwise the sandbox will be disabled. The option is currently an</para>
        /// <para>experimental feature. (Default: 0)</para>
        /// </summary>
        Sandbox,

        /// <summary>
        /// <para>Socks4Proxy host[:port]</para>
        /// <para>&#160;</para>
        /// <para>Tor will make all OR connections through the SOCKS 4 proxy at host:port</para>
        /// <para>(or host:1080 if port is not specified).</para>
        /// </summary>
        Socks4Proxy,

        /// <summary>
        /// <para>Socks5Proxy host[:port]</para>
        /// <para>&#160;</para>
        /// <para>Tor will make all OR connections through the SOCKS 5 proxy at host:port</para>
        /// <para>(or host:1080 if port is not specified).</para>
        /// </summary>
        Socks5Proxy,

        /// <summary>
        /// <para>Socks5ProxyUsername username</para>
        /// <para>&#160;</para>
        /// </summary>
        Socks5ProxyUsername,

        /// <summary>
        /// <para>Socks5ProxyPassword password</para>
        /// <para>&#160;</para>
        /// <para>If defined, authenticate to the SOCKS 5 server using username and password</para>
        /// <para>in accordance to RFC 1929. Both username and password must be between 1 and</para>
        /// <para>255 characters.</para>
        /// </summary>
        Socks5ProxyPassword,

        /// <summary>
        /// <para>SocksSocketsGroupWritable 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 0, don't allow the filesystem group to read and</para>
        /// <para>write unix sockets (e.g. SocksSocket). If the option is set to 1, make</para>
        /// <para>the SocksSocket socket readable and writable by the default GID. (Default: 0)</para>
        /// </summary>
        SocksSocketsGroupWritable,

        /// <summary>
        /// <para>KeepalivePeriod NUM</para>
        /// <para>&#160;</para>
        /// <para>To keep firewalls from expiring connections, send a padding keepalive cell</para>
        /// <para>every NUM seconds on open connections that are in use. If the connection</para>
        /// <para>has no open circuits, it will instead be closed after NUM seconds of</para>
        /// <para>idleness. (Default: 5 minutes)</para>
        /// </summary>
        KeepalivePeriod,

        /// <summary>
        /// <para>Log minSeverity[-maxSeverity] stderr|stdout|syslog</para>
        /// <para>&#160;</para>
        /// <para>Send all messages between minSeverity and maxSeverity to the standard</para>
        /// <para>output stream, the standard error stream, or to the system log. (The</para>
        /// <para>"syslog" value is only supported on Unix.) Recognized severity levels are</para>
        /// <para>debug, info, notice, warn, and err. We advise using "notice" in most cases,</para>
        /// <para>since anything more verbose may provide sensitive information to an</para>
        /// <para>attacker who obtains the logs. If only one severity level is given, all</para>
        /// <para>messages of that level or higher will be sent to the listed destination.</para>
        /// </summary>
        Log,

        /// <summary>
        /// <para>Log minSeverity[-maxSeverity] file FILENAME</para>
        /// <para>&#160;</para>
        /// <para>As above, but send log messages to the listed filename. The</para>
        /// <para>"Log" option may appear more than once in a configuration file.</para>
        /// <para>Messages are sent to all the logs that match their severity</para>
        /// <para>level.</para>
        /// </summary>
        Log2,

        /// <summary>
        /// <para>Log [domain,...]minSeverity[-maxSeverity] ... file FILENAME</para>
        /// <para>&#160;</para>
        /// </summary>
        Log3,

        /// <summary>
        /// <para>Log [domain,...]minSeverity[-maxSeverity] ... stderr|stdout|syslog</para>
        /// <para>&#160;</para>
        /// <para>As above, but select messages by range of log severity and by a</para>
        /// <para>set of "logging domains".  Each logging domain corresponds to an area of</para>
        /// <para>functionality inside Tor.  You can specify any number of severity ranges</para>
        /// <para>for a single log statement, each of them prefixed by a comma-separated</para>
        /// <para>list of logging domains.  You can prefix a domain with $$~$$ to indicate</para>
        /// <para>negation, and use  to indicate "all domains".  If you specify a severity</para>
        /// <para>range without a list of domains, it matches all domains.</para>
        /// <para>&#160;</para>
        /// <para>This is an advanced feature which is most useful for debugging one or two</para>
        /// <para>of Tor's subsystems at a time.</para>
        /// <para>&#160;</para>
        /// <para>The currently recognized domains are: general, crypto, net, config, fs,</para>
        /// <para>protocol, mm, http, app, control, circ, rend, bug, dir, dirserv, or, edge,</para>
        /// <para>acct, hist, and handshake.  Domain names are case-insensitive.</para>
        /// <para>&#160;</para>
        /// <para>For example, "`Log [handshake]debug [~net,~mm]info notice stdout`" sends</para>
        /// <para>to stdout: all handshake messages of any severity, all info-and-higher</para>
        /// <para>messages from domains other than networking and memory management, and all</para>
        /// <para>messages of severity notice or higher.</para>
        /// </summary>
        Log4,

        /// <summary>
        /// <para>LogMessageDomains 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor includes message domains with each log message.  Every log</para>
        /// <para>message currently has at least one domain; most currently have exactly</para>
        /// <para>one.  This doesn't affect controller log messages. (Default: 0)</para>
        /// </summary>
        LogMessageDomains,

        /// <summary>
        /// <para>OutboundBindAddress IP</para>
        /// <para>&#160;</para>
        /// <para>Make all outbound connections originate from the IP address specified. This</para>
        /// <para>is only useful when you have multiple network interfaces, and you want all</para>
        /// <para>of Tor's outgoing connections to use a single one. This option may</para>
        /// <para>be used twice, once with an IPv4 address and once with an IPv6 address.</para>
        /// <para>This setting will be ignored for connections to the loopback addresses</para>
        /// <para>(127.0.0.0/8 and 1).</para>
        /// </summary>
        OutboundBindAddress,

        /// <summary>
        /// <para>PidFile FILE</para>
        /// <para>&#160;</para>
        /// <para>On startup, write our PID to FILE. On clean shutdown, remove</para>
        /// <para>FILE.</para>
        /// </summary>
        PidFile,

        /// <summary>
        /// <para>ProtocolWarnings 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor will log with severity 'warn' various cases of other parties not</para>
        /// <para>following the Tor specification. Otherwise, they are logged with severity</para>
        /// <para>'info'. (Default: 0)</para>
        /// </summary>
        ProtocolWarnings,

        /// <summary>
        /// <para>PredictedPortsRelevanceTime NUM</para>
        /// <para>&#160;</para>
        /// <para>Set how long, after the client has made an anonymized connection to a</para>
        /// <para>given port, we will try to make sure that we build circuits to</para>
        /// <para>exits that support that port. The maximum value for this option is 1</para>
        /// <para>hour. (Default: 1 hour)</para>
        /// </summary>
        PredictedPortsRelevanceTime,

        /// <summary>
        /// <para>RunAsDaemon 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor forks and daemonizes to the background. This option has no effect</para>
        /// <para>on Windows; instead you should use the --service command-line option.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        RunAsDaemon,

        /// <summary>
        /// <para>LogTimeGranularity NUM</para>
        /// <para>&#160;</para>
        /// <para>Set the resolution of timestamps in Tor's logs to NUM milliseconds.</para>
        /// <para>NUM must be positive and either a divisor or a multiple of 1 second.</para>
        /// <para>Note that this option only controls the granularity written by Tor to</para>
        /// <para>a file or console log.  Tor does not (for example) "batch up" log</para>
        /// <para>messages to affect times logged by a controller, times attached to</para>
        /// <para>syslog messages, or the mtime fields on log files.  (Default: 1 second)</para>
        /// </summary>
        LogTimeGranularity,

        /// <summary>
        /// <para>TruncateLogFile 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor will overwrite logs at startup and in response to a HUP signal,</para>
        /// <para>instead of appending to them. (Default: 0)</para>
        /// </summary>
        TruncateLogFile,

        /// <summary>
        /// <para>SafeLogging 0|1|relay</para>
        /// <para>&#160;</para>
        /// <para>Tor can scrub potentially sensitive strings from log messages (e.g.</para>
        /// <para>addresses) by replacing them with the string [scrubbed]. This way logs can</para>
        /// <para>still be useful, but they don't leave behind personally identifying</para>
        /// <para>information about what sites a user might have visited.</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 0, Tor will not perform any scrubbing, if it is</para>
        /// <para>set to 1, all potentially sensitive strings are replaced. If it is set to</para>
        /// <para>relay, all log messages generated when acting as a relay are sanitized, but</para>
        /// <para>all messages generated when acting as a client are not. (Default: 1)</para>
        /// </summary>
        SafeLogging,

        /// <summary>
        /// <para>User UID</para>
        /// <para>&#160;</para>
        /// <para>On startup, setuid to this user and setgid to their primary group.</para>
        /// </summary>
        User,

        /// <summary>
        /// <para>HardwareAccel 0|1</para>
        /// <para>&#160;</para>
        /// <para>If non-zero, try to use built-in (static) crypto hardware acceleration when</para>
        /// <para>available. (Default: 0)</para>
        /// </summary>
        HardwareAccel,

        /// <summary>
        /// <para>AccelName NAME</para>
        /// <para>&#160;</para>
        /// <para>When using OpenSSL hardware crypto acceleration attempt to load the dynamic</para>
        /// <para>engine of this name. This must be used for any dynamic hardware engine.</para>
        /// <para>Names can be verified with the openssl engine command.</para>
        /// </summary>
        AccelName,

        /// <summary>
        /// <para>AccelDir DIR</para>
        /// <para>&#160;</para>
        /// <para>Specify this option if using dynamic hardware acceleration and the engine</para>
        /// <para>implementation library resides somewhere other than the OpenSSL default.</para>
        /// </summary>
        AccelDir,

        /// <summary>
        /// <para>AvoidDiskWrites 0|1</para>
        /// <para>&#160;</para>
        /// <para>If non-zero, try to write to disk less frequently than we would otherwise.</para>
        /// <para>This is useful when running on flash memory or other media that support</para>
        /// <para>only a limited number of writes. (Default: 0)</para>
        /// </summary>
        AvoidDiskWrites,

        /// <summary>
        /// <para>CircuitPriorityHalflife NUM1</para>
        /// <para>&#160;</para>
        /// <para>If this value is set, we override the default algorithm for choosing which</para>
        /// <para>circuit's cell to deliver or relay next. When the value is 0, we</para>
        /// <para>round-robin between the active circuits on a connection, delivering one</para>
        /// <para>cell from each in turn. When the value is positive, we prefer delivering</para>
        /// <para>cells from whichever connection has the lowest weighted cell count, where</para>
        /// <para>cells are weighted exponentially according to the supplied</para>
        /// <para>CircuitPriorityHalflife value (in seconds). If this option is not set at</para>
        /// <para>all, we use the behavior recommended in the current consensus</para>
        /// <para>networkstatus. This is an advanced option; you generally shouldn't have</para>
        /// <para>to mess with it. (Default: not set)</para>
        /// </summary>
        CircuitPriorityHalflife,

        /// <summary>
        /// <para>DisableIOCP 0|1</para>
        /// <para>&#160;</para>
        /// <para>If Tor was built to use the Libevent's "bufferevents" networking code</para>
        /// <para>and you're running on Windows, setting this option to 1 will tell Libevent</para>
        /// <para>not to use the Windows IOCP networking API.  (Default: 1)</para>
        /// </summary>
        DisableIOCP,

        /// <summary>
        /// <para>UserspaceIOCPBuffers 0|1</para>
        /// <para>&#160;</para>
        /// <para>If IOCP is enabled (see DisableIOCP above), setting this option to 1</para>
        /// <para>will tell Tor to disable kernel-space TCP buffers, in order to avoid</para>
        /// <para>needless copy operations and try not to run out of non-paged RAM.</para>
        /// <para>This feature is experimental; don't use it yet unless you're eager to</para>
        /// <para>help tracking down bugs. (Default: 0)</para>
        /// </summary>
        UserspaceIOCPBuffers,

        /// <summary>
        /// <para>UseFilteringSSLBufferevents 0|1</para>
        /// <para>&#160;</para>
        /// <para>Tells Tor to do its SSL communication using a chain of</para>
        /// <para>bufferevents: one for SSL and one for networking.  This option has no</para>
        /// <para>effect if bufferevents are disabled (in which case it can't turn on), or</para>
        /// <para>if IOCP bufferevents are enabled (in which case it can't turn off).  This</para>
        /// <para>option is useful for debugging only; most users shouldn't touch it.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        UseFilteringSSLBufferevents,

        /// <summary>
        /// <para>CountPrivateBandwidth 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set, then Tor's rate-limiting applies not only to</para>
        /// <para>remote connections, but also to connections to private addresses like</para>
        /// <para>127.0.0.1 or 10.0.0.1.  This is mostly useful for debugging</para>
        /// <para>rate-limiting.  (Default: 0)</para>
        /// </summary>
        CountPrivateBandwidth,

        /// <summary>
        /// <para>AllowInvalidNodes entry|exit|middle|introduction|rendezvous|...</para>
        /// <para>&#160;</para>
        /// <para>If some Tor servers are obviously not working right, the directory</para>
        /// <para>authorities can manually mark them as invalid, meaning that it's not</para>
        /// <para>recommended you use them for entry or exit positions in your circuits. You</para>
        /// <para>can opt to use them in some circuit positions, though. The default is</para>
        /// <para>"middle,rendezvous", and other choices are not advised.</para>
        /// </summary>
        AllowInvalidNodes,

        /// <summary>
        /// <para>ExcludeSingleHopRelays 0|1</para>
        /// <para>&#160;</para>
        /// <para>This option controls whether circuits built by Tor will include relays with</para>
        /// <para>the AllowSingleHopExits flag set to true. If ExcludeSingleHopRelays is set</para>
        /// <para>to 0, these relays will be included. Note that these relays might be at</para>
        /// <para>higher risk of being seized or observed, so they are not normally</para>
        /// <para>included.  Also note that relatively few clients turn off this option,</para>
        /// <para>so using these relays might make your client stand out.</para>
        /// <para>(Default: 1)</para>
        /// </summary>
        ExcludeSingleHopRelays,

        /// <summary>
        /// <para>Bridge [transport] IP:ORPort [fingerprint]</para>
        /// <para>&#160;</para>
        /// <para>When set along with UseBridges, instructs Tor to use the relay at</para>
        /// <para>"IP:ORPort" as a "bridge" relaying into the Tor network. If "fingerprint"</para>
        /// <para>is provided (using the same format as for DirAuthority), we will verify that</para>
        /// <para>the relay running at that location has the right fingerprint. We also use</para>
        /// <para>fingerprint to look up the bridge descriptor at the bridge authority, if</para>
        /// <para>it's provided and if UpdateBridgesFromAuthority is set too. </para>
        /// <para>&#160;</para>
        /// <para>If "transport" is provided, and matches to a ClientTransportPlugin</para>
        /// <para>line, we use that pluggable transports proxy to transfer data to</para>
        /// <para>the bridge.</para>
        /// </summary>
        Bridge,

        /// <summary>
        /// <para>LearnCircuitBuildTimeout 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 0, CircuitBuildTimeout adaptive learning is disabled. (Default: 1)</para>
        /// </summary>
        LearnCircuitBuildTimeout,

        /// <summary>
        /// <para>CircuitBuildTimeout NUM</para>
        /// <para>&#160;</para>
        /// <para>Try for at most NUM seconds when building circuits. If the circuit isn't</para>
        /// <para>open in that time, give up on it. If LearnCircuitBuildTimeout is 1, this</para>
        /// <para>value serves as the initial value to use before a timeout is learned. If</para>
        /// <para>LearnCircuitBuildTimeout is 0, this value is the only value used.</para>
        /// <para>(Default: 60 seconds)</para>
        /// </summary>
        CircuitBuildTimeout,

        /// <summary>
        /// <para>CircuitIdleTimeout NUM</para>
        /// <para>&#160;</para>
        /// <para>If we have kept a clean (never used) circuit around for NUM seconds, then</para>
        /// <para>close it. This way when the Tor client is entirely idle, it can expire all</para>
        /// <para>of its circuits, and then expire its TLS connections. Also, if we end up</para>
        /// <para>making a circuit that is not useful for exiting any of the requests we're</para>
        /// <para>receiving, it won't forever take up a slot in the circuit list. (Default: 1</para>
        /// <para>hour)</para>
        /// </summary>
        CircuitIdleTimeout,

        /// <summary>
        /// <para>CircuitStreamTimeout NUM</para>
        /// <para>&#160;</para>
        /// <para>If non-zero, this option overrides our internal timeout schedule for how</para>
        /// <para>many seconds until we detach a stream from a circuit and try a new circuit.</para>
        /// <para>If your network is particularly slow, you might want to set this to a</para>
        /// <para>number like 60. (Default: 0)</para>
        /// </summary>
        CircuitStreamTimeout,

        /// <summary>
        /// <para>ClientOnly 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor will not run as a relay or serve</para>
        /// <para>directory requests, even if the ORPort, ExtORPort, or DirPort options are</para>
        /// <para>set. (This config option is</para>
        /// <para>mostly unnecessary: we added it back when we were considering having</para>
        /// <para>Tor clients auto-promote themselves to being relays if they were stable</para>
        /// <para>and fast enough. The current behavior is simply that Tor is a client</para>
        /// <para>unless ORPort, ExtORPort, or DirPort are configured.) (Default: 0)</para>
        /// </summary>
        ClientOnly,

        /// <summary>
        /// <para>ExcludeNodes node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints, country codes, and address</para>
        /// <para>patterns of nodes to avoid when building a circuit. Country codes must</para>
        /// <para>be wrapped in braces; fingerprints may be preceded by a dollar sign.</para>
        /// <para>(Example:</para>
        /// <para>ExcludeNodes ABCD1234CDEF5678ABCD1234CDEF5678ABCD1234, {cc}, 255.254.0.0/8)</para>
        /// <para>&#160;</para>
        /// <para>By default, this option is treated as a preference that Tor is allowed</para>
        /// <para>to override in order to keep working.</para>
        /// <para>For example, if you try to connect to a hidden service,</para>
        /// <para>but you have excluded all of the hidden service's introduction points,</para>
        /// <para>Tor will connect to one of them anyway.  If you do not want this</para>
        /// <para>behavior, set the StrictNodes option (documented below). </para>
        /// <para>&#160;</para>
        /// <para>Note also that if you are a relay, this (and the other node selection</para>
        /// <para>options below) only affects your own circuits that Tor builds for you.</para>
        /// <para>Clients can still build circuits through you to any node.  Controllers</para>
        /// <para>can tell Tor to build circuits through any node.</para>
        /// <para>&#160;</para>
        /// <para>Country codes are case-insensitive. The code "{??}" refers to nodes whose</para>
        /// <para>country can't be identified. No country code, including {??}, works if</para>
        /// <para>no GeoIPFile can be loaded. See also the GeoIPExcludeUnknown option below.</para>
        /// </summary>
        ExcludeNodes,

        /// <summary>
        /// <para>ExcludeExitNodes node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints, country codes, and address</para>
        /// <para>patterns of nodes to never use when picking an exit node---that is, a</para>
        /// <para>node that delivers traffic for you outside the Tor network.   Note that any</para>
        /// <para>node listed in ExcludeNodes is automatically considered to be part of this</para>
        /// <para>list too.  See</para>
        /// <para>the ExcludeNodes option for more information on how to specify</para>
        /// <para>nodes. See also the caveats on the "ExitNodes" option below.</para>
        /// </summary>
        ExcludeExitNodes,

        /// <summary>
        /// <para>GeoIPExcludeUnknown 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 'auto', then whenever any country code is set in</para>
        /// <para>ExcludeNodes or ExcludeExitNodes, all nodes with unknown country ({??} and</para>
        /// <para>possibly {A1}) are treated as excluded as well. If this option is set to</para>
        /// <para>'1', then all unknown countries are treated as excluded in ExcludeNodes</para>
        /// <para>and ExcludeExitNodes.  This option has no effect when a GeoIP file isn't</para>
        /// <para>configured or can't be found.  (Default: auto)</para>
        /// </summary>
        GeoIPExcludeUnknown,

        /// <summary>
        /// <para>ExitNodes node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints, country codes, and address</para>
        /// <para>patterns of nodes to use as exit node---that is, a</para>
        /// <para>node that delivers traffic for you outside the Tor network.  See</para>
        /// <para>the ExcludeNodes option for more information on how to specify nodes.</para>
        /// <para>&#160;</para>
        /// <para>Note that if you list too few nodes here, or if you exclude too many exit</para>
        /// <para>nodes with ExcludeExitNodes, you can degrade functionality.  For example,</para>
        /// <para>if none of the exits you list allows traffic on port 80 or 443, you won't</para>
        /// <para>be able to browse the web.</para>
        /// <para>&#160;</para>
        /// <para>Note also that not every circuit is used to deliver traffic outside of</para>
        /// <para>the Tor network.  It is normal to see non-exit circuits (such as those</para>
        /// <para>used to connect to hidden services, those that do directory fetches,</para>
        /// <para>those used for relay reachability self-tests, and so on) that end</para>
        /// <para>at a non-exit node.  To</para>
        /// <para>keep a node from being used entirely, see ExcludeNodes and StrictNodes.</para>
        /// <para>&#160;</para>
        /// <para>The ExcludeNodes option overrides this option: any node listed in both</para>
        /// <para>ExitNodes and ExcludeNodes is treated as excluded.</para>
        /// <para>&#160;</para>
        /// <para>The .exit address notation, if enabled via AllowDotExit, overrides</para>
        /// <para>this option.</para>
        /// </summary>
        ExitNodes,

        /// <summary>
        /// <para>EntryNodes node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints and country codes of nodes</para>
        /// <para>to use for the first hop in your normal circuits.</para>
        /// <para>Normal circuits include all</para>
        /// <para>circuits except for direct connections to directory servers.  The Bridge</para>
        /// <para>option overrides this option; if you have configured bridges and</para>
        /// <para>UseBridges is 1, the Bridges are used as your entry nodes.</para>
        /// <para>&#160;</para>
        /// <para>The ExcludeNodes option overrides this option: any node listed in both</para>
        /// <para>EntryNodes and ExcludeNodes is treated as excluded. See</para>
        /// <para>the ExcludeNodes option for more information on how to specify nodes.</para>
        /// </summary>
        EntryNodes,

        /// <summary>
        /// <para>StrictNodes 0|1</para>
        /// <para>&#160;</para>
        /// <para>If StrictNodes is set to 1, Tor will treat the ExcludeNodes option as a</para>
        /// <para>requirement to follow for all the circuits you generate, even if doing so</para>
        /// <para>will break functionality for you.  If StrictNodes is set to 0, Tor will</para>
        /// <para>still try to avoid nodes in the ExcludeNodes list, but it will err on the</para>
        /// <para>side of avoiding unexpected errors.  Specifically, StrictNodes 0 tells</para>
        /// <para>Tor that it is okay to use an excluded node when it is necessary to</para>
        /// <para>perform relay reachability self-tests, connect to</para>
        /// <para>a hidden service, provide a hidden service to a client, fulfill a .exit</para>
        /// <para>request, upload directory information, or download directory information.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        StrictNodes,

        /// <summary>
        /// <para>FascistFirewall 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor will only create outgoing connections to ORs running on ports</para>
        /// <para>that your firewall allows (defaults to 80 and 443; see FirewallPorts).</para>
        /// <para>This will allow you to run Tor as a client behind a firewall with</para>
        /// <para>restrictive policies, but will not allow you to run as a server behind such</para>
        /// <para>a firewall. If you prefer more fine-grained control, use</para>
        /// <para>ReachableAddresses instead.</para>
        /// </summary>
        FascistFirewall,

        /// <summary>
        /// <para>FirewallPorts PORTS</para>
        /// <para>&#160;</para>
        /// <para>A list of ports that your firewall allows you to connect to. Only used when</para>
        /// <para>FascistFirewall is set. This option is deprecated; use ReachableAddresses</para>
        /// <para>instead. (Default: 80, 443)</para>
        /// </summary>
        FirewallPorts,

        /// <summary>
        /// <para>ReachableAddresses ADDR[/MASK][:PORT]...</para>
        /// <para>&#160;</para>
        /// <para>A comma-separated list of IP addresses and ports that your firewall allows</para>
        /// <para>you to connect to. The format is as for the addresses in ExitPolicy, except</para>
        /// <para>that "accept" is understood unless "reject" is explicitly provided. For</para>
        /// <para>example, 'ReachableAddresses 99.0.0.0/8, reject 18.0.0.0/8:80, accept</para>
        /// <para>:80' means that your firewall allows connections to everything inside net</para>
        /// <para>99, rejects port 80 connections to net 18, and accepts connections to port</para>
        /// <para>80 otherwise. (Default: 'accept :'.)</para>
        /// </summary>
        ReachableAddresses,

        /// <summary>
        /// <para>ReachableDirAddresses ADDR[/MASK][:PORT]...</para>
        /// <para>&#160;</para>
        /// <para>Like ReachableAddresses, a list of addresses and ports. Tor will obey</para>
        /// <para>these restrictions when fetching directory information, using standard HTTP</para>
        /// <para>GET requests. If not set explicitly then the value of</para>
        /// <para>ReachableAddresses is used. If HTTPProxy is set then these</para>
        /// <para>connections will go through that proxy.</para>
        /// </summary>
        ReachableDirAddresses,

        /// <summary>
        /// <para>ReachableORAddresses ADDR[/MASK][:PORT]...</para>
        /// <para>&#160;</para>
        /// <para>Like ReachableAddresses, a list of addresses and ports. Tor will obey</para>
        /// <para>these restrictions when connecting to Onion Routers, using TLS/SSL. If not</para>
        /// <para>set explicitly then the value of ReachableAddresses is used. If</para>
        /// <para>HTTPSProxy is set then these connections will go through that proxy.</para>
        /// <para>&#160;</para>
        /// <para>The separation between ReachableORAddresses and</para>
        /// <para>ReachableDirAddresses is only interesting when you are connecting</para>
        /// <para>through proxies (see HTTPProxy and HTTPSProxy). Most proxies limit</para>
        /// <para>TLS connections (which Tor uses to connect to Onion Routers) to port 443,</para>
        /// <para>and some limit HTTP GET requests (which Tor uses for fetching directory</para>
        /// <para>information) to port 80.</para>
        /// </summary>
        ReachableORAddresses,

        /// <summary>
        /// <para>HidServAuth onion-address auth-cookie [service-name]</para>
        /// <para>&#160;</para>
        /// <para>Client authorization for a hidden service. Valid onion addresses contain 16</para>
        /// <para>characters in a-z2-7 plus ".onion", and valid auth cookies contain 22</para>
        /// <para>characters in A-Za-z0-9+/. The service name is only used for internal</para>
        /// <para>purposes, e.g., for Tor controllers. This option may be used multiple times</para>
        /// <para>for different hidden services. If a hidden service uses authorization and</para>
        /// <para>this option is not set, the hidden service is not accessible. Hidden</para>
        /// <para>services can be configured to require authorization using the</para>
        /// <para>HiddenServiceAuthorizeClient option.</para>
        /// </summary>
        HidServAuth,

        /// <summary>
        /// <para>CloseHSClientCircuitsImmediatelyOnTimeout 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor will close unfinished hidden service client circuits</para>
        /// <para>which have not moved closer to connecting to their destination</para>
        /// <para>hidden service when their internal state has not changed for the</para>
        /// <para>duration of the current circuit-build timeout.  Otherwise, such</para>
        /// <para>circuits will be left open, in the hope that they will finish</para>
        /// <para>connecting to their destination hidden services.  In either case,</para>
        /// <para>another set of introduction and rendezvous circuits for the same</para>
        /// <para>destination hidden service will be launched. (Default: 0)</para>
        /// </summary>
        CloseHSClientCircuitsImmediatelyOnTimeout,

        /// <summary>
        /// <para>CloseHSServiceRendCircuitsImmediatelyOnTimeout 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor will close unfinished hidden-service-side rendezvous</para>
        /// <para>circuits after the current circuit-build timeout.  Otherwise, such</para>
        /// <para>circuits will be left open, in the hope that they will finish</para>
        /// <para>connecting to their destinations.  In either case, another</para>
        /// <para>rendezvous circuit for the same destination client will be</para>
        /// <para>launched. (Default: 0)</para>
        /// </summary>
        CloseHSServiceRendCircuitsImmediatelyOnTimeout,

        /// <summary>
        /// <para>LongLivedPorts PORTS</para>
        /// <para>&#160;</para>
        /// <para>A list of ports for services that tend to have long-running connections</para>
        /// <para>(e.g. chat and interactive shells). Circuits for streams that use these</para>
        /// <para>ports will contain only high-uptime nodes, to reduce the chance that a node</para>
        /// <para>will go down before the stream is finished. Note that the list is also</para>
        /// <para>honored for circuits (both client and service side) involving hidden</para>
        /// <para>services whose virtual port is in this list. (Default: 21, 22, 706,</para>
        /// <para>1863, 5050, 5190, 5222, 5223, 6523, 6667, 6697, 8300)</para>
        /// </summary>
        LongLivedPorts,

        /// <summary>
        /// <para>MapAddress address newaddress</para>
        /// <para>&#160;</para>
        /// <para>When a request for address arrives to Tor, it will transform to newaddress</para>
        /// <para>before processing it. For example, if you always want connections to</para>
        /// <para>www.example.com to exit via torserver (where torserver is the</para>
        /// <para>nickname of the server), use "MapAddress www.example.com</para>
        /// <para>www.example.com.torserver.exit". If the value is prefixed with a</para>
        /// <para>".", matches an entire domain. For example, if you</para>
        /// <para>always want connections to example.com and any if its subdomains</para>
        /// <para>to exit via</para>
        /// <para>torserver (where torserver is the nickname of the server), use</para>
        /// <para>"MapAddress .example.com .example.com.torserver.exit". (Note the</para>
        /// <para>leading "." in each part of the directive.) You can also redirect all</para>
        /// <para>subdomains of a domain to a single address. For example, "MapAddress</para>
        /// <para>.example.com www.example.com".</para>
        /// <para>&#160;</para>
        /// <para>NOTES:</para>
        /// <para>1. When evaluating MapAddress expressions Tor stops when it hits the most</para>
        /// <para>recently added expression that matches the requested address. So if you</para>
        /// <para>have the following in your torrc, www.torproject.org will map to 1.1.1.1:</para>
        /// <para> MapAddress www.torproject.org 2.2.2.2</para>
        /// <para> MapAddress www.torproject.org 1.1.1.1</para>
        /// <para>2. Tor evaluates the MapAddress configuration until it finds no matches. So</para>
        /// <para>if you have the following in your torrc, www.torproject.org will map to</para>
        /// <para>2.2.2.2:</para>
        /// <para>  MapAddress 1.1.1.1 2.2.2.2</para>
        /// <para>  MapAddress www.torproject.org 1.1.1.1</para>
        /// <para>3. The following MapAddress expression is invalid (and will be</para>
        /// <para>ignored) because you cannot map from a specific address to a wildcard</para>
        /// <para>address:</para>
        /// <para>  MapAddress www.torproject.org .torproject.org.torserver.exit</para>
        /// <para>4. Using a wildcard to match only part of a string (as in ample.com) is</para>
        /// <para>also invalid.</para>
        /// </summary>
        MapAddress,

        /// <summary>
        /// <para>NewCircuitPeriod NUM</para>
        /// <para>&#160;</para>
        /// <para>Every NUM seconds consider whether to build a new circuit. (Default: 30</para>
        /// <para>seconds)</para>
        /// </summary>
        NewCircuitPeriod,

        /// <summary>
        /// <para>MaxCircuitDirtiness NUM</para>
        /// <para>&#160;</para>
        /// <para>Feel free to reuse a circuit that was first used at most NUM seconds ago,</para>
        /// <para>but never attach a new stream to a circuit that is too old.  For hidden</para>
        /// <para>services, this applies to the last time a circuit was used, not the</para>
        /// <para>first.  (Default: 10 minutes)</para>
        /// </summary>
        MaxCircuitDirtiness,

        /// <summary>
        /// <para>MaxClientCircuitsPending NUM</para>
        /// <para>&#160;</para>
        /// <para>Do not allow more than NUM circuits to be pending at a time for handling</para>
        /// <para>client streams. A circuit is pending if we have begun constructing it,</para>
        /// <para>but it has not yet been completely constructed.  (Default: 32)</para>
        /// </summary>
        MaxClientCircuitsPending,

        /// <summary>
        /// <para>NodeFamily node,node,...</para>
        /// <para>&#160;</para>
        /// <para>The Tor servers, defined by their identity fingerprints,</para>
        /// <para>constitute a "family" of similar or co-administered servers, so never use</para>
        /// <para>any two of them in the same circuit. Defining a NodeFamily is only needed</para>
        /// <para>when a server doesn't list the family itself (with MyFamily). This option</para>
        /// <para>can be used multiple times; each instance defines a separate family.  In</para>
        /// <para>addition to nodes, you can also list IP address and ranges and country</para>
        /// <para>codes in {curly braces}. See the ExcludeNodes option for more</para>
        /// <para>information on how to specify nodes.</para>
        /// </summary>
        NodeFamily,

        /// <summary>
        /// <para>EnforceDistinctSubnets 0|1</para>
        /// <para>&#160;</para>
        /// <para>If 1, Tor will not put two servers whose IP addresses are "too close" on</para>
        /// <para>the same circuit. Currently, two addresses are "too close" if they lie in</para>
        /// <para>the same /16 range. (Default: 1)</para>
        /// </summary>
        EnforceDistinctSubnets,

        /// <summary>
        /// <para>SOCKSPort ['address':]port|unix:path|auto [flags] [isolation flags]</para>
        /// <para>&#160;</para>
        /// <para>Open this port to listen for connections from SOCKS-speaking</para>
        /// <para>applications. Set this to 0 if you don't want to allow application</para>
        /// <para>connections via SOCKS. Set it to "auto" to have Tor pick a port for</para>
        /// <para>you. This directive can be specified multiple times to bind</para>
        /// <para>to multiple addresses/ports. (Default: 9050)</para>
        /// <para>&#160;</para>
        /// <para>The isolation flags arguments give Tor rules for which streams</para>
        /// <para>received on this SOCKSPort are allowed to share circuits with one</para>
        /// <para>another.  Recognized isolation flags are:</para>
        /// <para>IsolateClientAddr;;</para>
        /// <para>    Don't share circuits with streams from a different</para>
        /// <para>    client address.  (On by default and strongly recommended;</para>
        /// <para>    you can disable it with NoIsolateClientAddr.)</para>
        /// <para>IsolateSOCKSAuth;;</para>
        /// <para>    Don't share circuits with streams for which different</para>
        /// <para>    SOCKS authentication was provided. (On by default;</para>
        /// <para>    you can disable it with NoIsolateSOCKSAuth.)</para>
        /// <para>IsolateClientProtocol;;</para>
        /// <para>    Don't share circuits with streams using a different protocol.</para>
        /// <para>    (SOCKS 4, SOCKS 5, TransPort connections, NATDPort connections,</para>
        /// <para>    and DNSPort requests are all considered to be different protocols.)</para>
        /// <para>IsolateDestPort;;</para>
        /// <para>    Don't share circuits with streams targeting a different</para>
        /// <para>    destination port.</para>
        /// <para>IsolateDestAddr;;</para>
        /// <para>    Don't share circuits with streams targeting a different</para>
        /// <para>    destination address.</para>
        /// <para>SessionGroup=INT;;</para>
        /// <para>    If no other isolation rules would prevent it, allow streams</para>
        /// <para>    on this port to share circuits with streams from every other</para>
        /// <para>    port with the same session group.  (By default, streams received</para>
        /// <para>    on different SOCKSPorts, TransPorts, etc are always isolated from one</para>
        /// <para>    another. This option overrides that behavior.)</para>
        /// </summary>
        SOCKSPort,

        /// <summary>
        /// <para>:</para>
        /// <para>&#160;</para>
        /// <para>Other recognized flags for a SOCKSPort are:</para>
        /// <para>NoIPv4Traffic;;</para>
        /// <para>    Tell exits to not connect to IPv4 addresses in response to SOCKS</para>
        /// <para>    requests on this connection.</para>
        /// <para>IPv6Traffic;;</para>
        /// <para>    Tell exits to allow IPv6 addresses in response to SOCKS requests on</para>
        /// <para>    this connection, so long as SOCKS5 is in use.  (SOCKS4 can't handle</para>
        /// <para>    IPv6.)</para>
        /// <para>PreferIPv6;;</para>
        /// <para>    Tells exits that, if a host has both an IPv4 and an IPv6 address,</para>
        /// <para>    we would prefer to connect to it via IPv6. (IPv4 is the default.)</para>
        /// <para>&#160;</para>
        /// <para>    NOTE: Although this option allows you to specify an IP address</para>
        /// <para>    other than localhost, you should do so only with extreme caution.</para>
        /// <para>    The SOCKS protocol is unencrypted and (as we use it)</para>
        /// <para>    unauthenticated, so exposing it in this way could leak your</para>
        /// <para>    information to anybody watching your network, and allow anybody</para>
        /// <para>    to use your computer as an open proxy.</para>
        /// <para>&#160;</para>
        /// <para>CacheIPv4DNS;;</para>
        /// <para>    Tells the client to remember IPv4 DNS answers we receive from exit</para>
        /// <para>    nodes via this connection. (On by default.)</para>
        /// <para>CacheIPv6DNS;;</para>
        /// <para>    Tells the client to remember IPv6 DNS answers we receive from exit</para>
        /// <para>    nodes via this connection.</para>
        /// <para>CacheDNS;;</para>
        /// <para>    Tells the client to remember all DNS answers we receive from exit</para>
        /// <para>    nodes via this connection.</para>
        /// <para>UseIPv4Cache;;</para>
        /// <para>    Tells the client to use any cached IPv4 DNS answers we have when making</para>
        /// <para>    requests via this connection. (NOTE: This option, along UseIPv6Cache</para>
        /// <para>    and UseDNSCache, can harm your anonymity, and probably</para>
        /// <para>    won't help performance as much as you might expect. Use with care!)</para>
        /// <para>UseIPv6Cache;;</para>
        /// <para>    Tells the client to use any cached IPv6 DNS answers we have when making</para>
        /// <para>    requests via this connection.</para>
        /// <para>UseDNSCache;;</para>
        /// <para>    Tells the client to use any cached DNS answers we have when making</para>
        /// <para>    requests via this connection.</para>
        /// <para>PreferIPv6Automap;;</para>
        /// <para>    When serving a hostname lookup request on this port that</para>
        /// <para>    should get automapped (according to AutomapHostsOnResolve),</para>
        /// <para>    if we could return either an IPv4 or an IPv6 answer, prefer</para>
        /// <para>    an IPv6 answer. (On by default.)</para>
        /// <para>PreferSOCKSNoAuth;;</para>
        /// <para>    Ordinarily, when an application offers both "username/password</para>
        /// <para>    authentication" and "no authentication" to Tor via SOCKS5, Tor</para>
        /// <para>    selects username/password authentication so that IsolateSOCKSAuth can</para>
        /// <para>    work.  This can confuse some applications, if they offer a</para>
        /// <para>    username/password combination then get confused when asked for</para>
        /// <para>    one. You can disable this behavior, so that Tor will select "No</para>
        /// <para>    authentication" when IsolateSOCKSAuth is disabled, or when this</para>
        /// <para>    option is set.</para>
        /// </summary>
        OtherSOCKSPortFlags,

        /// <summary>
        /// <para>SOCKSListenAddress IP[:PORT]</para>
        /// <para>&#160;</para>
        /// <para>Bind to this address to listen for connections from Socks-speaking</para>
        /// <para>applications. (Default: 127.0.0.1) You can also specify a port (e.g.</para>
        /// <para>192.168.0.1:9100). This directive can be specified multiple times to bind</para>
        /// <para>to multiple addresses/ports.  (DEPRECATED: As of 0.2.3.x-alpha, you can</para>
        /// <para>now use multiple SOCKSPort entries, and provide addresses for SOCKSPort</para>
        /// <para>entries, so SOCKSListenAddress no longer has a purpose.  For backward</para>
        /// <para>compatibility, SOCKSListenAddress is only allowed when SOCKSPort is just</para>
        /// <para>a port number.)</para>
        /// </summary>
        SOCKSListenAddress,

        /// <summary>
        /// <para>SocksPolicy policy,policy,...</para>
        /// <para>&#160;</para>
        /// <para>Set an entrance policy for this server, to limit who can connect to the</para>
        /// <para>SocksPort and DNSPort ports. The policies have the same form as exit</para>
        /// <para>policies below, except that port specifiers are ignored. Any address</para>
        /// <para>not matched by some entry in the policy is accepted.</para>
        /// </summary>
        SocksPolicy,

        /// <summary>
        /// <para>SocksTimeout NUM</para>
        /// <para>&#160;</para>
        /// <para>Let a socks connection wait NUM seconds handshaking, and NUM seconds</para>
        /// <para>unattached waiting for an appropriate circuit, before we fail it. (Default:</para>
        /// <para>2 minutes)</para>
        /// </summary>
        SocksTimeout,

        /// <summary>
        /// <para>TokenBucketRefillInterval NUM [msec|second]</para>
        /// <para>&#160;</para>
        /// <para>Set the refill interval of Tor's token bucket to NUM milliseconds.</para>
        /// <para>NUM must be between 1 and 1000, inclusive.  Note that the configured</para>
        /// <para>bandwidth limits are still expressed in bytes per second: this</para>
        /// <para>option only affects the frequency with which Tor checks to see whether</para>
        /// <para>previously exhausted connections may read again. (Default: 100 msec)</para>
        /// </summary>
        TokenBucketRefillInterval,

        /// <summary>
        /// <para>TrackHostExits host,.domain,...</para>
        /// <para>&#160;</para>
        /// <para>For each value in the comma separated list, Tor will track recent</para>
        /// <para>connections to hosts that match this value and attempt to reuse the same</para>
        /// <para>exit node for each. If the value is prepended with a '.', it is treated as</para>
        /// <para>matching an entire domain. If one of the values is just a '.', it means</para>
        /// <para>match everything. This option is useful if you frequently connect to sites</para>
        /// <para>that will expire all your authentication cookies (i.e. log you out) if</para>
        /// <para>your IP address changes. Note that this option does have the disadvantage</para>
        /// <para>of making it more clear that a given history is associated with a single</para>
        /// <para>user. However, most people who would wish to observe this will observe it</para>
        /// <para>through cookies or other protocol-specific means anyhow.</para>
        /// </summary>
        TrackHostExits,

        /// <summary>
        /// <para>TrackHostExitsExpire NUM</para>
        /// <para>&#160;</para>
        /// <para>Since exit servers go up and down, it is desirable to expire the</para>
        /// <para>association between host and exit server after NUM seconds. The default is</para>
        /// <para>1800 seconds (30 minutes).</para>
        /// </summary>
        TrackHostExitsExpire,

        /// <summary>
        /// <para>UpdateBridgesFromAuthority 0|1</para>
        /// <para>&#160;</para>
        /// <para>When set (along with UseBridges), Tor will try to fetch bridge descriptors</para>
        /// <para>from the configured bridge authorities when feasible. It will fall back to</para>
        /// <para>a direct request if the authority responds with a 404. (Default: 0)</para>
        /// </summary>
        UpdateBridgesFromAuthority,

        /// <summary>
        /// <para>UseBridges 0|1</para>
        /// <para>&#160;</para>
        /// <para>When set, Tor will fetch descriptors for each bridge listed in the "Bridge"</para>
        /// <para>config lines, and use these relays as both entry guards and directory</para>
        /// <para>guards. (Default: 0)</para>
        /// </summary>
        UseBridges,

        /// <summary>
        /// <para>UseEntryGuards 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 1, we pick a few long-term entry servers, and try</para>
        /// <para>to stick with them. This is desirable because constantly changing servers</para>
        /// <para>increases the odds that an adversary who owns some servers will observe a</para>
        /// <para>fraction of your paths. (Default: 1)</para>
        /// </summary>
        UseEntryGuards,

        /// <summary>
        /// <para>UseEntryGuardsAsDirGuards 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 1, and UseEntryGuards is also set to 1,</para>
        /// <para>we try to use our entry guards as directory</para>
        /// <para>guards, and failing that, pick more nodes to act as our directory guards.</para>
        /// <para>This helps prevent an adversary from enumerating clients. It's only</para>
        /// <para>available for clients (non-relay, non-bridge) that aren't configured to</para>
        /// <para>download any non-default directory material.  It doesn't currently</para>
        /// <para>do anything when we lack a live consensus. (Default: 1)</para>
        /// </summary>
        UseEntryGuardsAsDirGuards,

        /// <summary>
        /// <para>GuardfractionFile FILENAME</para>
        /// <para>&#160;</para>
        /// <para>V3 authoritative directories only. Configures the location of the</para>
        /// <para>guardfraction file which contains information about how long relays</para>
        /// <para>have been guards. (Default: unset)</para>
        /// </summary>
        GuardfractionFile,

        /// <summary>
        /// <para>UseGuardFraction 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>This torrc option specifies whether clients should use the</para>
        /// <para>guardfraction information found in the consensus during path</para>
        /// <para>selection. If it's set to 'auto', clients will do what the</para>
        /// <para>UseGuardFraction consensus parameter tells them to do. (Default: auto)</para>
        /// </summary>
        UseGuardFraction,

        /// <summary>
        /// <para>NumEntryGuards NUM</para>
        /// <para>&#160;</para>
        /// <para>If UseEntryGuards is set to 1, we will try to pick a total of NUM routers</para>
        /// <para>as long-term entries for our circuits. If NUM is 0, we try to learn</para>
        /// <para>the number from the NumEntryGuards consensus parameter, and default</para>
        /// <para>to 3 if the consensus parameter isn't set. (Default: 0)</para>
        /// </summary>
        NumEntryGuards,

        /// <summary>
        /// <para>NumDirectoryGuards NUM</para>
        /// <para>&#160;</para>
        /// <para>If UseEntryGuardsAsDirectoryGuards is enabled, we try to make sure we</para>
        /// <para>have at least NUM routers to use as directory guards. If this option</para>
        /// <para>is set to 0, use the value from the NumDirectoryGuards consensus</para>
        /// <para>parameter, falling back to the value from NumEntryGuards if the</para>
        /// <para>consensus parameter is 0 or isn't set. (Default: 0)</para>
        /// </summary>
        NumDirectoryGuards,

        /// <summary>
        /// <para>GuardLifetime  N days|weeks|months</para>
        /// <para>&#160;</para>
        /// <para>If nonzero, and UseEntryGuards is set, minimum time to keep a guard before</para>
        /// <para>picking a new one. If zero, we use the GuardLifetime parameter from the</para>
        /// <para>consensus directory.  No value here may  be less than 1 month or greater</para>
        /// <para>than 5 years; out-of-range values are clamped. (Default: 0)</para>
        /// </summary>
        GuardLifetime,

        /// <summary>
        /// <para>SafeSocks 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is enabled, Tor will reject application connections that</para>
        /// <para>use unsafe variants of the socks protocol -- ones that only provide an IP</para>
        /// <para>address, meaning the application is doing a DNS resolve first.</para>
        /// <para>Specifically, these are socks4 and socks5 when not doing remote DNS.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        SafeSocks,

        /// <summary>
        /// <para>TestSocks 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is enabled, Tor will make a notice-level log entry for</para>
        /// <para>each connection to the Socks port indicating whether the request used a</para>
        /// <para>safe socks protocol or an unsafe one (see above entry on SafeSocks). This</para>
        /// <para>helps to determine whether an application using Tor is possibly leaking</para>
        /// <para>DNS requests. (Default: 0)</para>
        /// </summary>
        TestSocks,

        /// <summary>
        /// <para>WarnUnsafeSocks 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is enabled, Tor will warn whenever a request is</para>
        /// <para>received that only contains an IP address instead of a hostname. Allowing</para>
        /// <para>applications to do DNS resolves themselves is usually a bad idea and</para>
        /// <para>can leak your location to attackers. (Default: 1)</para>
        /// </summary>
        WarnUnsafeSocks,

        /// <summary>
        /// <para>VirtualAddrNetworkIPv4 Address/bits</para>
        /// <para>&#160;</para>
        /// </summary>
        VirtualAddrNetworkIPv4,

        /// <summary>
        /// <para>VirtualAddrNetworkIPv6 [Address]/bits</para>
        /// <para>&#160;</para>
        /// <para>When Tor needs to assign a virtual (unused) address because of a MAPADDRESS</para>
        /// <para>command from the controller or the AutomapHostsOnResolve feature, Tor</para>
        /// <para>picks an unassigned address from this range. (Defaults:</para>
        /// <para>127.192.0.0/10 and [FE80]/10 respectively.)</para>
        /// <para>&#160;</para>
        /// <para>When providing proxy server service to a network of computers using a tool</para>
        /// <para>like dns-proxy-tor, change the IPv4 network to "10.192.0.0/10" or</para>
        /// <para>"172.16.0.0/12" and change the IPv6 network to "[FC00]/7".</para>
        /// <para>The default VirtualAddrNetwork address ranges on a</para>
        /// <para>properly configured machine will route to the loopback or link-local</para>
        /// <para>interface. For</para>
        /// <para>local use, no change to the default VirtualAddrNetwork setting is needed.</para>
        /// </summary>
        VirtualAddrNetworkIPv6,

        /// <summary>
        /// <para>AllowNonRFC953Hostnames 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is disabled, Tor blocks hostnames containing illegal</para>
        /// <para>characters (like @ and :) rather than sending them to an exit node to be</para>
        /// <para>resolved. This helps trap accidental attempts to resolve URLs and so on.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        AllowNonRFC953Hostnames,

        /// <summary>
        /// <para>AllowDotExit 0|1</para>
        /// <para>&#160;</para>
        /// <para>If enabled, we convert "www.google.com.foo.exit" addresses on the</para>
        /// <para>SocksPort/TransPort/NATDPort into "www.google.com" addresses that exit from</para>
        /// <para>the node "foo". Disabled by default since attacking websites and exit</para>
        /// <para>relays can use it to manipulate your path selection. (Default: 0)</para>
        /// </summary>
        AllowDotExit,

        /// <summary>
        /// <para>FastFirstHopPK 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>When this option is disabled, Tor uses the public key step for the first</para>
        /// <para>hop of creating circuits. Skipping it is generally safe since we have</para>
        /// <para>already used TLS to authenticate the relay and to establish forward-secure</para>
        /// <para>keys. Turning this option off makes circuit building a little</para>
        /// <para>slower. Setting this option to "auto" takes advice from the authorities</para>
        /// <para>in the latest consensus about whether to use this feature. </para>
        /// <para>&#160;</para>
        /// <para>Note that Tor will always use the public key step for the first hop if it's</para>
        /// <para>operating as a relay, and it will never use the public key step if it</para>
        /// <para>doesn't yet know the onion key of the first hop. (Default: auto)</para>
        /// </summary>
        FastFirstHopPK,

        /// <summary>
        /// <para>TransPort  ['address':]port|auto [isolation flags]</para>
        /// <para>&#160;</para>
        /// <para>Open this port to listen for transparent proxy connections.  Set this to</para>
        /// <para>0 if you don't want to allow transparent proxy connections.  Set the port</para>
        /// <para>to "auto" to have Tor pick a port for you. This directive can be</para>
        /// <para>specified multiple times to bind to multiple addresses/ports.  See</para>
        /// <para>SOCKSPort for an explanation of isolation flags.</para>
        /// <para>&#160;</para>
        /// <para>TransPort requires OS support for transparent proxies, such as BSDs' pf or</para>
        /// <para>Linux's IPTables. If you're planning to use Tor as a transparent proxy for</para>
        /// <para>a network, you'll want to examine and change VirtualAddrNetwork from the</para>
        /// <para>default setting. You'll also want to set the TransListenAddress option for</para>
        /// <para>the network you'd like to proxy. (Default: 0)</para>
        /// </summary>
        TransPort,

        /// <summary>
        /// <para>TransListenAddress IP[:PORT]</para>
        /// <para>&#160;</para>
        /// <para>Bind to this address to listen for transparent proxy connections. (Default:</para>
        /// <para>127.0.0.1). This is useful for exporting a transparent proxy server to an</para>
        /// <para>entire network. (DEPRECATED: As of 0.2.3.x-alpha, you can</para>
        /// <para>now use multiple TransPort entries, and provide addresses for TransPort</para>
        /// <para>entries, so TransListenAddress no longer has a purpose.  For backward</para>
        /// <para>compatibility, TransListenAddress is only allowed when TransPort is just</para>
        /// <para>a port number.)</para>
        /// </summary>
        TransListenAddress,

        /// <summary>
        /// <para>TransProxyType default|TPROXY|ipfw|pf-divert</para>
        /// <para>&#160;</para>
        /// <para>TransProxyType may only be enabled when there is transparent proxy listener</para>
        /// <para>enabled.</para>
        /// <para>&#160;</para>
        /// <para>Set this to "TPROXY" if you wish to be able to use the TPROXY Linux module</para>
        /// <para>to transparently proxy connections that are configured using the TransPort</para>
        /// <para>option. This setting lets the listener on the TransPort accept connections</para>
        /// <para>for all addresses, even when the TransListenAddress is configured for an</para>
        /// <para>internal address. Detailed information on how to configure the TPROXY</para>
        /// <para>feature can be found in the Linux kernel source tree in the file</para>
        /// <para>Documentation/networking/tproxy.txt.</para>
        /// <para>&#160;</para>
        /// <para>Set this option to "ipfw" to use the FreeBSD ipfw interface.</para>
        /// <para>&#160;</para>
        /// <para>On BSD operating systems when using pf, set this to "pf-divert" to take</para>
        /// <para>advantage of +divert-to+ rules, which do not modify the packets like</para>
        /// <para>+rdr-to+ rules do. Detailed information on how to configure pf to use</para>
        /// <para>+divert-to+ rules can be found in the pf.conf(5) manual page. On OpenBSD,</para>
        /// <para>+divert-to+ is available to use on versions greater than or equal to</para>
        /// <para>OpenBSD 4.4.</para>
        /// <para>&#160;</para>
        /// <para>Set this to "default", or leave it unconfigured, to use regular IPTables</para>
        /// <para>on Linux, or to use pf +rdr-to+ rules on BSD systems.</para>
        /// <para>&#160;</para>
        /// <para>(Default: "default".)</para>
        /// </summary>
        TransProxyType,

        /// <summary>
        /// <para>NATDPort ['address':]port|auto [isolation flags]</para>
        /// <para>&#160;</para>
        /// <para>Open this port to listen for connections from old versions of ipfw (as</para>
        /// <para>included in old versions of FreeBSD, etc) using the NATD protocol.</para>
        /// <para>Use 0 if you don't want to allow NATD connections.  Set the port</para>
        /// <para>to "auto" to have Tor pick a port for you. This directive can be</para>
        /// <para>specified multiple times to bind to multiple addresses/ports.  See</para>
        /// <para>SOCKSPort for an explanation of isolation flags.</para>
        /// <para>&#160;</para>
        /// <para>This option is only for people who cannot use TransPort. (Default: 0)</para>
        /// </summary>
        NATDPort,

        /// <summary>
        /// <para>NATDListenAddress IP[:PORT]</para>
        /// <para>&#160;</para>
        /// <para>Bind to this address to listen for NATD connections. (DEPRECATED: As of</para>
        /// <para>0.2.3.x-alpha, you can now use multiple NATDPort entries, and provide</para>
        /// <para>addresses for NATDPort entries, so NATDListenAddress no longer has a</para>
        /// <para>purpose.  For backward compatibility, NATDListenAddress is only allowed</para>
        /// <para>when NATDPort is just a port number.)</para>
        /// </summary>
        NATDListenAddress,

        /// <summary>
        /// <para>AutomapHostsOnResolve 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is enabled, and we get a request to resolve an address</para>
        /// <para>that ends with one of the suffixes in AutomapHostsSuffixes, we map an</para>
        /// <para>unused virtual address to that address, and return the new virtual address.</para>
        /// <para>This is handy for making ".onion" addresses work with applications that</para>
        /// <para>resolve an address and then connect to it. (Default: 0)</para>
        /// </summary>
        AutomapHostsOnResolve,

        /// <summary>
        /// <para>AutomapHostsSuffixes SUFFIX,SUFFIX,...</para>
        /// <para>&#160;</para>
        /// <para>A comma-separated list of suffixes to use with AutomapHostsOnResolve.</para>
        /// <para>The "." suffix is equivalent to "all addresses." (Default: .exit,.onion).</para>
        /// </summary>
        AutomapHostsSuffixes,

        /// <summary>
        /// <para>DNSPort ['address':]port|auto [isolation flags]</para>
        /// <para>&#160;</para>
        /// <para>If non-zero, open this port to listen for UDP DNS requests, and resolve</para>
        /// <para>them anonymously.  This port only handles A, AAAA, and PTR requests---it</para>
        /// <para>doesn't handle arbitrary DNS request types. Set the port to "auto" to</para>
        /// <para>have Tor pick a port for</para>
        /// <para>you. This directive can be specified multiple times to bind to multiple</para>
        /// <para>addresses/ports. See SOCKSPort for an explanation of isolation</para>
        /// <para>flags. (Default: 0)</para>
        /// </summary>
        DNSPort,

        /// <summary>
        /// <para>DNSListenAddress IP[:PORT]</para>
        /// <para>&#160;</para>
        /// <para>Bind to this address to listen for DNS connections. (DEPRECATED: As of</para>
        /// <para>0.2.3.x-alpha, you can now use multiple DNSPort entries, and provide</para>
        /// <para>addresses for DNSPort entries, so DNSListenAddress no longer has a</para>
        /// <para>purpose.  For backward compatibility, DNSListenAddress is only allowed</para>
        /// <para>when DNSPort is just a port number.)</para>
        /// </summary>
        DNSListenAddress,

        /// <summary>
        /// <para>ClientDNSRejectInternalAddresses 0|1</para>
        /// <para>&#160;</para>
        /// <para>If true, Tor does not believe any anonymously retrieved DNS answer that</para>
        /// <para>tells it that an address resolves to an internal address (like 127.0.0.1 or</para>
        /// <para>192.168.0.1). This option prevents certain browser-based attacks; don't</para>
        /// <para>turn it off unless you know what you're doing. (Default: 1)</para>
        /// </summary>
        ClientDNSRejectInternalAddresses,

        /// <summary>
        /// <para>ClientRejectInternalAddresses 0|1</para>
        /// <para>&#160;</para>
        /// <para>If true, Tor does not try to fulfill requests to connect to an internal</para>
        /// <para>address (like 127.0.0.1 or 192.168.0.1) unless a exit node is</para>
        /// <para>specifically requested (for example, via a .exit hostname, or a</para>
        /// <para>controller request).  (Default: 1)</para>
        /// </summary>
        ClientRejectInternalAddresses,

        /// <summary>
        /// <para>DownloadExtraInfo 0|1</para>
        /// <para>&#160;</para>
        /// <para>If true, Tor downloads and caches "extra-info" documents. These documents</para>
        /// <para>contain information about servers other than the information in their</para>
        /// <para>regular server descriptors. Tor does not use this information for anything</para>
        /// <para>itself; to save bandwidth, leave this option turned off. (Default: 0)</para>
        /// </summary>
        DownloadExtraInfo,

        /// <summary>
        /// <para>WarnPlaintextPorts port,port,...</para>
        /// <para>&#160;</para>
        /// <para>Tells Tor to issue a warnings whenever the user tries to make an anonymous</para>
        /// <para>connection to one of these ports. This option is designed to alert users</para>
        /// <para>to services that risk sending passwords in the clear. (Default:</para>
        /// <para>23,109,110,143)</para>
        /// </summary>
        WarnPlaintextPorts,

        /// <summary>
        /// <para>RejectPlaintextPorts port,port,...</para>
        /// <para>&#160;</para>
        /// <para>Like WarnPlaintextPorts, but instead of warning about risky port uses, Tor</para>
        /// <para>will instead refuse to make the connection. (Default: None)</para>
        /// </summary>
        RejectPlaintextPorts,

        /// <summary>
        /// <para>AllowSingleHopCircuits 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, the attached Tor controller can use relays</para>
        /// <para>that have the AllowSingleHopExits option turned on to build</para>
        /// <para>one-hop Tor connections.  (Default: 0)</para>
        /// </summary>
        AllowSingleHopCircuits,

        /// <summary>
        /// <para>OptimisticData 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, and Tor is using an exit node that supports</para>
        /// <para>the feature, it will try optimistically to send data to the exit node</para>
        /// <para>without waiting for the exit node to report whether the connection</para>
        /// <para>succeeded.  This can save a round-trip time for protocols like HTTP</para>
        /// <para>where the client talks first.  If OptimisticData is set to auto,</para>
        /// <para>Tor will look at the UseOptimisticData parameter in the networkstatus.</para>
        /// <para>(Default: auto)</para>
        /// </summary>
        OptimisticData,

        /// <summary>
        /// <para>Tor2webMode 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, Tor connects to hidden services</para>
        /// <para>non-anonymously.  This option also disables client connections to</para>
        /// <para>non-hidden-service hostnames through Tor. It must only be used when</para>
        /// <para>running a tor2web Hidden Service web proxy.</para>
        /// <para>To enable this option the compile time flag --enable-tor2webmode must be</para>
        /// <para>specified. (Default: 0)</para>
        /// </summary>
        Tor2webMode,

        /// <summary>
        /// <para>Tor2webRendezvousPoints node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints, nicknames, country codes and</para>
        /// <para>address patterns of nodes that are allowed to be used as RPs</para>
        /// <para>in HS circuits; any other nodes will not be used as RPs.</para>
        /// <para>(Example:</para>
        /// <para>Tor2webRendezvousPoints Fastyfasty, ABCD1234CDEF5678ABCD1234CDEF5678ABCD1234, {cc}, 255.254.0.0/8)</para>
        /// <para>&#160;</para>
        /// <para>This feature can only be used if Tor2webMode is also enabled.</para>
        /// <para>&#160;</para>
        /// <para>ExcludeNodes have higher priority than Tor2webRendezvousPoints,</para>
        /// <para>which means that nodes specified in ExcludeNodes will not be</para>
        /// <para>picked as RPs.</para>
        /// <para>&#160;</para>
        /// <para>If no nodes in Tor2webRendezvousPoints are currently available for</para>
        /// <para>use, Tor will choose a random node when building HS circuits.</para>
        /// </summary>
        Tor2webRendezvousPoints,

        /// <summary>
        /// <para>UseMicrodescriptors 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>Microdescriptors are a smaller version of the information that Tor needs</para>
        /// <para>in order to build its circuits.  Using microdescriptors makes Tor clients</para>
        /// <para>download less directory information, thus saving bandwidth.  Directory</para>
        /// <para>caches need to fetch regular descriptors and microdescriptors, so this</para>
        /// <para>option doesn't save any bandwidth for them.  If this option is set to</para>
        /// <para>"auto" (recommended) then it is on for all clients that do not set</para>
        /// <para>FetchUselessDescriptors. (Default: auto)</para>
        /// </summary>
        UseMicrodescriptors,

        /// <summary>
        /// <para>UseNTorHandshake 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>The "ntor" circuit-creation handshake is faster and (we think) more</para>
        /// <para>secure than the original ("TAP") circuit handshake, but starting to use</para>
        /// <para>it too early might make your client stand out. If this option is 0, your</para>
        /// <para>Tor client won't use the ntor handshake. If it's 1, your Tor client</para>
        /// <para>will use the ntor handshake to extend circuits through servers that</para>
        /// <para>support it. If this option is "auto", then your client</para>
        /// <para>will use the ntor handshake once enough directory authorities recommend</para>
        /// <para>it. (Default: 1)</para>
        /// </summary>
        UseNTorHandshake,

        /// <summary>
        /// <para>PathBiasCircThreshold NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasCircThreshold,

        /// <summary>
        /// <para>PathBiasNoticeRate NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasNoticeRate,

        /// <summary>
        /// <para>PathBiasWarnRate NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasWarnRate,

        /// <summary>
        /// <para>PathBiasExtremeRate NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasExtremeRate,

        /// <summary>
        /// <para>PathBiasDropGuards NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasDropGuards,

        /// <summary>
        /// <para>PathBiasScaleThreshold NUM</para>
        /// <para>&#160;</para>
        /// <para>These options override the default behavior of Tor's (currently</para>
        /// <para>experimental) path bias detection algorithm. To try to find broken or</para>
        /// <para>misbehaving guard nodes, Tor looks for nodes where more than a certain</para>
        /// <para>fraction of circuits through that guard fail to get built.</para>
        /// <para>&#160;</para>
        /// <para>The PathBiasCircThreshold option controls how many circuits we need to build</para>
        /// <para>through a guard before we make these checks.  The PathBiasNoticeRate,</para>
        /// <para>PathBiasWarnRate and PathBiasExtremeRate options control what fraction of</para>
        /// <para>circuits must succeed through a guard so we won't write log messages.</para>
        /// <para>If less than PathBiasExtremeRate circuits succeed and PathBiasDropGuards</para>
        /// <para>is set to 1, we disable use of that guard.</para>
        /// <para>&#160;</para>
        /// <para>When we have seen more than PathBiasScaleThreshold</para>
        /// <para>circuits through a guard, we scale our observations by 0.5 (governed by</para>
        /// <para>the consensus) so that new observations don't get swamped by old ones.</para>
        /// <para>&#160;</para>
        /// <para>By default, or if a negative value is provided for one of these options,</para>
        /// <para>Tor uses reasonable defaults from the networkstatus consensus document.</para>
        /// <para>If no defaults are available there, these options default to 150, .70,</para>
        /// <para>.50, .30, 0, and 300 respectively.</para>
        /// </summary>
        PathBiasScaleThreshold,

        /// <summary>
        /// <para>PathBiasUseThreshold NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasUseThreshold,

        /// <summary>
        /// <para>PathBiasNoticeUseRate NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasNoticeUseRate,

        /// <summary>
        /// <para>PathBiasExtremeUseRate NUM</para>
        /// <para>&#160;</para>
        /// </summary>
        PathBiasExtremeUseRate,

        /// <summary>
        /// <para>PathBiasScaleUseThreshold NUM</para>
        /// <para>&#160;</para>
        /// <para>Similar to the above options, these options override the default behavior</para>
        /// <para>of Tor's (currently experimental) path use bias detection algorithm.</para>
        /// <para>&#160;</para>
        /// <para>Where as the path bias parameters govern thresholds for successfully</para>
        /// <para>building circuits, these four path use bias parameters govern thresholds</para>
        /// <para>only for circuit usage. Circuits which receive no stream usage</para>
        /// <para>are not counted by this detection algorithm. A used circuit is considered</para>
        /// <para>successful if it is capable of carrying streams or otherwise receiving</para>
        /// <para>well-formed responses to RELAY cells.</para>
        /// <para>&#160;</para>
        /// <para>By default, or if a negative value is provided for one of these options,</para>
        /// <para>Tor uses reasonable defaults from the networkstatus consensus document.</para>
        /// <para>If no defaults are available there, these options default to 20, .80,</para>
        /// <para>.60, and 100, respectively.</para>
        /// </summary>
        PathBiasScaleUseThreshold,

        /// <summary>
        /// <para>ClientUseIPv6 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 1, Tor might connect to entry nodes over</para>
        /// <para>IPv6. Note that clients configured with an IPv6 address in a</para>
        /// <para>Bridge line will try connecting over IPv6 even if</para>
        /// <para>ClientUseIPv6 is set to 0. (Default: 0)</para>
        /// </summary>
        ClientUseIPv6,

        /// <summary>
        /// <para>ClientPreferIPv6ORPort 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 1, Tor prefers an OR port with an IPv6</para>
        /// <para>address over one with IPv4 if a given entry node has both. Other</para>
        /// <para>things may influence the choice. This option breaks a tie to the</para>
        /// <para>favor of IPv6. (Default: 0)</para>
        /// </summary>
        ClientPreferIPv6ORPort,

        /// <summary>
        /// <para>PathsNeededToBuildCircuits NUM</para>
        /// <para>&#160;</para>
        /// <para>Tor clients don't build circuits for user traffic until they know</para>
        /// <para>about enough of the network so that they could potentially construct</para>
        /// <para>enough of the possible paths through the network. If this option</para>
        /// <para>is set to a fraction between 0.25 and 0.95, Tor won't build circuits</para>
        /// <para>until it has enough descriptors or microdescriptors to construct</para>
        /// <para>that fraction of possible paths. Note that setting this option too low</para>
        /// <para>can make your Tor client less anonymous, and setting it too high can</para>
        /// <para>prevent your Tor client from bootstrapping.  If this option is negative,</para>
        /// <para>Tor will use a default value chosen by the directory</para>
        /// <para>authorities. (Default: -1.)</para>
        /// </summary>
        PathsNeededToBuildCircuits,

        /// <summary>
        /// <para>Address address</para>
        /// <para>&#160;</para>
        /// <para>The IP address or fully qualified domain name of this server (e.g.</para>
        /// <para>moria.mit.edu). You can leave this unset, and Tor will guess your IP</para>
        /// <para>address.  This IP address is the one used to tell clients and other</para>
        /// <para>servers where to find your Tor server; it doesn't affect the IP that your</para>
        /// <para>Tor client binds to.  To bind to a different address, use the</para>
        /// <para>ListenAddress and OutboundBindAddress options.</para>
        /// </summary>
        Address,

        /// <summary>
        /// <para>AllowSingleHopExits 0|1</para>
        /// <para>&#160;</para>
        /// <para>This option controls whether clients can use this server as a single hop</para>
        /// <para>proxy. If set to 1, clients can use this server as an exit even if it is</para>
        /// <para>the only hop in the circuit.  Note that most clients will refuse to use</para>
        /// <para>servers that set this option, since most clients have</para>
        /// <para>ExcludeSingleHopRelays set.  (Default: 0)</para>
        /// </summary>
        AllowSingleHopExits,

        /// <summary>
        /// <para>AssumeReachable 0|1</para>
        /// <para>&#160;</para>
        /// <para>This option is used when bootstrapping a new Tor network. If set to 1,</para>
        /// <para>don't do self-reachability testing; just upload your server descriptor</para>
        /// <para>immediately. If AuthoritativeDirectory is also set, this option</para>
        /// <para>instructs the dirserver to bypass remote reachability testing too and list</para>
        /// <para>all connected servers as running.</para>
        /// </summary>
        AssumeReachable,

        /// <summary>
        /// <para>BridgeRelay 0|1</para>
        /// <para>&#160;</para>
        /// <para>Sets the relay to act as a "bridge" with respect to relaying connections</para>
        /// <para>from bridge users to the Tor network. It mainly causes Tor to publish a</para>
        /// <para>server descriptor to the bridge database, rather than</para>
        /// <para>to the public directory authorities.</para>
        /// </summary>
        BridgeRelay,

        /// <summary>
        /// <para>ContactInfo emailaddress</para>
        /// <para>&#160;</para>
        /// <para>Administrative contact information for this relay or bridge. This line</para>
        /// <para>can be used to contact you if your relay or bridge is misconfigured or</para>
        /// <para>something else goes wrong. Note that we archive and publish all</para>
        /// <para>descriptors containing these lines and that Google indexes them, so</para>
        /// <para>spammers might also collect them. You may want to obscure the fact</para>
        /// <para>that it's an email address and/or generate a new address for this</para>
        /// <para>purpose.</para>
        /// </summary>
        ContactInfo,

        /// <summary>
        /// <para>ExitRelay 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>Tells Tor whether to run as an exit relay.  If Tor is running as a</para>
        /// <para>non-bridge server, and ExitRelay is set to 1, then Tor allows traffic to</para>
        /// <para>exit according to the ExitPolicy option (or the default ExitPolicy if</para>
        /// <para>none is specified).</para>
        /// <para>&#160;</para>
        /// <para>If ExitRelay is set to 0, no traffic is allowed to</para>
        /// <para>exit, and the ExitPolicy option is ignored.</para>
        /// <para>&#160;</para>
        /// <para>If ExitRelay is set to "auto", then Tor behaves as if it were set to 1, but</para>
        /// <para>warns the user if this would cause traffic to exit.  In a future version,</para>
        /// <para>the default value will be 0. (Default: auto)</para>
        /// </summary>
        ExitRelay,

        /// <summary>
        /// <para>ExitPolicy policy,policy,...</para>
        /// <para>&#160;</para>
        /// <para>Set an exit policy for this server. Each policy is of the form</para>
        /// <para>"accept|reject ADDR[/MASK][:PORT]". If /MASK is</para>
        /// <para>omitted then this policy just applies to the host given. Instead of giving</para>
        /// <para>a host or network you can also use "" to denote the universe (0.0.0.0/0).</para>
        /// <para>PORT can be a single port number, an interval of ports</para>
        /// <para>"FROMPORT-TOPORT", or "". If PORT is omitted, that means</para>
        /// <para>"".</para>
        /// <para>&#160;</para>
        /// <para>For example, "accept 18.7.22.69:,reject 18.0.0.0/8:,accept :" would</para>
        /// <para>reject any traffic destined for MIT except for web.mit.edu, and accept</para>
        /// <para>anything else.</para>
        /// <para>&#160;</para>
        /// <para>To specify all internal and link-local networks (including 0.0.0.0/8,</para>
        /// <para>169.254.0.0/16,    127.0.0.0/8,    192.168.0.0/16, 10.0.0.0/8, and</para>
        /// <para>172.16.0.0/12), you can use the "private" alias instead of an address.</para>
        /// <para>These addresses are rejected by default (at the beginning of your exit</para>
        /// <para>policy), along with your public IP address, unless you set the</para>
        /// <para>ExitPolicyRejectPrivate config option to 0. For example, once you've done</para>
        /// <para>that, you could allow HTTP to 127.0.0.1 and block all other connections to</para>
        /// <para>internal networks with "accept 127.0.0.1:80,reject private:", though that</para>
        /// <para>may also allow connections to your own computer that are addressed to its</para>
        /// <para>public (external) IP address. See RFC 1918 and RFC 3330 for more details</para>
        /// <para>about internal and reserved IP address space.</para>
        /// <para>&#160;</para>
        /// <para>Tor also allow IPv6 exit policy entries. For instance, "reject6 [FC00]/7:"</para>
        /// <para>rejects all destinations that share 7 most significant bit prefix with </para>
        /// <para>address FC00. Respectively, "accept6 [C000]/3:" accepts all destinations</para>
        /// <para>that share 3 most significant bit prefix with address C000.</para>
        /// <para>&#160;</para>
        /// <para>This directive can be specified multiple times so you don't have to put it</para>
        /// <para>all on one line.</para>
        /// <para>&#160;</para>
        /// <para>Policies are considered first to last, and the first match wins. If you</para>
        /// <para>want to replace the default exit policy, end your exit policy with</para>
        /// <para>either a reject : or an accept :. Otherwise, you're augmenting</para>
        /// <para>(prepending to) the default exit policy. The default exit policy is:</para>
        /// <para>   reject :25</para>
        /// <para>   reject :119</para>
        /// <para>   reject :135-139</para>
        /// <para>   reject :445</para>
        /// <para>   reject :563</para>
        /// <para>   reject :1214</para>
        /// <para>   reject :4661-4666</para>
        /// <para>   reject :6346-6429</para>
        /// <para>   reject :6699</para>
        /// <para>   reject :6881-6999</para>
        /// <para>   accept :</para>
        /// </summary>
        ExitPolicy,

        /// <summary>
        /// <para>ExitPolicyRejectPrivate 0|1</para>
        /// <para>&#160;</para>
        /// <para>Reject all private (local) networks, along with your own public IP address,</para>
        /// <para>at the beginning of your exit policy. See above entry on ExitPolicy.</para>
        /// <para>(Default: 1)</para>
        /// </summary>
        ExitPolicyRejectPrivate,

        /// <summary>
        /// <para>IPv6Exit 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set, and we are an exit node, allow clients to use us for IPv6</para>
        /// <para>traffic. (Default: 0)</para>
        /// </summary>
        IPv6Exit,

        /// <summary>
        /// <para>MaxOnionQueueDelay NUM [msec|second]</para>
        /// <para>&#160;</para>
        /// <para>If we have more onionskins queued for processing than we can process in</para>
        /// <para>this amount of time, reject new ones. (Default: 1750 msec)</para>
        /// </summary>
        MaxOnionQueueDelay,

        /// <summary>
        /// <para>MyFamily node,node,...</para>
        /// <para>&#160;</para>
        /// <para>Declare that this Tor server is controlled or administered by a group or</para>
        /// <para>organization identical or similar to that of the other servers, defined by</para>
        /// <para>their identity fingerprints. When two servers both declare</para>
        /// <para>that they are in the same 'family', Tor clients will not use them in the</para>
        /// <para>same circuit. (Each server only needs to list the other servers in its</para>
        /// <para>family; it doesn't need to list itself, but it won't hurt.) Do not list</para>
        /// <para>any bridge relay as it would compromise its concealment.</para>
        /// <para>&#160;</para>
        /// <para>When listing a node, it's better to list it by fingerprint than by</para>
        /// <para>nickname: fingerprints are more reliable.</para>
        /// </summary>
        MyFamily,

        /// <summary>
        /// <para>Nickname name</para>
        /// <para>&#160;</para>
        /// <para>Set the server's nickname to 'name'. Nicknames must be between 1 and 19</para>
        /// <para>characters inclusive, and must contain only the characters [a-zA-Z0-9].</para>
        /// </summary>
        Nickname,

        /// <summary>
        /// <para>NumCPUs num</para>
        /// <para>&#160;</para>
        /// <para>How many processes to use at once for decrypting onionskins and other</para>
        /// <para>parallelizable operations.  If this is set to 0, Tor will try to detect</para>
        /// <para>how many CPUs you have, defaulting to 1 if it can't tell.  (Default: 0)</para>
        /// </summary>
        NumCPUs,

        /// <summary>
        /// <para>ORPort ['address':]PORT|auto [flags]</para>
        /// <para>&#160;</para>
        /// <para>Advertise this port to listen for connections from Tor clients and</para>
        /// <para>servers.  This option is required to be a Tor server.</para>
        /// <para>Set it to "auto" to have Tor pick a port for you. Set it to 0 to not</para>
        /// <para>run an ORPort at all. This option can occur more than once. (Default: 0)</para>
        /// <para>Tor recognizes these flags on each ORPort:</para>
        /// <para>NoAdvertise</para>
        /// <para>    By default, we bind to a port and tell our users about it. If</para>
        /// <para>    NoAdvertise is specified, we don't advertise, but listen anyway.  This</para>
        /// <para>    can be useful if the port everybody will be connecting to (for</para>
        /// <para>    example, one that's opened on our firewall) is somewhere else.</para>
        /// <para>NoListen</para>
        /// <para>    By default, we bind to a port and tell our users about it. If</para>
        /// <para>    NoListen is specified, we don't bind, but advertise anyway.  This</para>
        /// <para>    can be useful if something else  (for example, a firewall's port</para>
        /// <para>    forwarding configuration) is causing connections to reach us.</para>
        /// <para>IPv4Only</para>
        /// <para>    If the address is absent, or resolves to both an IPv4 and an IPv6</para>
        /// <para>    address, only listen to the IPv4 address.</para>
        /// <para>IPv6Only</para>
        /// <para>    If the address is absent, or resolves to both an IPv4 and an IPv6</para>
        /// <para>    address, only listen to the IPv6 address.</para>
        /// <para>For obvious reasons, NoAdvertise and NoListen are mutually exclusive, and</para>
        /// <para>IPv4Only and IPv6Only are mutually exclusive.</para>
        /// </summary>
        ORPort,

        /// <summary>
        /// <para>ORListenAddress IP[:PORT]</para>
        /// <para>&#160;</para>
        /// <para>Bind to this IP address to listen for connections from Tor clients and</para>
        /// <para>servers. If you specify a port, bind to this port rather than the one</para>
        /// <para>specified in ORPort. (Default: 0.0.0.0) This directive can be specified</para>
        /// <para>multiple times to bind to multiple addresses/ports.</para>
        /// <para>This option is deprecated; you can get the same behavior with ORPort now</para>
        /// <para>that it supports NoAdvertise and explicit addresses.</para>
        /// </summary>
        ORListenAddress,

        /// <summary>
        /// <para>PortForwarding 0|1</para>
        /// <para>&#160;</para>
        /// <para>Attempt to automatically forward the DirPort and ORPort on a NAT router</para>
        /// <para>connecting this Tor server to the Internet. If set, Tor will try both</para>
        /// <para>NAT-PMP (common on Apple routers) and UPnP (common on routers from other</para>
        /// <para>manufacturers). (Default: 0)</para>
        /// </summary>
        PortForwarding,

        /// <summary>
        /// <para>PortForwardingHelper filename|pathname</para>
        /// <para>&#160;</para>
        /// <para>If PortForwarding is set, use this executable to configure the forwarding.</para>
        /// <para>If set to a filename, the system path will be searched for the executable.</para>
        /// <para>If set to a path, only the specified path will be executed.</para>
        /// <para>(Default: tor-fw-helper)</para>
        /// </summary>
        PortForwardingHelper,

        /// <summary>
        /// <para>PublishServerDescriptor 0|1|v3|bridge,...</para>
        /// <para>&#160;</para>
        /// <para>This option specifies which descriptors Tor will publish when acting as</para>
        /// <para>a relay. You can</para>
        /// <para>choose multiple arguments, separated by commas.</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 0, Tor will not publish its</para>
        /// <para>descriptors to any directories. (This is useful if you're testing</para>
        /// <para>out your server, or if you're using a Tor controller that handles directory</para>
        /// <para>publishing for you.) Otherwise, Tor will publish its descriptors of all</para>
        /// <para>type(s) specified. The default is "1",</para>
        /// <para>which means "if running as a server, publish the</para>
        /// <para>appropriate descriptors to the authorities".</para>
        /// </summary>
        PublishServerDescriptor,

        /// <summary>
        /// <para>ShutdownWaitLength NUM</para>
        /// <para>&#160;</para>
        /// <para>When we get a SIGINT and we're a server, we begin shutting down:</para>
        /// <para>we close listeners and start refusing new circuits. After NUM</para>
        /// <para>seconds, we exit. If we get a second SIGINT, we exit immediately.</para>
        /// <para>(Default: 30 seconds)</para>
        /// </summary>
        ShutdownWaitLength,

        /// <summary>
        /// <para>SSLKeyLifetime N minutes|hours|days|weeks</para>
        /// <para>&#160;</para>
        /// <para>When creating a link certificate for our outermost SSL handshake,</para>
        /// <para>set its lifetime to this amount of time. If set to 0, Tor will choose</para>
        /// <para>some reasonable random defaults. (Default: 0)</para>
        /// </summary>
        SSLKeyLifetime,

        /// <summary>
        /// <para>HeartbeatPeriod  N minutes|hours|days|weeks</para>
        /// <para>&#160;</para>
        /// <para>Log a heartbeat message every HeartbeatPeriod seconds. This is</para>
        /// <para>a log level notice message, designed to let you know your Tor</para>
        /// <para>server is still alive and doing useful things. Settings this</para>
        /// <para>to 0 will disable the heartbeat. (Default: 6 hours)</para>
        /// </summary>
        HeartbeatPeriod,

        /// <summary>
        /// <para>AccountingMax N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits|TBytes</para>
        /// <para>&#160;</para>
        /// <para>Limits the max number of bytes sent and received within a set time period</para>
        /// <para>using a given calculation rule (see: AccountingStart, AccountingRule).</para>
        /// <para>Useful if you need to stay under a specific bandwidth. By default, the</para>
        /// <para>number used for calculation is the max of either the bytes sent or </para>
        /// <para>received. For example, with AccountingMax set to 1 GByte, a server</para>
        /// <para>could send 900 MBytes and receive 800 MBytes and continue running.</para>
        /// <para>It will only hibernate once one of the two reaches 1 GByte. This can</para>
        /// <para>be changed to use the sum of the both bytes received and sent by setting</para>
        /// <para>the AccountingRule option to "sum" (total bandwidth in/out). When the</para>
        /// <para>number of bytes remaining gets low, Tor will stop accepting new connections</para>
        /// <para>and circuits. When the number of bytes is exhausted, Tor will hibernate</para>
        /// <para>until some time in the next accounting period. To prevent all servers</para>
        /// <para>from waking at the same time, Tor will also wait until a random point</para>
        /// <para>in each period before waking up. If you have bandwidth cost issues,</para>
        /// <para>enabling hibernation is preferable to setting a low bandwidth, since</para>
        /// <para>it provides users with a collection of fast servers that are up some</para>
        /// <para>of the time, which is more useful than a set of slow servers that are</para>
        /// <para>always "available".</para>
        /// </summary>
        AccountingMax,

        /// <summary>
        /// <para>AccountingRule sum|max</para>
        /// <para>&#160;</para>
        /// <para>How we determine when our AccountingMax has been reached (when we</para>
        /// <para>should hibernate) during a time interval. Set to "max" to calculate</para>
        /// <para>using the higher of either the sent or received bytes (this is the</para>
        /// <para>default functionality). Set to "sum" to calculate using the sent</para>
        /// <para>plus received bytes. (Default: max)</para>
        /// </summary>
        AccountingRule,

        /// <summary>
        /// <para>AccountingStart day|week|month [day] HH:MM</para>
        /// <para>&#160;</para>
        /// <para>Specify how long accounting periods last. If month is given, each</para>
        /// <para>accounting period runs from the time HH:MM on the dayth day of one</para>
        /// <para>month to the same day and time of the next. (The day must be between 1 and</para>
        /// <para>28.) If week is given, each accounting period runs from the time HH:MM</para>
        /// <para>of the dayth day of one week to the same day and time of the next week,</para>
        /// <para>with Monday as day 1 and Sunday as day 7. If day is given, each</para>
        /// <para>accounting period runs from the time HH:MM each day to the same time on</para>
        /// <para>the next day. All times are local, and given in 24-hour time. (Default:</para>
        /// <para>"month 1 0:00")</para>
        /// </summary>
        AccountingStart,

        /// <summary>
        /// <para>RefuseUnknownExits 0|1|auto</para>
        /// <para>&#160;</para>
        /// <para>Prevent nodes that don't appear in the consensus from exiting using this</para>
        /// <para>relay.  If the option is 1, we always block exit attempts from such</para>
        /// <para>nodes; if it's 0, we never do, and if the option is "auto", then we do</para>
        /// <para>whatever the authorities suggest in the consensus (and block if the consensus</para>
        /// <para>is quiet on the issue). (Default: auto)</para>
        /// </summary>
        RefuseUnknownExits,

        /// <summary>
        /// <para>ServerDNSResolvConfFile filename</para>
        /// <para>&#160;</para>
        /// <para>Overrides the default DNS configuration with the configuration in</para>
        /// <para>filename. The file format is the same as the standard Unix</para>
        /// <para>"resolv.conf" file (7). This option, like all other ServerDNS options,</para>
        /// <para>only affects name lookups that your server does on behalf of clients.</para>
        /// <para>(Defaults to use the system DNS configuration.)</para>
        /// </summary>
        ServerDNSResolvConfFile,

        /// <summary>
        /// <para>ServerDNSAllowBrokenConfig 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is false, Tor exits immediately if there are problems</para>
        /// <para>parsing the system DNS configuration or connecting to nameservers.</para>
        /// <para>Otherwise, Tor continues to periodically retry the system nameservers until</para>
        /// <para>it eventually succeeds. (Default: 1)</para>
        /// </summary>
        ServerDNSAllowBrokenConfig,

        /// <summary>
        /// <para>ServerDNSSearchDomains 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, then we will search for addresses in the local search domain.</para>
        /// <para>For example, if this system is configured to believe it is in</para>
        /// <para>"example.com", and a client tries to connect to "www", the client will be</para>
        /// <para>connected to "www.example.com". This option only affects name lookups that</para>
        /// <para>your server does on behalf of clients. (Default: 0)</para>
        /// </summary>
        ServerDNSSearchDomains,

        /// <summary>
        /// <para>ServerDNSDetectHijacking 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set to 1, we will test periodically to determine</para>
        /// <para>whether our local nameservers have been configured to hijack failing DNS</para>
        /// <para>requests (usually to an advertising site). If they are, we will attempt to</para>
        /// <para>correct this. This option only affects name lookups that your server does</para>
        /// <para>on behalf of clients. (Default: 1)</para>
        /// </summary>
        ServerDNSDetectHijacking,

        /// <summary>
        /// <para>ServerDNSTestAddresses address,address,...</para>
        /// <para>&#160;</para>
        /// <para>When we're detecting DNS hijacking, make sure that these valid addresses</para>
        /// <para>aren't getting redirected. If they are, then our DNS is completely useless,</para>
        /// <para>and we'll reset our exit policy to "reject :". This option only affects</para>
        /// <para>name lookups that your server does on behalf of clients. (Default:</para>
        /// <para>"www.google.com, www.mit.edu, www.yahoo.com, www.slashdot.org")</para>
        /// </summary>
        ServerDNSTestAddresses,

        /// <summary>
        /// <para>ServerDNSAllowNonRFC953Hostnames 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is disabled, Tor does not try to resolve hostnames</para>
        /// <para>containing illegal characters (like @ and :) rather than sending them to an</para>
        /// <para>exit node to be resolved. This helps trap accidental attempts to resolve</para>
        /// <para>URLs and so on. This option only affects name lookups that your server does</para>
        /// <para>on behalf of clients. (Default: 0)</para>
        /// </summary>
        ServerDNSAllowNonRFC953Hostnames,

        /// <summary>
        /// <para>BridgeRecordUsageByCountry 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is enabled and BridgeRelay is also enabled, and we have</para>
        /// <para>GeoIP data, Tor keeps a per-country count of how many client</para>
        /// <para>addresses have contacted it so that it can help the bridge authority guess</para>
        /// <para>which countries have blocked access to it. (Default: 1)</para>
        /// </summary>
        BridgeRecordUsageByCountry,

        /// <summary>
        /// <para>ServerDNSRandomizeCase 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, Tor sets the case of each character randomly in</para>
        /// <para>outgoing DNS requests, and makes sure that the case matches in DNS replies.</para>
        /// <para>This so-called "0x20 hack" helps resist some types of DNS poisoning attack.</para>
        /// <para>For more information, see "Increased DNS Forgery Resistance through</para>
        /// <para>0x20-Bit Encoding". This option only affects name lookups that your server</para>
        /// <para>does on behalf of clients. (Default: 1)</para>
        /// </summary>
        ServerDNSRandomizeCase,

        /// <summary>
        /// <para>GeoIPFile filename</para>
        /// <para>&#160;</para>
        /// <para>A filename containing IPv4 GeoIP data, for use with by-country statistics.</para>
        /// </summary>
        GeoIPFile,

        /// <summary>
        /// <para>GeoIPv6File filename</para>
        /// <para>&#160;</para>
        /// <para>A filename containing IPv6 GeoIP data, for use with by-country statistics.</para>
        /// </summary>
        GeoIPv6File,

        /// <summary>
        /// <para>TLSECGroup P224|P256</para>
        /// <para>&#160;</para>
        /// <para>What EC group should we try to use for incoming TLS connections?</para>
        /// <para>P224 is faster, but makes us stand out more. Has no effect if</para>
        /// <para>we're a client, or if our OpenSSL version lacks support for ECDHE.</para>
        /// <para>(Default: P256)</para>
        /// </summary>
        TLSECGroup,

        /// <summary>
        /// <para>CellStatistics 0|1</para>
        /// <para>&#160;</para>
        /// <para>Relays only.</para>
        /// <para>When this option is enabled, Tor collects statistics about cell</para>
        /// <para>processing (i.e. mean time a cell is spending in a queue, mean</para>
        /// <para>number of cells in a queue and mean number of processed cells per</para>
        /// <para>circuit) and writes them into disk every 24 hours. Onion router</para>
        /// <para>operators may use the statistics for performance monitoring.</para>
        /// <para>If ExtraInfoStatistics is enabled, it will published as part of</para>
        /// <para>extra-info document. (Default: 0)</para>
        /// </summary>
        CellStatistics,

        /// <summary>
        /// <para>DirReqStatistics 0|1</para>
        /// <para>&#160;</para>
        /// <para>Relays and bridges only.</para>
        /// <para>When this option is enabled, a Tor directory writes statistics on the</para>
        /// <para>number and response time of network status requests to disk every 24</para>
        /// <para>hours. Enables relay and bridge operators to monitor how much their</para>
        /// <para>server is being used by clients to learn about Tor network.</para>
        /// <para>If ExtraInfoStatistics is enabled, it will published as part of</para>
        /// <para>extra-info document. (Default: 1)</para>
        /// </summary>
        DirReqStatistics,

        /// <summary>
        /// <para>EntryStatistics 0|1</para>
        /// <para>&#160;</para>
        /// <para>Relays only.</para>
        /// <para>When this option is enabled, Tor writes statistics on the number of</para>
        /// <para>directly connecting clients to disk every 24 hours. Enables relay</para>
        /// <para>operators to monitor how much inbound traffic that originates from</para>
        /// <para>Tor clients passes through their server to go further down the</para>
        /// <para>Tor network. If ExtraInfoStatistics is enabled, it will be published</para>
        /// <para>as part of extra-info document. (Default: 0)</para>
        /// </summary>
        EntryStatistics,

        /// <summary>
        /// <para>ExitPortStatistics 0|1</para>
        /// <para>&#160;</para>
        /// <para>Exit relays only.</para>
        /// <para>When this option is enabled, Tor writes statistics on the number of</para>
        /// <para>relayed bytes and opened stream per exit port to disk every 24 hours.</para>
        /// <para>Enables exit relay operators to measure and monitor amounts of traffic</para>
        /// <para>that leaves Tor network through their exit node. If ExtraInfoStatistics</para>
        /// <para>is enabled, it will be published as part of extra-info document.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        ExitPortStatistics,

        /// <summary>
        /// <para>ConnDirectionStatistics 0|1</para>
        /// <para>&#160;</para>
        /// <para>Relays only.</para>
        /// <para>When this option is enabled, Tor writes statistics on the amounts of</para>
        /// <para>traffic it passes between itself and other relays to disk every 24</para>
        /// <para>hours. Enables relay operators to monitor how much their relay is</para>
        /// <para>being used as middle node in the circuit. If ExtraInfoStatistics is</para>
        /// <para>enabled, it will be published as part of extra-info document.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        ConnDirectionStatistics,

        /// <summary>
        /// <para>HiddenServiceStatistics 0|1</para>
        /// <para>&#160;</para>
        /// <para>Relays only.</para>
        /// <para>When this option is enabled, a Tor relay writes obfuscated</para>
        /// <para>statistics on its role as hidden-service directory, introduction</para>
        /// <para>point, or rendezvous point to disk every 24 hours. If</para>
        /// <para>ExtraInfoStatistics is also enabled, these statistics are further</para>
        /// <para>published to the directory authorities. (Default: 0)</para>
        /// </summary>
        HiddenServiceStatistics,

        /// <summary>
        /// <para>ExtraInfoStatistics 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is enabled, Tor includes previously gathered statistics in</para>
        /// <para>its extra-info documents that it uploads to the directory authorities.</para>
        /// <para>(Default: 1)</para>
        /// </summary>
        ExtraInfoStatistics,

        /// <summary>
        /// <para>ExtendAllowPrivateAddresses 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is enabled, Tor routers allow EXTEND request to</para>
        /// <para>localhost, RFC1918 addresses, and so on. This can create security issues;</para>
        /// <para>you should probably leave it off. (Default: 0)</para>
        /// </summary>
        ExtendAllowPrivateAddresses,

        /// <summary>
        /// <para>MaxMemInQueues  N bytes|KB|MB|GB</para>
        /// <para>&#160;</para>
        /// <para>This option configures a threshold above which Tor will assume that it</para>
        /// <para>needs to stop queueing or buffering data because it's about to run out of</para>
        /// <para>memory.  If it hits this threshold, it will begin killing circuits until</para>
        /// <para>it has recovered at least 10% of this memory.  Do not set this option too</para>
        /// <para>low, or your relay may be unreliable under load.  This option only</para>
        /// <para>affects some queues, so the actual process size will be larger than</para>
        /// <para>this.  If this option is set to 0, Tor will try to pick a reasonable</para>
        /// <para>default based on your system's physical memory.  (Default: 0)</para>
        /// </summary>
        MaxMemInQueues,

        /// <summary>
        /// <para>SigningKeyLifetime N days|weeks|months</para>
        /// <para>&#160;</para>
        /// <para>For how long should each Ed25519 signing key be valid?  Tor uses a</para>
        /// <para>permanent master identity key that can be kept offline, and periodically</para>
        /// <para>generates new "signing" keys that it uses online.  This option</para>
        /// <para>configures their lifetime.</para>
        /// <para>(Default: 30 days)</para>
        /// </summary>
        SigningKeyLifetime,

        /// <summary>
        /// <para>DirPortFrontPage FILENAME</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, it takes an HTML file and publishes it as "/" on</para>
        /// <para>the DirPort. Now relay operators can provide a disclaimer without needing</para>
        /// <para>to set up a separate webserver. There's a sample disclaimer in</para>
        /// <para>contrib/operator-tools/tor-exit-notice.html.</para>
        /// </summary>
        DirPortFrontPage,

        /// <summary>
        /// <para>HidServDirectoryV2 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set, Tor accepts and serves v2 hidden service</para>
        /// <para>descriptors. Setting DirPort is not required for this, because clients</para>
        /// <para>connect via the ORPort by default. (Default: 1)</para>
        /// </summary>
        HidServDirectoryV2,

        /// <summary>
        /// <para>DirPort ['address':]PORT|auto [flags]</para>
        /// <para>&#160;</para>
        /// <para>If this option is nonzero, advertise the directory service on this port.</para>
        /// <para>Set it to "auto" to have Tor pick a port for you.  This option can occur</para>
        /// <para>more than once, but only one advertised DirPort is supported: all</para>
        /// <para>but one DirPort must have the NoAdvertise flag set. (Default: 0)</para>
        /// <para>The same flags are supported here as are supported by ORPort.</para>
        /// </summary>
        DirPort,

        /// <summary>
        /// <para>DirListenAddress IP[:PORT]</para>
        /// <para>&#160;</para>
        /// <para>Bind the directory service to this address. If you specify a port, bind to</para>
        /// <para>this port rather than the one specified in DirPort.  (Default: 0.0.0.0)</para>
        /// <para>This directive can be specified multiple times  to bind to multiple</para>
        /// <para>addresses/ports.</para>
        /// <para>This option is deprecated; you can get the same behavior with DirPort now</para>
        /// <para>that it supports NoAdvertise and explicit addresses.</para>
        /// </summary>
        DirListenAddress,

        /// <summary>
        /// <para>DirPolicy policy,policy,...</para>
        /// <para>&#160;</para>
        /// <para>Set an entrance policy for this server, to limit who can connect to the</para>
        /// <para>directory ports. The policies have the same form as exit policies above,</para>
        /// <para>except that port specifiers are ignored. Any address not matched by</para>
        /// <para>some entry in the policy is accepted.</para>
        /// </summary>
        DirPolicy,

        /// <summary>
        /// <para>AuthoritativeDirectory 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set to 1, Tor operates as an authoritative directory</para>
        /// <para>server. Instead of caching the directory, it generates its own list of</para>
        /// <para>good servers, signs it, and sends that to the clients. Unless the clients</para>
        /// <para>already have you listed as a trusted directory, you probably do not want</para>
        /// <para>to set this option. Please coordinate with the other admins at</para>
        /// <para>tor-ops@torproject.org if you think you should be a directory.</para>
        /// </summary>
        AuthoritativeDirectory,

        /// <summary>
        /// <para>V3AuthoritativeDirectory 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set in addition to AuthoritativeDirectory, Tor</para>
        /// <para>generates version 3 network statuses and serves descriptors, etc as</para>
        /// <para>described in doc/spec/dir-spec.txt (for Tor clients and servers running at</para>
        /// <para>least 0.2.0.x).</para>
        /// </summary>
        V3AuthoritativeDirectory,

        /// <summary>
        /// <para>VersioningAuthoritativeDirectory 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set to 1, Tor adds information on which versions of</para>
        /// <para>Tor are still believed safe for use to the published directory. Each</para>
        /// <para>version 1 authority is automatically a versioning authority; version 2</para>
        /// <para>authorities provide this service optionally. See RecommendedVersions,</para>
        /// <para>RecommendedClientVersions, and RecommendedServerVersions.</para>
        /// </summary>
        VersioningAuthoritativeDirectory,

        /// <summary>
        /// <para>RecommendedVersions STRING</para>
        /// <para>&#160;</para>
        /// <para>STRING is a comma-separated list of Tor versions currently believed to be</para>
        /// <para>safe. The list is included in each directory, and nodes which pull down the</para>
        /// <para>directory learn whether they need to upgrade. This option can appear</para>
        /// <para>multiple times: the values from multiple lines are spliced together. When</para>
        /// <para>this is set then VersioningAuthoritativeDirectory should be set too.</para>
        /// </summary>
        RecommendedVersions,

        /// <summary>
        /// <para>RecommendedPackageVersions PACKAGENAME VERSION URL DIGESTTYPE=DIGEST </para>
        /// <para>&#160;</para>
        /// <para>Adds "package" line to the directory authority's vote.  This information</para>
        /// <para>is used to vote on the correct URL and digest for the released versions</para>
        /// <para>of different Tor-related packages, so that the consensus can certify</para>
        /// <para>them.  This line may appear any number of times.</para>
        /// </summary>
        RecommendedPackageVersions,

        /// <summary>
        /// <para>RecommendedClientVersions STRING</para>
        /// <para>&#160;</para>
        /// <para>STRING is a comma-separated list of Tor versions currently believed to be</para>
        /// <para>safe for clients to use. This information is included in version 2</para>
        /// <para>directories. If this is not set then the value of RecommendedVersions</para>
        /// <para>is used. When this is set then VersioningAuthoritativeDirectory should</para>
        /// <para>be set too.</para>
        /// </summary>
        RecommendedClientVersions,

        /// <summary>
        /// <para>BridgeAuthoritativeDir 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set in addition to AuthoritativeDirectory, Tor</para>
        /// <para>accepts and serves server descriptors, but it caches and serves the main</para>
        /// <para>networkstatus documents rather than generating its own. (Default: 0)</para>
        /// </summary>
        BridgeAuthoritativeDir,

        /// <summary>
        /// <para>MinUptimeHidServDirectoryV2 N seconds|minutes|hours|days|weeks</para>
        /// <para>&#160;</para>
        /// <para>Minimum uptime of a v2 hidden service directory to be accepted as such by</para>
        /// <para>authoritative directories. (Default: 25 hours)</para>
        /// </summary>
        MinUptimeHidServDirectoryV2,

        /// <summary>
        /// <para>RecommendedServerVersions STRING</para>
        /// <para>&#160;</para>
        /// <para>STRING is a comma-separated list of Tor versions currently believed to be</para>
        /// <para>safe for servers to use. This information is included in version 2</para>
        /// <para>directories. If this is not set then the value of RecommendedVersions</para>
        /// <para>is used. When this is set then VersioningAuthoritativeDirectory should</para>
        /// <para>be set too.</para>
        /// </summary>
        RecommendedServerVersions,

        /// <summary>
        /// <para>ConsensusParams STRING</para>
        /// <para>&#160;</para>
        /// <para>STRING is a space-separated list of key=value pairs that Tor will include</para>
        /// <para>in the "params" line of its networkstatus vote.</para>
        /// </summary>
        ConsensusParams,

        /// <summary>
        /// <para>DirAllowPrivateAddresses 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor will accept server descriptors with arbitrary "Address"</para>
        /// <para>elements. Otherwise, if the address is not an IP address or is a private IP</para>
        /// <para>address, it will reject the server descriptor. (Default: 0)</para>
        /// </summary>
        DirAllowPrivateAddresses,

        /// <summary>
        /// <para>AuthDirBadExit AddressPattern...</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. A set of address patterns for servers that</para>
        /// <para>will be listed as bad exits in any network status document this authority</para>
        /// <para>publishes, if AuthDirListBadExits is set.</para>
        /// <para>&#160;</para>
        /// <para>(The address pattern syntax here and in the options below</para>
        /// <para>is the same as for exit policies, except that you don't need to say</para>
        /// <para>"accept" or "reject", and ports are not needed.)</para>
        /// </summary>
        AuthDirBadExit,

        /// <summary>
        /// <para>AuthDirInvalid AddressPattern...</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. A set of address patterns for servers that</para>
        /// <para>will never be listed as "valid" in any network status document that this</para>
        /// <para>authority publishes.</para>
        /// </summary>
        AuthDirInvalid,

        /// <summary>
        /// <para>AuthDirReject AddressPattern...</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. A set of address patterns for servers that</para>
        /// <para>will never be listed at all in any network status document that this</para>
        /// <para>authority publishes, or accepted as an OR address in any descriptor</para>
        /// <para>submitted for publication by this authority.</para>
        /// </summary>
        AuthDirReject,

        /// <summary>
        /// <para>AuthDirBadExitCCs CC,...</para>
        /// <para>&#160;</para>
        /// </summary>
        AuthDirBadExitCCs,

        /// <summary>
        /// <para>AuthDirInvalidCCs CC,...</para>
        /// <para>&#160;</para>
        /// </summary>
        AuthDirInvalidCCs,

        /// <summary>
        /// <para>AuthDirRejectCCs CC,...</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. These options contain a comma-separated</para>
        /// <para>list of country codes such that any server in one of those country codes</para>
        /// <para>will be marked as a bad exit/invalid for use, or rejected</para>
        /// <para>entirely.</para>
        /// </summary>
        AuthDirRejectCCs,

        /// <summary>
        /// <para>AuthDirListBadExits 0|1</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. If set to 1, this directory has some</para>
        /// <para>opinion about which nodes are unsuitable as exit nodes. (Do not set this to</para>
        /// <para>1 unless you plan to list non-functioning exits as bad; otherwise, you are</para>
        /// <para>effectively voting in favor of every declared exit as an exit.)</para>
        /// </summary>
        AuthDirListBadExits,

        /// <summary>
        /// <para>AuthDirMaxServersPerAddr NUM</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. The maximum number of servers that we will</para>
        /// <para>list as acceptable on a single IP address. Set this to "0" for "no limit".</para>
        /// <para>(Default: 2)</para>
        /// </summary>
        AuthDirMaxServersPerAddr,

        /// <summary>
        /// <para>AuthDirMaxServersPerAuthAddr NUM</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. Like AuthDirMaxServersPerAddr, but applies</para>
        /// <para>to addresses shared with directory authorities. (Default: 5)</para>
        /// </summary>
        AuthDirMaxServersPerAuthAddr,

        /// <summary>
        /// <para>AuthDirFastGuarantee N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. If non-zero, always vote the</para>
        /// <para>Fast flag for any relay advertising this amount of capacity or</para>
        /// <para>more. (Default: 100 KBytes)</para>
        /// </summary>
        AuthDirFastGuarantee,

        /// <summary>
        /// <para>AuthDirGuardBWGuarantee N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. If non-zero, this advertised capacity</para>
        /// <para>or more is always sufficient to satisfy the bandwidth requirement</para>
        /// <para>for the Guard flag. (Default: 250 KBytes)</para>
        /// </summary>
        AuthDirGuardBWGuarantee,

        /// <summary>
        /// <para>BridgePassword Password</para>
        /// <para>&#160;</para>
        /// <para>If set, contains an HTTP authenticator that tells a bridge authority to</para>
        /// <para>serve all requested bridge information. Used by the (only partially</para>
        /// <para>implemented) "bridge community" design, where a community of bridge</para>
        /// <para>relay operators all use an alternate bridge directory authority,</para>
        /// <para>and their target user audience can periodically fetch the list of</para>
        /// <para>available community bridges to stay up-to-date. (Default: not set)</para>
        /// </summary>
        BridgePassword,

        /// <summary>
        /// <para>V3AuthVotingInterval N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>V3 authoritative directories only. Configures the server's preferred voting</para>
        /// <para>interval. Note that voting will actually happen at an interval chosen</para>
        /// <para>by consensus from all the authorities' preferred intervals. This time</para>
        /// <para>SHOULD divide evenly into a day. (Default: 1 hour)</para>
        /// </summary>
        V3AuthVotingInterval,

        /// <summary>
        /// <para>V3AuthVoteDelay N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>V3 authoritative directories only. Configures the server's preferred delay</para>
        /// <para>between publishing its vote and assuming it has all the votes from all the</para>
        /// <para>other authorities. Note that the actual time used is not the server's</para>
        /// <para>preferred time, but the consensus of all preferences. (Default: 5 minutes)</para>
        /// </summary>
        V3AuthVoteDelay,

        /// <summary>
        /// <para>V3AuthDistDelay N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>V3 authoritative directories only. Configures the server's preferred  delay</para>
        /// <para>between publishing its consensus and signature and assuming  it has all the</para>
        /// <para>signatures from all the other authorities. Note that the actual time used</para>
        /// <para>is not the server's preferred time,  but the consensus of all preferences.</para>
        /// <para>(Default: 5 minutes)</para>
        /// </summary>
        V3AuthDistDelay,

        /// <summary>
        /// <para>V3AuthNIntervalsValid NUM</para>
        /// <para>&#160;</para>
        /// <para>V3 authoritative directories only. Configures the number of VotingIntervals</para>
        /// <para>for which each consensus should be valid for. Choosing high numbers</para>
        /// <para>increases network partitioning risks; choosing low numbers increases</para>
        /// <para>directory traffic. Note that the actual number of intervals used is not the</para>
        /// <para>server's preferred number, but the consensus of all preferences. Must be at</para>
        /// <para>least 2. (Default: 3)</para>
        /// </summary>
        V3AuthNIntervalsValid,

        /// <summary>
        /// <para>V3BandwidthsFile FILENAME</para>
        /// <para>&#160;</para>
        /// <para>V3 authoritative directories only. Configures the location of the</para>
        /// <para>bandwidth-authority generated file storing information on relays' measured</para>
        /// <para>bandwidth capacities. (Default: unset)</para>
        /// </summary>
        V3BandwidthsFile,

        /// <summary>
        /// <para>V3AuthUseLegacyKey 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set, the directory authority will sign consensuses not only with its</para>
        /// <para>own signing key, but also with a "legacy" key and certificate with a</para>
        /// <para>different identity.  This feature is used to migrate directory authority</para>
        /// <para>keys in the event of a compromise.  (Default: 0)</para>
        /// </summary>
        V3AuthUseLegacyKey,

        /// <summary>
        /// <para>RephistTrackTime N seconds|minutes|hours|days|weeks</para>
        /// <para>&#160;</para>
        /// <para>Tells an authority, or other node tracking node reliability and history,</para>
        /// <para>that fine-grained information about nodes can be discarded when it hasn't</para>
        /// <para>changed for a given amount of time.  (Default: 24 hours)</para>
        /// </summary>
        RephistTrackTime,

        /// <summary>
        /// <para>VoteOnHidServDirectoriesV2 0|1</para>
        /// <para>&#160;</para>
        /// <para>When this option is set in addition to AuthoritativeDirectory, Tor</para>
        /// <para>votes on whether to accept relays as hidden service directories.</para>
        /// <para>(Default: 1)</para>
        /// </summary>
        VoteOnHidServDirectoriesV2,

        /// <summary>
        /// <para>AuthDirHasIPv6Connectivity 0|1</para>
        /// <para>&#160;</para>
        /// <para>Authoritative directories only. When set to 0, OR ports with an</para>
        /// <para>IPv6 address are being accepted without reachability testing.</para>
        /// <para>When set to 1, IPv6 OR ports are being tested just like IPv4 OR</para>
        /// <para>ports. (Default: 0)</para>
        /// </summary>
        AuthDirHasIPv6Connectivity,

        /// <summary>
        /// <para>MinMeasuredBWsForAuthToIgnoreAdvertised N</para>
        /// <para>&#160;</para>
        /// <para>A total value, in abstract bandwidth units, describing how much</para>
        /// <para>measured total bandwidth an authority should have observed on the network</para>
        /// <para>before it will treat advertised bandwidths as wholly</para>
        /// <para>unreliable. (Default: 500)</para>
        /// </summary>
        MinMeasuredBWsForAuthToIgnoreAdvertised,

        /// <summary>
        /// <para>HiddenServiceDir DIRECTORY</para>
        /// <para>&#160;</para>
        /// <para>Store data files for a hidden service in DIRECTORY. Every hidden service</para>
        /// <para>must have a separate directory. You may use this option  multiple times to</para>
        /// <para>specify multiple services. DIRECTORY must be an existing directory.</para>
        /// <para>(Note: in current versions of Tor, if DIRECTORY is a relative path,</para>
        /// <para>it will be relative to current</para>
        /// <para>working directory of Tor instance, not to its DataDirectory.  Do not</para>
        /// <para>rely on this behavior; it is not guaranteed to remain the same in future</para>
        /// <para>versions.)</para>
        /// </summary>
        HiddenServiceDir,

        /// <summary>
        /// <para>HiddenServicePort VIRTPORT [TARGET]</para>
        /// <para>&#160;</para>
        /// <para>Configure a virtual port VIRTPORT for a hidden service. You may use this</para>
        /// <para>option multiple times; each time applies to the service using the most</para>
        /// <para>recent HiddenServiceDir. By default, this option maps the virtual port to</para>
        /// <para>the same port on 127.0.0.1 over TCP. You may override the target port,</para>
        /// <para>address, or both by specifying a target of addr, port, or addr:port.</para>
        /// <para>(You can specify an IPv6 target as [addr]:port.)</para>
        /// <para>You may also have multiple lines with  the same VIRTPORT: when a user</para>
        /// <para>connects to that VIRTPORT, one of the TARGETs from those lines will be</para>
        /// <para>chosen at random.</para>
        /// </summary>
        HiddenServicePort,

        /// <summary>
        /// <para>PublishHidServDescriptors 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 0, Tor will run any hidden services you configure, but it won't</para>
        /// <para>advertise them to the rendezvous directory. This option is only useful if</para>
        /// <para>you're using a Tor controller that handles hidserv publishing for you.</para>
        /// <para>(Default: 1)</para>
        /// </summary>
        PublishHidServDescriptors,

        /// <summary>
        /// <para>HiddenServiceVersion version,version,...</para>
        /// <para>&#160;</para>
        /// <para>A list of rendezvous service descriptor versions to publish for the hidden</para>
        /// <para>service. Currently, only version 2 is supported. (Default: 2)</para>
        /// </summary>
        HiddenServiceVersion,

        /// <summary>
        /// <para>HiddenServiceAuthorizeClient auth-type client-name,client-name,...</para>
        /// <para>&#160;</para>
        /// <para>If configured, the hidden service is accessible for authorized clients</para>
        /// <para>only. The auth-type can either be 'basic' for a general-purpose</para>
        /// <para>authorization protocol or 'stealth' for a less scalable protocol that also</para>
        /// <para>hides service activity from unauthorized clients. Only clients that are</para>
        /// <para>listed here are authorized to access the hidden service. Valid client names</para>
        /// <para>are 1 to 16 characters long and only use characters in A-Za-z0-9+- (no</para>
        /// <para>spaces). If this option is set, the hidden service is not accessible for</para>
        /// <para>clients without authorization any more. Generated authorization data can be</para>
        /// <para>found in the hostname file. Clients need to put this authorization data in</para>
        /// <para>their configuration file using HidServAuth.</para>
        /// </summary>
        HiddenServiceAuthorizeClient,

        /// <summary>
        /// <para>HiddenServiceAllowUnknownPorts 0|1</para>
        /// <para>&#160;</para>
        /// <para>f set to 1, then connections to unrecognized ports do not cause the</para>
        /// <para>urrent hidden service to close rendezvous circuits. (Setting this to 0 is</para>
        /// <para>ot an authorization mechanism; it is instead meant to be a mild</para>
        /// <para>nconvenience to port-scanners.) (Default: 0)</para>
        /// </summary>
        HiddenServiceAllowUnknownPorts,

        /// <summary>
        /// <para>HiddenServiceMaxStreams N</para>
        /// <para>&#160;</para>
        /// <para>he maximum number of simultaneous streams (connections) per rendezvous</para>
        /// <para>ircuit. (Setting this to 0 will allow an unlimited number of simultanous</para>
        /// <para>treams.) (Default: 0)</para>
        /// </summary>
        HiddenServiceMaxStreams,

        /// <summary>
        /// <para>HiddenServiceMaxStreamsCloseCircuit 0|1</para>
        /// <para>&#160;</para>
        /// <para>f set to 1, then exceeding HiddenServiceMaxStreams will cause the</para>
        /// <para>ffending rendezvous circuit to be torn down, as opposed to stream creation</para>
        /// <para>equests that exceed the limit being silently ignored. (Default: 0)</para>
        /// </summary>
        HiddenServiceMaxStreamsCloseCircuit,

        /// <summary>
        /// <para>RendPostPeriod N seconds|minutes|hours|days|weeks</para>
        /// <para>&#160;</para>
        /// <para>Every time the specified period elapses, Tor uploads any rendezvous</para>
        /// <para>service descriptors to the directory servers. This information  is also</para>
        /// <para>uploaded whenever it changes. (Default: 1 hour)</para>
        /// </summary>
        RendPostPeriod,

        /// <summary>
        /// <para>HiddenServiceDirGroupReadable 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set to 1, allow the filesystem group to read the</para>
        /// <para>hidden service directory and hostname file. If the option is set to 0,</para>
        /// <para>only owner is able to read the hidden service directory. (Default: 0)</para>
        /// <para>Has no effect on Windows.</para>
        /// </summary>
        HiddenServiceDirGroupReadable,

        /// <summary>
        /// <para>TestingTorNetwork 0|1</para>
        /// <para>&#160;</para>
        /// <para>If set to 1, Tor adjusts default values of the configuration options below,</para>
        /// <para>so that it is easier to set up a testing Tor network. May only be set if</para>
        /// <para>non-default set of DirAuthorities is set. Cannot be unset while Tor is</para>
        /// <para>running.</para>
        /// <para>(Default: 0)</para>
        /// <para>   ServerDNSAllowBrokenConfig 1</para>
        /// <para>   DirAllowPrivateAddresses 1</para>
        /// <para>   EnforceDistinctSubnets 0</para>
        /// <para>   AssumeReachable 1</para>
        /// <para>   AuthDirMaxServersPerAddr 0</para>
        /// <para>   AuthDirMaxServersPerAuthAddr 0</para>
        /// <para>   ClientDNSRejectInternalAddresses 0</para>
        /// <para>   ClientRejectInternalAddresses 0</para>
        /// <para>   CountPrivateBandwidth 1</para>
        /// <para>   ExitPolicyRejectPrivate 0</para>
        /// <para>   ExtendAllowPrivateAddresses 1</para>
        /// <para>   V3AuthVotingInterval 5 minutes</para>
        /// <para>   V3AuthVoteDelay 20 seconds</para>
        /// <para>   V3AuthDistDelay 20 seconds</para>
        /// <para>   MinUptimeHidServDirectoryV2 0 seconds</para>
        /// <para>   TestingV3AuthInitialVotingInterval 5 minutes</para>
        /// <para>   TestingV3AuthInitialVoteDelay 20 seconds</para>
        /// <para>   TestingV3AuthInitialDistDelay 20 seconds</para>
        /// <para>   TestingAuthDirTimeToLearnReachability 0 minutes</para>
        /// <para>   TestingEstimatedDescriptorPropagationTime 0 minutes</para>
        /// <para>   TestingServerDownloadSchedule 0, 0, 0, 5, 10, 15, 20, 30, 60</para>
        /// <para>   TestingClientDownloadSchedule 0, 0, 5, 10, 15, 20, 30, 60</para>
        /// <para>   TestingServerConsensusDownloadSchedule 0, 0, 5, 10, 15, 20, 30, 60</para>
        /// <para>   TestingClientConsensusDownloadSchedule 0, 0, 5, 10, 15, 20, 30, 60</para>
        /// <para>   TestingBridgeDownloadSchedule 60, 30, 30, 60</para>
        /// <para>   TestingClientMaxIntervalWithoutRequest 5 seconds</para>
        /// <para>   TestingDirConnectionMaxStall 30 seconds</para>
        /// <para>   TestingConsensusMaxDownloadTries 80</para>
        /// <para>   TestingDescriptorMaxDownloadTries 80</para>
        /// <para>   TestingMicrodescMaxDownloadTries 80</para>
        /// <para>   TestingCertMaxDownloadTries 80</para>
        /// <para>   TestingEnableConnBwEvent 1</para>
        /// <para>   TestingEnableCellStatsEvent 1</para>
        /// <para>   TestingEnableTbEmptyEvent 1</para>
        /// </summary>
        TestingTorNetwork,

        /// <summary>
        /// <para>TestingV3AuthInitialVotingInterval N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>Like V3AuthVotingInterval, but for initial voting interval before the first</para>
        /// <para>consensus has been created. Changing this requires that</para>
        /// <para>TestingTorNetwork is set. (Default: 30 minutes)</para>
        /// </summary>
        TestingV3AuthInitialVotingInterval,

        /// <summary>
        /// <para>TestingV3AuthInitialVoteDelay N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>Like V3AuthVoteDelay, but for initial voting interval before</para>
        /// <para>the first consensus has been created. Changing this requires that</para>
        /// <para>TestingTorNetwork is set. (Default: 5 minutes)</para>
        /// </summary>
        TestingV3AuthInitialVoteDelay,

        /// <summary>
        /// <para>TestingV3AuthInitialDistDelay N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>Like V3AuthDistDelay, but for initial voting interval before</para>
        /// <para>the first consensus has been created. Changing this requires that</para>
        /// <para>TestingTorNetwork is set. (Default: 5 minutes)</para>
        /// </summary>
        TestingV3AuthInitialDistDelay,

        /// <summary>
        /// <para>TestingV3AuthVotingStartOffset N seconds|minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>Directory authorities offset voting start time by this much.</para>
        /// <para>Changing this requires that TestingTorNetwork is set. (Default: 0)</para>
        /// </summary>
        TestingV3AuthVotingStartOffset,

        /// <summary>
        /// <para>TestingAuthDirTimeToLearnReachability N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>After starting as an authority, do not make claims about whether routers</para>
        /// <para>are Running until this much time has passed. Changing this requires</para>
        /// <para>that TestingTorNetwork is set.  (Default: 30 minutes)</para>
        /// </summary>
        TestingAuthDirTimeToLearnReachability,

        /// <summary>
        /// <para>TestingEstimatedDescriptorPropagationTime N minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>Clients try downloading server descriptors from directory caches after this</para>
        /// <para>time. Changing this requires that TestingTorNetwork is set. (Default:</para>
        /// <para>10 minutes)</para>
        /// </summary>
        TestingEstimatedDescriptorPropagationTime,

        /// <summary>
        /// <para>TestingMinFastFlagThreshold N bytes|KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>Minimum value for the Fast flag.  Overrides the ordinary minimum taken</para>
        /// <para>from the consensus when TestingTorNetwork is set. (Default: 0.)</para>
        /// </summary>
        TestingMinFastFlagThreshold,

        /// <summary>
        /// <para>TestingServerDownloadSchedule N,N,...</para>
        /// <para>&#160;</para>
        /// <para>Schedule for when servers should download things in general. Changing this</para>
        /// <para>requires that TestingTorNetwork is set. (Default: 0, 0, 0, 60, 60, 120,</para>
        /// <para>300, 900, 2147483647)</para>
        /// </summary>
        TestingServerDownloadSchedule,

        /// <summary>
        /// <para>TestingClientDownloadSchedule N,N,...</para>
        /// <para>&#160;</para>
        /// <para>Schedule for when clients should download things in general. Changing this</para>
        /// <para>requires that TestingTorNetwork is set. (Default: 0, 0, 60, 300, 600,</para>
        /// <para>2147483647)</para>
        /// </summary>
        TestingClientDownloadSchedule,

        /// <summary>
        /// <para>TestingServerConsensusDownloadSchedule N,N,...</para>
        /// <para>&#160;</para>
        /// <para>Schedule for when servers should download consensuses. Changing this</para>
        /// <para>requires that TestingTorNetwork is set. (Default: 0, 0, 60, 300, 600,</para>
        /// <para>1800, 1800, 1800, 1800, 1800, 3600, 7200)</para>
        /// </summary>
        TestingServerConsensusDownloadSchedule,

        /// <summary>
        /// <para>TestingClientConsensusDownloadSchedule N,N,...</para>
        /// <para>&#160;</para>
        /// <para>Schedule for when clients should download consensuses. Changing this</para>
        /// <para>requires that TestingTorNetwork is set. (Default: 0, 0, 60, 300, 600,</para>
        /// <para>1800, 3600, 3600, 3600, 10800, 21600, 43200)</para>
        /// </summary>
        TestingClientConsensusDownloadSchedule,

        /// <summary>
        /// <para>TestingBridgeDownloadSchedule N,N,...</para>
        /// <para>&#160;</para>
        /// <para>Schedule for when clients should download bridge descriptors. Changing this</para>
        /// <para>requires that TestingTorNetwork is set. (Default: 3600, 900, 900, 3600)</para>
        /// </summary>
        TestingBridgeDownloadSchedule,

        /// <summary>
        /// <para>TestingClientMaxIntervalWithoutRequest N seconds|minutes</para>
        /// <para>&#160;</para>
        /// <para>When directory clients have only a few descriptors to request, they batch</para>
        /// <para>them until they have more, or until this amount of time has passed.</para>
        /// <para>Changing this requires that TestingTorNetwork is set. (Default: 10</para>
        /// <para>minutes)</para>
        /// </summary>
        TestingClientMaxIntervalWithoutRequest,

        /// <summary>
        /// <para>TestingDirConnectionMaxStall N seconds|minutes</para>
        /// <para>&#160;</para>
        /// <para>Let a directory connection stall this long before expiring it.</para>
        /// <para>Changing this requires that TestingTorNetwork is set. (Default:</para>
        /// <para>5 minutes)</para>
        /// </summary>
        TestingDirConnectionMaxStall,

        /// <summary>
        /// <para>TestingConsensusMaxDownloadTries NUM</para>
        /// <para>&#160;</para>
        /// <para>Try this often to download a consensus before giving up. Changing</para>
        /// <para>this requires that TestingTorNetwork is set. (Default: 8)</para>
        /// </summary>
        TestingConsensusMaxDownloadTries,

        /// <summary>
        /// <para>TestingDescriptorMaxDownloadTries NUM</para>
        /// <para>&#160;</para>
        /// <para>Try this often to download a server descriptor before giving up.</para>
        /// <para>Changing this requires that TestingTorNetwork is set. (Default: 8)</para>
        /// </summary>
        TestingDescriptorMaxDownloadTries,

        /// <summary>
        /// <para>TestingMicrodescMaxDownloadTries NUM</para>
        /// <para>&#160;</para>
        /// <para>Try this often to download a microdesc descriptor before giving up.</para>
        /// <para>Changing this requires that TestingTorNetwork is set. (Default: 8)</para>
        /// </summary>
        TestingMicrodescMaxDownloadTries,

        /// <summary>
        /// <para>TestingCertMaxDownloadTries NUM</para>
        /// <para>&#160;</para>
        /// <para>Try this often to download a v3 authority certificate before giving up.</para>
        /// <para>Changing this requires that TestingTorNetwork is set. (Default: 8)</para>
        /// </summary>
        TestingCertMaxDownloadTries,

        /// <summary>
        /// <para>TestingDirAuthVoteExit node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints, country codes, and</para>
        /// <para>address patterns of nodes to vote Exit for regardless of their</para>
        /// <para>uptime, bandwidth, or exit policy. See the ExcludeNodes</para>
        /// <para>option for more information on how to specify nodes.</para>
        /// <para>&#160;</para>
        /// <para>In order for this option to have any effect, TestingTorNetwork</para>
        /// <para>has to be set. See the ExcludeNodes option for more</para>
        /// <para>information on how to specify nodes.</para>
        /// </summary>
        TestingDirAuthVoteExit,

        /// <summary>
        /// <para>TestingDirAuthVoteGuard node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints and country codes and</para>
        /// <para>address patterns of nodes to vote Guard for regardless of their</para>
        /// <para>uptime and bandwidth. See the ExcludeNodes option for more</para>
        /// <para>information on how to specify nodes.</para>
        /// <para>&#160;</para>
        /// <para>In order for this option to have any effect, TestingTorNetwork</para>
        /// <para>has to be set.</para>
        /// </summary>
        TestingDirAuthVoteGuard,

        /// <summary>
        /// <para>TestingDirAuthVoteHSDir node,node,...</para>
        /// <para>&#160;</para>
        /// <para>A list of identity fingerprints and country codes and</para>
        /// <para>address patterns of nodes to vote HSDir for regardless of their</para>
        /// <para>uptime and ORPort connectivity. See the ExcludeNodes option for more</para>
        /// <para>information on how to specify nodes.</para>
        /// <para>&#160;</para>
        /// <para>In order for this option to have any effect, TestingTorNetwork</para>
        /// <para>and VoteOnHidServDirectoriesV2 both have to be set.</para>
        /// </summary>
        TestingDirAuthVoteHSDir,

        /// <summary>
        /// <para>TestingEnableConnBwEvent 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set, then Tor controllers may register for CONNBW</para>
        /// <para>events.  Changing this requires that TestingTorNetwork is set.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        TestingEnableConnBwEvent,

        /// <summary>
        /// <para>TestingEnableCellStatsEvent 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set, then Tor controllers may register for CELLSTATS</para>
        /// <para>events.  Changing this requires that TestingTorNetwork is set.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        TestingEnableCellStatsEvent,

        /// <summary>
        /// <para>TestingEnableTbEmptyEvent 0|1</para>
        /// <para>&#160;</para>
        /// <para>If this option is set, then Tor controllers may register for TBEMPTY</para>
        /// <para>events.  Changing this requires that TestingTorNetwork is set.</para>
        /// <para>(Default: 0)</para>
        /// </summary>
        TestingEnableTbEmptyEvent,

        /// <summary>
        /// <para>TestingMinExitFlagThreshold  N KBytes|MBytes|GBytes|KBits|MBits|GBits</para>
        /// <para>&#160;</para>
        /// <para>Sets a lower-bound for assigning an exit flag when running as an</para>
        /// <para>authority on a testing network. Overrides the usual default lower bound</para>
        /// <para>of 4 KB. (Default: 0)</para>
        /// </summary>
        TestingMinExitFlagThreshold,

        /// <summary>
        /// <para>TestingLinkCertifetime N seconds|minutes|hours|days|weeks|months</para>
        /// <para>&#160;</para>
        /// <para>Overrides the default lifetime for the certificates used to authenticate</para>
        /// <para>our X509 link cert with our ed25519 signing key.</para>
        /// <para>(Default: 2 days)</para>
        /// </summary>
        TestingLinkCertLifetime,

        /// <summary>
        /// <para>TestingAuthKeyLifetime N seconds|minutes|hours|days|weeks|months</para>
        /// <para>&#160;</para>
        /// <para>Overrides the default lifetime for a signing Ed25519 TLS Link authentication</para>
        /// <para>key.</para>
        /// <para>(Default: 2 days)</para>
        /// </summary>
        TestingAuthKeyLifetime,

        /// <summary>
        /// <para>TestingLinkKeySlop N seconds|minutes|hours</para>
        /// <para>&#160;</para>
        /// </summary>
        TestingLinkKeySlop,

        /// <summary>
        /// <para>TestingAuthKeySlop N seconds|minutes|hours</para>
        /// <para>&#160;</para>
        /// </summary>
        TestingAuthKeySlop,

        /// <summary>
        /// <para>TestingSigningKeySlop N seconds|minutes|hours</para>
        /// <para>&#160;</para>
        /// <para>How early before the official expiration of a an Ed25519 signing key do</para>
        /// <para>we replace it and issue a new key?</para>
        /// <para>(Default: 3 hours for link and auth; 1 day for signing.)</para>
        /// </summary>
        TestingSigningKeySlop
    }
}