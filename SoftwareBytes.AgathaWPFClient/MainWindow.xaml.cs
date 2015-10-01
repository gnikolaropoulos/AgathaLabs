using System.Windows;
using Agatha.Common;
using Agatha.Common.InversionOfControl;
using SoftwareBytes.AgathaMessages;
using System.Configuration;

namespace SoftwareBytes.AgathaWPFClient
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ComponentRegistration.Register();
		}

		private void HandleSendRequestClick(object sender, RoutedEventArgs e)
		{
			EchoRequest request = new EchoRequest { Message = m_message.Text };
			var requestDispatcher = IoC.Container.Resolve<IAsyncRequestDispatcher>();
			requestDispatcher.Add(request);
			requestDispatcher.ProcessRequests(responses =>
			{
				var response = responses.Get<EchoResponse>();
				m_response.Text = "Message received is \"" + response.Message + "\"";
			},
				ex => { m_response.Text = ex.Message; });
		}
	}
}
