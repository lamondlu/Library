using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.CSDataAccessor.Core
{
	public interface IApiGatewayUrlProvider
	{
		string Url { get; }
	}
}
