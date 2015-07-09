
namespace Shem.Commands
{
    public enum OnionFlags
    {
        /// <summary>
        /// The server should not include the newly generated private key as part of the response.
        /// </summary>
        DiscardPK,

        /// <summary>
        /// Do not associate the newly created Onion Service to the current control connection.
        /// </summary>
        Detach
    }
}