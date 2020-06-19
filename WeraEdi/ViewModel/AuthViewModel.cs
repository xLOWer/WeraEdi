using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeraEdi.ViewModel
{
	public class AuthViewModel : ViewModel
	{
		public AuthViewModel()
		{
			IsLoggedIn = false;
		}

		/// <summary>
		/// Аутентификация
		/// </summary>
		/// <param name="user">Логин пользователя. Может быть пустой, тогда используется данные из GUI</param>
		/// <param name="password">Пароль пользователя. Может быть пустой, тогда используется данные из GUI</param>
		public void SignIn(string user = null, string password = null)
		{
			if (user == null)
				user = this.UserName;
			if (password == null)
				password = this.Password;

			//if (Domain.Authenticate( user, password ))
			{
				AuthSuccess( user, password );
				IsLoggedIn = true;
				return;
			}

			AuthFailed( user, password );
		}

		private string _UserName;
		public string UserName
		{
			get => _UserName;
			set 
			{
				UserName = _UserName;
				NotifyPropertyChanged( nameof( UserName ) );
			}
		}

		private string _Password;
		public string Password
		{
			get => _Password;
			set {
				Password = _Password;
				NotifyPropertyChanged( nameof( Password ) );
			}
		}

		private bool _IsLoggedIn;
		/// <summary>
		/// Флаг, показывающий прошла ли аутентификация успешно
		/// </summary>
		public bool IsLoggedIn
		{
			get => _IsLoggedIn;
			set {
				IsLoggedIn = _IsLoggedIn;
				NotifyPropertyChanged( nameof( IsLoggedIn ) );
			}
		}


		public event Action<string, string> AuthSuccess = delegate { };
		public event Action<string, string> AuthFailed = delegate { };

	}
}
