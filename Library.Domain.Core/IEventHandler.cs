using System.Threading.Tasks;

namespace Library.Domain.Core
{
    public interface IEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void HandleCore(TEvent evt);

        Task HandleAsync(TEvent evt);
    }
}