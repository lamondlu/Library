using System;

namespace Library.UI.DTOs
{
    public class RentBookDTO
    {
        public Guid BookId { get; set; }

        public Guid CustomerId { get; set; }
    }
}