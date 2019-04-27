using log4net;
using log4net.Config;

namespace RAP.Domain.Util
{
    public class LoggerManager
    {
        private static ILog log = LogManager.GetLogger("LOGGER");


        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}