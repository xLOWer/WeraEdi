using WeraEdi.Core.Configuration.Interfaces;

namespace WeraEdi.Core.Configuration
{
	public class DbSettings : Settings
	{
		public static new DbSettings Default => new DbSettings { };
		public static new string Directory => "config/";
		public static new string FileName => "db_conf.json";
		public static new string Path => Directory + FileName;
	}
}
