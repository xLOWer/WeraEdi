using SkbKontur.EdiApi.Client.Http.Internal;
using System;
using System.IO;
using System.Net;
using WeraEdi.Core.Configuration;
using WeraEdi.Core.Infrastructure;

namespace WeraEdi.Core.Services
{
	public class EdiManager
	{
		private TokenCache Token { get; set; }
		private IWebProxy WebProxy { get; set; }
		private InternalEdiApiHttpClient EdiApiClient { get; set; }

		private EdiSettings EdiConf { get; set; }
		private ProxySettings ProxyConf { get; set; }

		private ConfigManager ConfigMgr { get; set; }


		public static EdiManager GetDefaultApi(EdiSettings _edi = null, ProxySettings _proxy = null, AppSettings _app = null)
		{
			EdiManager edi = new EdiManager();
			edi.ConfigMgr = new  ConfigManager();
			edi.EdiConf = new EdiSettings();
			edi.ProxyConf = new ProxySettings();

			// если зкинули какойто тонфиг, то его и сохраним
			if (_edi != null)
				edi.ConfigMgr.SaveSettings( _edi, EdiSettings.Path );
			if (_proxy != null)
				edi.ConfigMgr.SaveSettings( _proxy, ProxySettings.Path );

			// загружаем конфиг
			EdiSettings conf = edi.ConfigMgr.LoadSettings<EdiSettings>( EdiSettings.Path );
			ProxySettings proxy = edi.ConfigMgr.LoadSettings<ProxySettings>( ProxySettings.Path );

			// если что-то пошло не так и конфига всёравно не видно, то сохраним базовый шаблон конфига
			if (conf == null)
				edi.ConfigMgr.SaveSettings( EdiSettings.Default, EdiSettings.Path );
			if (proxy == null)
				edi.ConfigMgr.SaveSettings( ProxySettings.Default, ProxySettings.Path );

			// установим конфиг в создаваемый домен
			edi.EdiConf = conf;
			edi.ProxyConf = proxy;

			edi.WebProxy = null;

			// если edi хочет ходить через прокси - пусть будет так
			if (_app.EnableProxy)
			{
				edi.WebProxy = new WebProxy( proxy.ProxyAddress, _app.EnableProxy );
				edi.WebProxy.Credentials = new NetworkCredential(
					proxy.ProxyUserName,
					proxy.ProxyUserPassword
				);
			}

			edi.EdiApiClient = new InternalEdiApiHttpClient(
				conf.EdiApiClientId,
				new Uri( conf.EdiApiUrl ),
				conf.EdiApiTimeout,
				edi.WebProxy
			);

			return edi;
		}


		/// <summary>
		/// Получить токен аутентификации
		/// </summary>
		public bool Authenticate(string user, string password)
		{
			if (File.Exists( TokenCache.Path ))
				Token = this.ConfigMgr.LoadSettings<TokenCache>( TokenCache.Path );

			if (Token == null)
			{
				if (!IsTokenExpired)
					return true;

				var authToken = EdiApiClient.Authenticate( user, password );

				if (string.IsNullOrEmpty( authToken ))
					return false;

				Token = new TokenCache( authToken, user );
				this.ConfigMgr.SaveSettings( Token, TokenCache.Path );
				return true;
			}
			return false;
		}


		/// <summary>
		/// Истёк ли токен аутентификации
		/// </summary>
		public bool IsTokenExpired => Token.TokenExpirationDate < DateTime.Now;


	}
}
