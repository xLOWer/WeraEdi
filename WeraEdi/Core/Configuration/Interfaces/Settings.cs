namespace WeraEdi.Core.Configuration.Interfaces
{
	public class Settings : ISettings
	{
		public static ISettings Default { get; set; }

		public static string Directory { get; }
		public static string FileName { get; }
		public static string Path { get; }

		static Settings()
		{
			if (!System.IO.Directory.Exists( Path ))
				System.IO.Directory.CreateDirectory( Path );
		}

	}
}
