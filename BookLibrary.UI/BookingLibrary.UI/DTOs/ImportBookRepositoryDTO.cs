using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class ImportBookRepositoryDTO
    {
        public ImportBookRepositoryDTO()
        {
            BookRepositories = new List<Guid>();
        }

        public List<Guid> BookRepositories { get; set; }
    }
}