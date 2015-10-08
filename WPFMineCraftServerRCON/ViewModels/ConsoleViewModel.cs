using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WPFMineCraftServerRCON.ViewModels
{
	internal class ConsoleViewModel : ViewModelBase
	{
		public static readonly ConsoleViewModel INSTANCE = new ConsoleViewModel();
		private ConsoleViewModel()
		{
			McCommand = string.Empty;
			McResponse = string.Empty;
			ConsoleMonitor = new ObservableCollection<string>();
			UsedCommands = new ObservableCollection<string>();
		}
		public string McCommand { get; set; }
		public string McResponse { get; set; }
		public ObservableCollection<string> ConsoleMonitor { get; set; }
		public ObservableCollection<string> UsedCommands { get; set; }
	}
}
