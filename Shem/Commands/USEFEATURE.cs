
namespace Shem.Commands
{
    /// <summary>
    /// Adding additional features to the control protocol sometimes will break backwards compatibility. Initially such features are added into Tor and disabled by default. USEFEATURE can enable these additional features. Once enabled, a feature stays enabled for the duration of the connection to the controller. A new connection to the controller must be opened to disable an enabled feature.
    /// </summary>
    public class UseFeature : TCCommand
    {
        private string featureName;

        /// <summary>
        /// Adding additional features to the control protocol sometimes will break backwards compatibility. Initially such features are added into Tor and disabled by default. USEFEATURE can enable these additional features. Once enabled, a feature stays enabled for the duration of the connection to the controller. A new connection to the controller must be opened to disable an enabled feature.
        /// </summary>
        /// <param name="featureName"></param>
        public UseFeature(string featureName)
        {
            this.featureName = featureName;
        }

        public override string Raw()
        {
            return string.Format("USEFEATURE {0}\r\n", featureName);
        }
    }
}