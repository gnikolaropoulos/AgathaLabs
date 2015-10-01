using System;
using System.Windows;
using System.Windows.Controls;
using Agatha.Common;
using Agatha.Common.InversionOfControl;
using SoftwareBytes.AgathaMessages;

namespace SoftwareBytes.AgathaSilverlightClient
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void HandleSendRequestClick(Object sender, RoutedEventArgs e)
		{
			EchoRequest request = new EchoRequest{Message=m_message.Text};
			var requestDispatcher = IoC.Container.Resolve<IAsyncRequestDispatcher>();
			requestDispatcher.Add(request);
			requestDispatcher.ProcessRequests(responses =>
				{
					var response = responses.Get<EchoResponse>();
					m_response.Text = "Message received is \"" + response.Message +"\"";
				},
				ex => {m_response.Text = ex.Message; });
		}
	}
}
