using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeraEdi.ViewModel
{
	public class ViewModel : IViewModel
	{
		public ViewModel()
		{

		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string info)
		{
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( info ) );
		}
	}
}
