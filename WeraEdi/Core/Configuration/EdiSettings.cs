using WeraEdi.Core.Configuration.Interfaces;

namespace WeraEdi.Core.Configuration
{
	public class EdiSettings : Settings
	{
		public string EdiApiUrl { get; set; }
		public int EdiApiTimeout { get; set; }
		public string EdiApiClientId { get; set; } 
	

		public static new EdiSettings Default => new EdiSettings 
		{
			EdiApiUrl = "https://test-edi-api.kontur.ru/",
			EdiApiTimeout=5000,
			EdiApiClientId ="",
		};
		public static new string Directory => "config/";
		public static new string FileName => "edi_conf.json";
		public static new string Path => Directory + FileName;
	}
}
