namespace DiseaseConfirmer.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Models;

    public interface IMessagesService
    {
        Task<Message> Create(string senderId, string message);

        Task<IEnumerable<T>> MessagesFromToday<T>();
    }
}
