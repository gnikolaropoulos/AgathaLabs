using System.Reflection;
using Agatha.ServiceLayer;

namespace SoftwareBytes.AgathaHost
{
	public static class ComponentRegistration
	{
		public static void Register()
		{
			Assembly messages = Assembly.Load("SoftwareBytes.AgathaMessages");
			new ServiceLayerConfiguration(Assembly.GetExecutingAssembly(), messages,
				typeof(Agatha.Castle.Container)).Initialize();
		}
	}
}
