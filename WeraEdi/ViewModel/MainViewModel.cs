using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeraEdi.Core.Services;

namespace WeraEdi.ViewModel
{
	public class MainViewModel : ViewModel
	{

		public AppManager Manager { get; set; }

		public MainViewModel()
		{
			Manager = AppManager.GetDefaultApp(new Auth()
			{
				IsLoggedIn = false,
				UserName = "",
				Password = "",
			} );
		}

	}
}
