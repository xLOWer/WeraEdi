using WeraEdi.Core.Configuration.Interfaces;

namespace WeraEdi.Core.Configuration
{
	public class AppSettings : Settings
	{
		public bool EnableProxy { get; set; }
		public bool EnableAutoLoad { get; set; }


		public static new AppSettings Default => new AppSettings
		{
			EnableProxy	 = false,
			EnableAutoLoad = false,
		};

		public static new string Directory => "config/";
		public static new string FileName => "app_conf.json";
		public static new string Path => Directory + FileName;
	}
}
