using System;
using System.Windows;
using WPFMineCraftServerRCON.ViewModels;
using MinecraftServerRCON;

namespace WPFMineCraftServerRCON.Views
{
	public partial class ConsoleWindow : Window
	{
		private RCONClient _rconClient;
		private ConsoleViewModel _vmConsole;

		public ConsoleWindow(RCONClient rcon)
		{
			InitializeComponent();
			_vmConsole = ConsoleViewModel.INSTANCE;
			DataContext = _vmConsole;
			_rconClient = rcon;
			_vmConsole.ConsoleMonitor.Add(
				"[" + DateTime.Now + "] " + 
				"Initialize Complete! Try \"list\" to see who is online.");
		}
		private void sendButton_OnClick(object sender, RoutedEventArgs e)
		{
			_vmConsole.McResponse =
				_rconClient.sendMessage(RCONMessageType.Command, _vmConsole.McCommand);
			CollectUsedCommands();
			ShowCommandsAndResponseOnMonitor();
		}
		private void CollectUsedCommands()
		{
			_vmConsole.UsedCommands.Add(_vmConsole.McCommand);
		}
		private void ShowCommandsAndResponseOnMonitor()
		{
			_vmConsole.ConsoleMonitor.Add("[" + DateTime.Now + "]> " + _vmConsole.McCommand);
			_vmConsole.ConsoleMonitor.Add("[" + DateTime.Now + "]  " + _vmConsole.McResponse);
			commandBox.Text = string.Empty;
			monitorListView.ScrollIntoView(
				monitorListView.Items[monitorListView.Items.Count - 1]);
		}
		private void usedCommandListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			commandBox.Text = _vmConsole.UsedCommands[usedCommandListView.SelectedIndex];
		}
	}
}
