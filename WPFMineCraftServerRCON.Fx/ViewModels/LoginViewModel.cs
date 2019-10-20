using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFMineCraftServerRCON.ViewModels
{
	internal class LoginViewModel : ViewModelBase
	{
		public static readonly LoginViewModel INSTANCE = new LoginViewModel();
		private LoginViewModel()
		{
			SelectBackgoundImage();
		}
		#region Properties
		public string IPAddress { get; set; } = "localhost";
		public int Port { get; set; } = 25575;
		public ImageBrush BackgroundImageSource { get; set; }
		#endregion
		public void SelectBackgoundImage()
		{
			//It will ergodic /Resource folder in the future
			string path = @"Resources\Background\"
						   + new Random().Next(3)
						   + ".jpg";
			Uri uriPath = new Uri(path, UriKind.Relative);
			BackgroundImageSource = new ImageBrush(new BitmapImage(uriPath));
		}
	}
}
