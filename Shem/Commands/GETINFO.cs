using System;
using Shem.Utils;

namespace Shem.Commands
{
    public class GETINFO : TCCommand
    {
        /// <summary>
        /// Informations availables from GETINFO command.
        /// </summary>
        public enum Informations
        {
            /// <summary>
            /// The version of the server's software, including the name of the software. (example: "Tor 0.0.9.4")
            /// </summary>
            [StringValue("version")]
            version,

            /// <summary>
            /// The location of Tor's configuration file ("torrc")
            /// </summary>
            [StringValue("config-file")]
            config_file,

            /// <summary>
            /// The location of Tor's configuration defaults file ("torrc.defaults").  This file gets parsed before torrc, and is typically used to replace Tor's default configuration values. [First implemented in 0.2.3.9-alpha.]
            /// </summary>
            [StringValue("config-defaults-file")]
            config_defaults_file,

            /// <summary>
            /// The contents that Tor would write if you send it a SAVECONF command, so the controller can write the file to disk itself. [First implemented in 0.2.2.7-alpha.]
            /// </summary>
            [StringValue("config-text")]
            config_text,

            /// <summary>
            ///  The default exit policy lines that Tor will *append* to the ExitPolicy config option.
            /// </summary>
            [StringValue("exit-policy/default")]
            exit_policy_default,

            /// <summary>
            /// The ipv4 exit policy lines that Tor will *append* to the ExitPolicy config option.
            /// </summary>
            [StringValue("exit-policy/ipv4")]
            exit_policy_ipv4,

            /// <summary>
            /// The ipv6 exit policy lines that Tor will *append* to the ExitPolicy config option.
            /// </summary>
            [StringValue("exit-policy/ipv6")]
            exit_policy_ipv6,

            /// <summary>
            /// This OR's exit policy, in IPv4-only, IPv6-only, or all-entries flavors.
            /// </summary>
            [StringValue("exit-policy/full")]
            exit_policy_full,

            /// <summary>
            /// A nonnegative integer: zero if Tor is currently active and building circuits, and non zero if Tor has gone idle due to lack of useor some similar reason.  [First implemented in 0.2.3.16-alpha]
            /// </summary>
            [StringValue("dormant")]
            dormant,

            /// <summary>
            /// Router status info (v3 directory style) for all ORs we have an opinion about, joined by newlines. [First implemented in 0.1.2.3-alpha.] [In 0.2.0.9-alpha this switched from v2 directory style to v3]
            /// </summary>
            [StringValue("ns/all")]
            ns_all,

            /// <summary>
            /// The latest server descriptor for every router that Tor knows about.  (See md note about "desc/id" and "desc/name" above.)
            /// </summary>
            [StringValue("desc/all-recent")]
            desc_all_recent,

            /// <summary>
            /// A space-separated list (v1 directory style) of all known OR identities. This is in the same format as the router-status line in v1 directories; see dir-spec-v1.txt section 3 for details.  (If VERBOSE_NAMES is enabled, the output will not conform to dir-spec-v1.txt; instead, the result will be a space-separated list of LongName, each preceded by a "!" if it is believed to be not running.) This option is deprecated; use "ns/all" instead.
            /// </summary>
            [StringValue("network-status")]
            network_status,

            /// <summary>
            /// A \r\n-separated list of address mappings, each in the form of "from-address to-address expiry". Returns the mappings set through any mechanism. Expiry is formatted as with ADDRMAP events, except that "expiry" is always a time in UTC or the string "NEVER". First introduced in 0.2.0.3-alpha.
            /// </summary>
            [StringValue("address-mappings/all")]
            address_mappings_all,

            /// <summary>
            /// A \r\n-separated list of address mappings, each in the form of "from-address to-address expiry". Returns those address mappings set in the configuration. Expiry is formatted as with ADDRMAP events, except that "expiry" is always a time in UTC or the string "NEVER". First introduced in 0.2.0.3-alpha.
            /// </summary>
            [StringValue("address-mappings/config")]
            address_mappings_config,

            /// <summary>
            /// A \r\n-separated list of address mappings, each in the form of "from-address to-address expiry". Returns the mappings in the client-side DNS cache. Expiry is formatted as with ADDRMAP events, except that "expiry" is always a time in UTC or the string "NEVER". First introduced in 0.2.0.3-alpha.
            /// </summary>
            [StringValue("address-mappings/cache")]
            address_mappings_cache,

            /// <summary>
            /// A \r\n-separated list of address mappings, each in the form of "from-address to-address expiry". Returns the mappings set via the control interface. Expiry is formatted as with ADDRMAP events, except that "expiry" is always a time in UTC or the string "NEVER". First introduced in 0.2.0.3-alpha.
            /// </summary>
            [StringValue("address-mappings/control")]
            address_mappings_control,

            /// <summary>
            /// The best guess at our external IP address. If we have no guess, return a 551 error. (Added in 0.1.2.2-alpha)
            /// </summary>
            [StringValue("address")]
            address,

            /// <summary>
            /// The contents of the fingerprint file that Tor writes as a relay, or a 551 if we're not a relay currently. (Added in 0.1.2.3-alpha)
            /// </summary>
            [StringValue("fingerprint")]
            fingerprint,

            /// <summary>
            /// A series of lines as for a circuit status event. Each line is of the form described in section 4.1.1, omitting the initial "650 CIRC ".  Note that clients must be ready to accept additional arguments as described in section 4.1.
            /// </summary>
            [StringValue("circuit-status")]
            circuit_status,

            /// <summary>
            /// A series of lines as for a stream status event.  Each is of the form: StreamID SP StreamStatus SP CircuitID SP Target CRLF
            /// </summary>
            [StringValue("stream-status")]
            stream_status,

            /// <summary>
            /// A series of lines as for an OR connection status event.  In Tor 0.1.2.2-alpha with feature VERBOSE_NAMES enabled and in Tor 0.2.2.1-alpha and later by default, each line is of the form: LongName SP ORStatus CRLF
            /// </summary>
            [StringValue("orconn-status")]
            orconn_status,

            /// <summary>
            /// A series of lines listing the currently chosen entry guards, if any. In Tor 0.1.2.2-alpha with feature VERBOSE_NAMES enabled and in Tor 0.2.2.1-alpha and later by default, each line is of the form: LongName SP Status [SP ISOTime] CRLF
            /// </summary>
            [StringValue("entry-guards")]
            entry_guards,

            /// <summary>
            /// Total bytes read (downloaded).
            /// </summary>
            [StringValue("traffic/read")]
            traffic_read,

            /// <summary>
            /// Total bytes written (uploaded).
            /// </summary>
            [StringValue("traffic/written")]
            traffic_written,

            /// <summary>
            /// Information about accounting status. If accounting is enabled, "enabled" is 1; otherwise it is 0.
            /// </summary>
            [StringValue("accounting/enabled")]
            accounting_enabled,

            /// <summary>
            /// Information about accounting status, "hibernating" field is "hard" if we are accepting no data; "soft" if we're accepting no new connections, and "awake" if we're not hibernating at all.
            /// </summary>
            [StringValue("accounting/hibernating")]
            accounting_hibernating,

            /// <summary>
            /// Information about accounting status, "bytes" and "bytes-left" fields contain (read-bytes SP write-bytes), for the start and the rest of the interval respectively.
            /// </summary>
            [StringValue("accounting/bytes")]
            accounting_bytes,

            /// <summary>
            /// Information about accounting status, "bytes" and "bytes-left" fields contain (read-bytes SP write-bytes), for the start and the rest of the interval respectively.
            /// </summary>
            [StringValue("accounting/bytes-left")]
            accounting_bytes_left,

            /// <summary>
            /// Information about accounting status, 'interval-start' and 'interval-end' fields are the borders of the current interval. The times are UTC.
            /// </summary>
            [StringValue("accounting/interval-start")]
            accounting_interval_start,

            /// <summary>
            /// Information about accounting status, 'interval-wake' field is the time within the current interval (if any) where we plan[ned] to start being active. The times are UTC.
            /// </summary>
            [StringValue("accounting/interval-wake")]
            accounting_interval_wake,

            /// <summary>
            /// Information about accounting status, 'interval-start' and 'interval-end' fields are the borders of the current interval. The times are UTC.
            /// </summary>
            [StringValue("accounting/interval-end")]
            accounting_interval_end,

            /// <summary>
            /// A series of lines listing the available configuration options.
            /// </summary>
            [StringValue("config/names")]
            config_names,

            /// <summary>
            /// A series of lines listing default values for each configuration option. Options which don't have a valid default don't show up in the list.  Introduced in Tor 0.2.4.1-alpha.
            /// </summary>
            [StringValue("config/defaults")]
            config_defaults,

            /// <summary>
            /// A series of lines listing the available GETINFO options.
            /// </summary>
            [StringValue("info/names")]
            info_names,

            /// <summary>
            /// A space-separated list of all the events supported by this version of Tor's SETEVENTS.
            /// </summary>
            [StringValue("events/names")]
            events_names,

            /// <summary>
            /// A space-separated list of all the features supported by this version of Tor's USEFEATURE.
            /// </summary>
            [StringValue("features/names")]
            features_names,

            /// <summary>
            /// A space-separated list of all the values supported by the SIGNAL command.
            /// </summary>
            [StringValue("signal/names")]
            signal_names,

            /// <summary>
            /// Process id belonging to the main tor process.
            /// </summary>
            [StringValue("process/pid")]
            process_pid,

            /// <summary>
            /// User id running the tor process, -1 if unknown (this is  unimplemented on Windows, returning -1).
            /// </summary>
            [StringValue("process/uid")]
            process_uid,

            /// <summary>
            /// Username under which the tor process is running, providing an empty string if none exists (this is unimplemented on Windows, returning an empty string).
            /// </summary>
            [StringValue("process/user")]
            process_user,

            /// <summary>
            /// Upper bound on the file descriptor limit, -1 if unknown.
            /// </summary>
            [StringValue("process/descriptor-limit")]
            process_descriptor_limit,

            /// <summary>
            /// A series of lines listing directory contents, provided according to the specification for the URLs listed in Section 4.4 of dir-spec.txt.
            /// </summary>
            [StringValue("dir/status-vote/current/consensus")]
            dir_status_vote_current_consensus,

            /// <summary>
            /// A series of lines listing directory contents, provided according to the specification for the URLs listed in Section 4.4 of dir-spec.txt.
            /// </summary>
            [StringValue("dir/status/authority")]
            dir_status_authority,

            /// <summary>
            /// A series of lines listing directory contents, provided according to the specification for the URLs listed in Section 4.4 of dir-spec.txt.
            /// </summary>
            [StringValue("dir/status/all")]
            dir_status_all,

            /// <summary>
            /// A series of lines listing directory contents, provided according to the specification for the URLs listed in Section 4.4 of dir-spec.txt.
            /// </summary>
            [StringValue("dir/server/authority")]
            dir_server_authority,

            /// <summary>
            /// A series of lines listing directory contents, provided according to the specification for the URLs listed in Section 4.4 of dir-spec.txt.
            /// </summary>
            [StringValue("dir/server/all")]
            dir_server_all,

            /// <summary>
            /// These provide the current internal Tor values for various Tor states. See Section 4.1.10 for explanations. (Only a few of the status events are available as getinfo's currently. Let us know if you want more exposed.)
            /// </summary>
            [StringValue("status/circuit-established")]
            status_circuit_established,

            /// <summary>
            /// These provide the current internal Tor values for various Tor states. See Section 4.1.10 for explanations. (Only a few of the status events are available as getinfo's currently. Let us know if you want more exposed.)
            /// </summary>
            [StringValue("status/enough-dir-info")]
            status_enough_dir_info,

            /// <summary>
            /// These provide the current internal Tor values for various Tor states. See Section 4.1.10 for explanations. (Only a few of the status events are available as getinfo's currently. Let us know if you want more exposed.)
            /// </summary>
            [StringValue("status/good-server-descriptor")]
            status_good_server_descriptor,

            /// <summary>
            /// These provide the current internal Tor values for various Tor states. See Section 4.1.10 for explanations. (Only a few of the status events are available as getinfo's currently. Let us know if you want more exposed.)
            /// </summary>
            [StringValue("status/accepted-server-descriptor")]
            status_accepted_server_descriptor,

            /// <summary>
            /// Returns 0 or 1, depending on whether we've found our ORPort reachable.
            /// </summary>
            [StringValue("status/reachability-succeeded/or")]
            status_reachability_succeeded_or,

            /// <summary>
            /// Returns 0 or 1, depending on whether we've found our DirPort reachable.
            /// </summary>
            [StringValue("status/reachability-succeeded/dir")]
            status_reachability_succeeded_dir,

            /// <summary>
            /// Returns the most recent bootstrap phase status event sent. Specifically, it returns a string starting with either "NOTICE BOOTSTRAP ..." or "WARN BOOTSTRAP ...". Controllers should use this getinfo when they connect or attach to Tor to learn its current bootstrap state.
            /// </summary>
            [StringValue("status/bootstrap-phase")]
            status_bootstrap_phase,

            /// <summary>
            /// List of currently recommended versions.
            /// </summary>
            [StringValue("status/version/recommended")]
            status_version_recommended,

            /// <summary>
            /// Status of the current version. One of: new, old, unrecommended, recommended, new in series, obsolete, unknown.
            /// </summary>
            [StringValue("status/version/current")]
            status_version_current,

            /// <summary>
            /// A summary of which countries we've seen clients from recently, formatted the same as the CLIENTS_SEEN status event described in Section 4.1.14. This GETINFO option is currently available only for bridge relays.
            /// </summary>
            [StringValue("status/clients-seen")]
            status_clients_seen,

            /// <summary>
            /// A quoted, space-separated list of the locations where Tor is listening for connections of the specified type. These can contain IPv4 network address.
            /// </summary>
            [StringValue("net/listeners/or")]
            net_listeners_or,

            /// <summary>
            /// A quoted, space-separated list of the locations where Tor is listening for connections of the specified type. These can contain IPv4 network address.
            /// </summary>
            [StringValue("net/listeners/dir")]
            net_listeners_dir,

            /// <summary>
            /// A quoted, space-separated list of the locations where Tor is listening for connections of the specified type. These can contain IPv4 network address.
            /// </summary>
            [StringValue("net/listeners/socks")]
            net_listeners_socks,

            /// <summary>
            /// A quoted, space-separated list of the locations where Tor is listening for connections of the specified type. These can contain IPv4 network address.
            /// </summary>
            [StringValue("net/listeners/trans")]
            net_listeners_trans,

            /// <summary>
            /// A quoted, space-separated list of the locations where Tor is listening for connections of the specified type. These can contain IPv4 network address.
            /// </summary>
            [StringValue("net/listeners/natd")]
            net_listeners_natd,

            /// <summary>
            /// A quoted, space-separated list of the locations where Tor is listening for connections of the specified type. These can contain IPv4 network address.
            /// </summary>
            [StringValue("net/listeners/dns")]
            net_listeners_dns,

            /// <summary>
            /// A quoted, space-separated list of the locations where Tor is listening for connections of the specified type. These can contain IPv4 network address.
            /// </summary>
            [StringValue("net/listeners/control")]
            net_listeners_control,

            /// <summary>
            /// A newline-separated list of how many bytes we've served to answer each type of directory request. The format of each line is: Keyword 1*SP Integer 1*SP Integer where the first integer is the number of bytes written, and the second is the number of requests answered.
            /// </summary>
            [StringValue("dir-usage")]
            dir_usage,

            /// <summary>
            ///  A space-separated summary of recent BW events in chronological order from oldest to newest.  Each event is represented by a comma-separated tuple of "R,W", R is the number of bytes read, and W is the number of bytes written.  These entries each represent about one second's worth of traffic.
            /// </summary>
            [StringValue("bw-event-cache")]
            bw_event_cache,

            /// <summary>
            /// Produces an ISOTime describing part of the lifetime of the current (valid, accepted) consensus that Tor has.
            /// </summary>
            [StringValue("consensus/valid-after")]
            consensus_valid_after,

            /// <summary>
            /// Produces an ISOTime describing part of the lifetime of the current (valid, accepted) consensus that Tor has.
            /// </summary>
            [StringValue("consensus/fresh-until")]
            consensus_fresh_until,

            /// <summary>
            /// Produces an ISOTime describing part of the lifetime of the current (valid, accepted) consensus that Tor has.
            /// </summary>
            [StringValue("consensus/valid-until")]
            consensus_valid_until,

            /// <summary>
            /// A newline-separated list of the Onion ("Hidden") Services created via the "ADD_ONION" command. Returns Onion Services belonging to the current control connection.
            /// </summary>
            [StringValue("onions/current")]
            onions_current,

            /// <summary>
            /// A newline-separated list of the Onion ("Hidden") Services created via the "ADD_ONION" command. Returns Onion Services detached from the parent control connection (as in, belonging to no control connection).
            /// </summary>
            [StringValue("onions/detached")]
            onions_detached,

            /// <summary>
            /// The string "up" or "down", indicating whether we currently believe the network is reachable.
            /// </summary>
            [StringValue("network-liveness")]
            network_liveness
        }

        private string info = "";

        /// <summary>
        /// Returns requested informations about tor instance.
        /// </summary>
        /// <param name="informations"></param>
        public GETINFO(params Informations[] informations)
        {
            this.info = (new Func<string>(() =>
            {
                string ks = "";
                foreach (var k in informations)
                {
                    ks += " " + k.GetStringValue();
                }
                return ks;
            }))();
        }

        /// <summary>
        /// Returns requested informations about tor instance.
        /// </summary>
        /// <param name="informations"></param>
        public GETINFO(string informations)
        {
            this.info = informations;
        }

        public override string Raw()
        {
            return string.Format("GETINFO{0}\r\n", info);
        }
    }
}