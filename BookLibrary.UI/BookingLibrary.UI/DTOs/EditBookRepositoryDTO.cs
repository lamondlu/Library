using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingLibrary.UI.DTOs
{
    public class EditBookRepositoryDTO
    {
        public Guid BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string ISBN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateIssued { get; set; }

        public string Description { get; set; }
    }
}