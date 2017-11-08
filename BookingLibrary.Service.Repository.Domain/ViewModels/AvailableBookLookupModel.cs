using System;

namespace BookingLibrary.Service.Repository.Domain.ViewModels
{
    public class AvailableBookLookupModel
    {
        public Guid BookId { get; set; }

        public string Name { get; set; }
    }
}