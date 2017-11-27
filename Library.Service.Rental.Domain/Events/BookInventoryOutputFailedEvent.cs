using Library.Domain.Core;
using Library.Domain.Core.Attributes;
using Library.Domain.Core.Models;

namespace Library.Service.Rental.Domain.Events
{
    [EventLog(Code = "BOOKINVENTORYOUTPUT_FAILED", Message = "The book has been output by others, you can't rent this book", Type = LogType.Warning, DirectError = true)]
    [EventLog(Code = "SERVER_ERROR", Type = LogType.Error)]
    public class BookInventoryOutputFailedEvent : DomainEvent
    {
        public readonly static string Event_BookInventoryOutputFailed = "Event_BookInventoryOutputFailed";

        public BookInventoryOutputFailedEvent() : base(Event_BookInventoryOutputFailed)
        {
            
        }
    }
}