using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeraEdi.ViewModel
{
	public class Order { }

	public class OrderListViewModel : ListViewModel<Order, OrderViewModel<Order>>
	{
	}
}
