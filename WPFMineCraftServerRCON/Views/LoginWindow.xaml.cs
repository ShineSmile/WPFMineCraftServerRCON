using System.Windows;
using WPFMineCraftServerRCON.ViewModels;
using MinecraftServerRCON;
using System;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace WPFMineCraftServerRCON.Views
{
	public partial class LoginWindow : Window
	{
		private LoginViewModel _vmLogin;
		public LoginWindow()
		{
			InitializeComponent();
			_vmLogin = LoginViewModel.INSTANCE;
			DataContext = _vmLogin;
		}

		private void loginButton_OnClick(object sender, RoutedEventArgs e)
		{
			using (var rcon = RCONClient.INSTANCE)
			{
				try
				{
					rcon.setupStream(
						_vmLogin.IPAddress,
						_vmLogin.Port,
						passwordBox.Password);
					passwordBox.Password = string.Empty;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}
				ConsoleWindow consoleWindow = new ConsoleWindow(rcon);
				this.Visibility = Visibility.Collapsed;
				consoleWindow.ShowDialog();
				this.Visibility = Visibility.Visible;
			}
		}
		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void navigationGrid_MouseLeave(object sender, MouseEventArgs e)
		{
			_navigationGrid.Width = 10;
		}

		private void navigationGrid_MouseEnter(object sender, MouseEventArgs e)
		{
			_navigationGrid.Width = 80;
		}

		private void BlogHyperlink_Click(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://blog.heavensfeel.net");
		}

		private void GitHubHyperlink_Click(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ShineSmile");
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
