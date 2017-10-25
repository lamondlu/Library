using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class BookRepositoryDTO
    {
        public Guid BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public string Description { get; set; }
    }
}