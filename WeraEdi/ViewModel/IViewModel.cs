using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeraEdi.ViewModel
{
	public interface IViewModel : IDisposable, INotifyPropertyChanged
	{
		void NotifyPropertyChanged(string info);
	}
}
