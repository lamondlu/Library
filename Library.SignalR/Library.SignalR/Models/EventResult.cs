namespace Library.SignalR.Models
{
    public class EventResult
    {
        public string EventName { get; set; }

        public bool IsFinished { get; set; }

        public bool IsError { get; set; }
    }
}