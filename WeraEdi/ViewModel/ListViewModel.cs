using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeraEdi.ViewModel
{
	public class ListViewModel<TEntity, TSingleViewModel> : ViewModel
		where TSingleViewModel : SingleViewModel<TEntity>
	{
		public List<TEntity> Items { get; set; }
		public TEntity SelectedItem { get; set; }

		public void LoadItems() { }

		public void CreateItem<TSingleViewModel>()
		{

		}

		public void EditItem<TSingleViewModel>()
		{

		}

		public void DeleteItem()
		{

		}

	}
}
