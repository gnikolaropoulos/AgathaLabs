using System;
using System.Configuration;
using System.Reflection;
using Agatha.Common;
using SoftwareBytes.AgathaMessages;

namespace SoftwareBytes.AgathaWPFClient
{
	public static class ComponentRegistration
	{
		public static void Register()
		{
			String assebmlyName = ConfigurationManager.AppSettings["Messages"];
			Assembly messages = Assembly.Load(assebmlyName);
			new ClientConfiguration(typeof(EchoRequest).Assembly, typeof(Agatha.Castle.Container)).Initialize();
		}
	}
}
