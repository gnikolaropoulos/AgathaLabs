using System;
using Agatha.Common;
using Agatha.ServiceLayer;
using SoftwareBytes.AgathaMessages;

namespace Softwarebytes.AgathaHostAgathaMessages.Handlers
{
	public class EchoRequestHandler : RequestHandler<EchoRequest,EchoResponse>
	{
		public override Response Handle(EchoRequest request)
		{
			var response = CreateTypedResponse();
			if (request.Message == String.Empty)
			{
				response.Message = "Empty...";
			}
			else
			{
				response.Message = request.Message;
			}

			return response;
		}
	}
}
