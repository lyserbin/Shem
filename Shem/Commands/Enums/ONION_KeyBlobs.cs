
namespace Shem.Commands.Enums
{
    public enum ONION_KeyBlobs
    {
        /// <summary>
        /// The server should generate a key using the "best" supported algorithm (KeyType == "NEW")
        /// </summary>
        BEST,

        /// <summary>
        /// The server should generate a 1024 bit RSA key (KeyType == "NEW")
        /// </summary>
        RSA1024,

        /// <summary>
        /// A serialized private key (without whitespace) (KeyType == "RSA1024")
        /// </summary>
        String
    }
}