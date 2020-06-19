using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SkbKontur.EdiApi.Client.Http.Internal;
using WeraEdi.Core.Configuration;
using WeraEdi.Core.Infrastructure;

namespace WeraEdi.Core.Services
{
	public class AppManager
	{
		public EdiManager EdiApi { get; set; }
		public Auth AuthData { get; set; }
		public AppSettings AppSettings { get; set; }

		public static void Init()
		{

		}

		public static AppManager GetDefaultApp(Auth auth, EdiSettings _edi = null, ProxySettings _proxy = null, AppSettings _app = null)
		{
			AppManager app = new AppManager();
			app.AuthData = auth;
			app.EdiApi = EdiManager.GetDefaultApi( _edi, _proxy, _app );
			return app;
		}

	}

	public class Auth
	{
		public bool IsLoggedIn { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}

}
