using System.Collections.Generic;
namespace Shem.Commons
{
    public class Circuit
    {
        /*
         * The syntax is:

         "650" SP "CIRC" SP CircuitID SP CircStatus [SP Path]
              [SP "BUILD_FLAGS=" BuildFlags] [SP "PURPOSE=" Purpose]
              [SP "HS_STATE=" HSState] [SP "REND_QUERY=" HSAddress]
              [SP "TIME_CREATED=" TimeCreated]
              [SP "REASON=" Reason [SP "REMOTE_REASON=" Reason]]
              [SP "SOCKS_USERNAME=" EscapedUsername]
              [SP "SOCKS_PASSWORD=" EscapedPassword]
              CRLF

          CircStatus =
                   "LAUNCHED" / ; circuit ID assigned to new circuit
                   "BUILT"    / ; all hops finished, can now accept streams
                   "EXTENDED" / ; one more hop has been completed
                   "FAILED"   / ; circuit closed (was not built)
                   "CLOSED"     ; circuit closed (was built)

          Path = LongName *("," LongName)
            ; In Tor versions 0.1.2.2-alpha through 0.2.2.1-alpha with feature
            ; VERBOSE_NAMES turned off and before version 0.1.2.2-alpha, Path
            ; is as follows:
            ; Path = ServerID *("," ServerID)

          BuildFlags = BuildFlag *("," BuildFlag)
          BuildFlag = "ONEHOP_TUNNEL" / "IS_INTERNAL" /
                      "NEED_CAPACITY" / "NEED_UPTIME"

          Purpose = "GENERAL" / "HS_CLIENT_INTRO" / "HS_CLIENT_REND" /
                    "HS_SERVICE_INTRO" / "HS_SERVICE_REND" / "TESTING" /
                    "CONTROLLER" / "MEASURE_TIMEOUT"

          HSState = "HSCI_CONNECTING" / "HSCI_INTRO_SENT" / "HSCI_DONE" /
                    "HSCR_CONNECTING" / "HSCR_ESTABLISHED_IDLE" /
                    "HSCR_ESTABLISHED_WAITING" / "HSCR_JOINED" /
                    "HSSI_CONNECTING" / "HSSI_ESTABLISHED" /
                    "HSSR_CONNECTING" / "HSSR_JOINED"

          EscapedUsername = QuotedString
          EscapedPassword = QuotedString

          HSAddress = 16*Base32Character
          Base32Character = ALPHA / "2" / "3" / "4" / "5" / "6" / "7"

          TimeCreated = ISOTime2Frac
          Seconds = 1*DIGIT
          Microseconds = 1*DIGIT

          Reason = "NONE" / "TORPROTOCOL" / "INTERNAL" / "REQUESTED" /
                   "HIBERNATING" / "RESOURCELIMIT" / "CONNECTFAILED" /
                   "OR_IDENTITY" / "OR_CONN_CLOSED" / "TIMEOUT" /
                   "FINISHED" / "DESTROYED" / "NOPATH" / "NOSUCHSERVICE" /
                   "MEASUREMENT_EXPIRED"
         */

        public int ID { get; private set; }
        public CircuitStatus Status { get; private set; }
        public List<OnionRelay> Path { get; private set; }
        public CircuitBuildFlags BuildFlags { get; private set; }
        public CircuitPurpose Purpose { get; private set; }
    }
}
