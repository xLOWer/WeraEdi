using System;
using WeraEdi.Core.Configuration.Interfaces;

namespace WeraEdi.Core.Infrastructure
{
	public class TokenCache : Settings
	{
		public TokenCache(string AuthToken, string Creator)
		{
			Token = AuthToken;
			TokenCreator = Creator;
			TokenCreationDate = DateTime.Now;
			TokenExpirationDate = DateTime.Now.AddHours( 12 );
		}

		public static new TokenCache Default(string AuthToken, string Creator) => new TokenCache(AuthToken, Creator) 
		{
			Token = AuthToken,
			TokenCreator = Creator,
			TokenCreationDate = DateTime.Now,
			TokenExpirationDate = DateTime.Now.AddHours( 12 ),
		};

		public string Token { get; set; }
		public string TokenCreator { get; set; }
		public DateTime TokenCreationDate { get; set; }
		public DateTime TokenExpirationDate { get; set; }


		public static new string Directory => "config/";
		public static new string FileName => "edi_cache";
		public static new string Path => Directory + FileName;
	}
}
