using System;

namespace Library.Service.Inventory.Domain.ViewModels
{
    public class AvailableBookLookupModel
    {
        public Guid BookId { get; set; }

        public string Name { get; set; }
    }
}