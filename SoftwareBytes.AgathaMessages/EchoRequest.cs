using System;
using Agatha.Common;

namespace SoftwareBytes.AgathaMessages
{
	public sealed class EchoRequest : Request
	{
		public String Message { get; set; }
	}
}
