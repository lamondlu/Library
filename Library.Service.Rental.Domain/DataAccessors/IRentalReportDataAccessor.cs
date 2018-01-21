using Library.Domain.Core;
using Library.Service.Rental.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Service.Rental.Domain.DataAccessors
{
	public interface IRentalReportDataAccessor
	{
		List<UnreturnedBookViewModel> GetUnreturnBooks();

		bool IsNewCustomer(Guid customerId);

		void RentBook(Guid bookId);

		void CreateRentBookRequest(Guid bookId, string bookName, string isbn, Guid customerId, PersonName name, DateTime rentDate);

		void ReturnBook(Guid bookId, DateTime returnDate);

		void Commit();

		Task CommitAsync();
	}
}