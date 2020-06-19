using WeraEdi.Core.Configuration.Interfaces;

namespace WeraEdi.Core.Configuration
{
	public class ProxySettings : Settings
	{
		public string ProxyAddress { get; set; }
		public string ProxyUserName { get; set; }
		public string ProxyUserPassword { get; set; }
		public string ProxyPort { get; set; }

		public static new ProxySettings Default => new ProxySettings {
			ProxyAddress = "192.168.2.29",
			ProxyPort = "3128",
			ProxyUserName ="",
			ProxyUserPassword ="",
		};
		public static new string Directory => "config/";
		public static new string FileName => "proxy_conf.json";
		public static new string Path => Directory + FileName;
	}
}
