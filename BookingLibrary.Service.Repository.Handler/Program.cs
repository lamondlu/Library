using System;

namespace BookingLibrary.Service.Repository.Handler
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositoryHandlerRegister register = new RepositoryHandlerRegister();
            register.RegisterAndStart();
        }
    }
}
