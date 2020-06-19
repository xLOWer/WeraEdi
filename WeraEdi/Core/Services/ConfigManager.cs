using Newtonsoft.Json;
using System.IO;
using WeraEdi.Core.Configuration.Interfaces;

namespace WeraEdi.Core.Services
{
	public class ConfigManager
	{

		public T LoadSettings<T>(string Path)
			where T : Settings
		{
			if (File.Exists( Path ))
			{
				using (var dataStream = File.OpenRead( Path ))
				{
					using (var reader = new StreamReader( dataStream ))
					{
						string fileContent = reader.ReadToEnd();
						var cfg = JsonConvert.DeserializeObject<T>( fileContent );
						return cfg;
					}
				}
			}
			return default( T );
		}


		public void SaveSettings<T>(T Settings, string Path = null)
		where T : Settings
		{
			using (var dataStream = File.OpenWrite( Path ))
			{
				using (var writer = new StreamWriter( dataStream ))
				{
					string obj = JsonConvert.SerializeObject( Settings, Formatting.Indented );
					writer.Write( obj );
				}
			}
		}


	}
}
