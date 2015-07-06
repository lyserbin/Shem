namespace Shem.Replies
{
    /*
     * The TC protocol currently uses the following first characters:
     *  2yz Positive Completion Reply
     *          The command was successful; a new request can be started.
     *  4yz Temporary Negative Completion reply
     *          The command was unsuccessful but might be reattempted later.
     *  5yz Permanent Negative Completion Reply
     *          The command was unsuccessful; the client should not try exactly
     *          that sequence of commands again.
     *  6yz Asynchronous Reply
     *          Sent out-of-order in response to an earlier SETEVENTS command.
     *
     * The following second characters are used:
     *  x0z Syntax
     *          Sent in response to ill-formed or nonsensical commands.
     *  x1z Protocol
     *          Refers to operations of the Tor Control protocol.
     *  x5z Tor
     *          Refers to actual operations of Tor system.
     */

    public enum ReplyCodes
    {
        /// <summary>
        /// The command sent went through good.
        /// </summary>
        OK = 250,
        
        /// <summary>
        /// The command sent was unnecessary, nothing went wrong anyway.
        /// </summary>
        UNNECESSARY = 251,

        /// <summary>
        /// The resources are exhausted (idk what it means..)
        /// </summary>
        EXHAUSTED = 451,

        /// <summary>
        /// The syntax protocol is faulty (this should never happen)
        /// </summary>
        SYNTAX_ERROR = 500,

        /// <summary>
        /// The sent command is unrecognized by TOR
        /// </summary>
        UNRECOGNIZED_COMMAND = 510,

        /// <summary>
        /// This command is still not avaiable in the TC protocol
        /// </summary>
        UNIMPLEMENTED_COMMAND = 511,

        /// <summary>
        /// Syntax error in command argument
        /// </summary>
        SYNTAX_ERROR_ARGUMENT = 512,

        /// <summary>
        /// Unrecognized command argument
        /// </summary>
        UNRECOGNIZED_ARGUMENT = 513,

        /// <summary>
        /// You have to authenticate (using an AUTHENTICATE command) before doing the given command
        /// </summary>
        AUTHENTICATION_REQUIRED = 514,

        /// <summary>
        /// Wrong credentials, the socket is now closed
        /// </summary>
        BAD_AUTHENTICATION = 515,

        /// <summary>
        /// Something went wrong :<
        /// </summary>
        UNSPECIFIED_TOR_ERROR = 550,

        /// <summary>
        /// Something went wrong inside Tor, so that the client's request couldn't be fulfilled
        /// </summary>
        INTERNAL_ERROR = 551,

        /// <summary>
        /// A  configuration key, a stream ID, circuit ID, event, mentioned in the command did not actually exist
        /// </summary>
        UNRECOGNIZED_ENTITY = 552,

        /// <summary>
        /// The client tried to set a configuration option to an incorrect, ill-formed, or impossible value
        /// </summary>
        INVALID_CONFIGURATION_VALUE = 553,

        /// <summary>
        /// TODO: document this
        /// </summary>
        INVALID_DESCRIPTOR = 554,

        /// <summary>
        /// TODO: document this
        /// </summary>
        UNMANAGED_ENTITY = 555,

        /// <summary>
        /// An async event pulled out
        /// </summary>
        ASYNC_EVENT_NOTIFICATION = 650
    }
}
