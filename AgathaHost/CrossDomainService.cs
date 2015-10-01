using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoftwareBytes.AgathaHost
{
	[ServiceContract]
	public interface ICrossDomainService
	{
		[OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
		Stream GetSilverlightPolicy();

		[OperationContract, WebGet(UriTemplate = "/crossdomain.xml")]
		Stream GetFlashPolicy();
	}

	public class CrossDomainService : ICrossDomainService
	{
		public Stream GetSilverlightPolicy()
		{
			String result = @"<?xml version=""1.0"" encoding=""utf-8""?>
								<access-policy>
									<cross-domain-access>
										<policy>
											<allow-from http-request-headers=""*"">
												<domain uri=""*""/>
											</allow-from>
											<grant-to>
												<resource path=""/"" include-subpaths=""true""/>
											</grant-to>
										</policy>
									</cross-domain-access>
								</access-policy>";

			return StringToStream(result);
		}

		public Stream GetFlashPolicy()
		{
			String result = @"<?xml version=""1.0""?>
								<!DOCTYPE cross-domain-policy SYSTEM ""http://www.macromedia.com/xml/dtds/cross-domain-policy.dtd"">
								<cross-domain-policy>
									<allow-access-from domain=""*"" />
								</cross-domain-policy>";

			return StringToStream(result);
		}

		private Stream StringToStream(String result)
		{
			WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
			return new MemoryStream(Encoding.UTF8.GetBytes(result));
		}
	}
}
