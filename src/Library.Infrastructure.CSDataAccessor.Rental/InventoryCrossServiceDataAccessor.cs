using Library.Service.Rental.Domain.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Service.Rental.Domain.DTOs;
using Library.Infrastructure.CSDataAccessor.Core;
using Library.Infrastructure.Core.Utilities;

namespace Library.Infrastructure.CSDataAccessor.Rental
{
	public class InventoryCrossServiceDataAccessor : IInventoryCrossServiceDataAccessor
	{
		private string _url = string.Empty;

		public InventoryCrossServiceDataAccessor(IApiGatewayUrlProvider provider)
		{
			_url = provider.Url;
		}

		public BookInventoryDetailsViewModel GetBookInventory(Guid bookInventoryId)
		{
			return ApiRequest.Get<BookInventoryDetailsViewModel>($"{_url}/inventories/{bookInventoryId}/details");
		}
	}
}
