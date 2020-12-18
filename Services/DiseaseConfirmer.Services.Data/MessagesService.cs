namespace DiseaseConfirmer.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DiseaseConfirmer.Data.Common.Repositories;
    using DiseaseConfirmer.Data.Models;
    using DiseaseConfirmer.Services.Data.Contracts;
    using DiseaseConfirmer.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class MessagesService : IMessagesService
    {
        private readonly IDeletableEntityRepository<Message> messagesRepositoy;

        public MessagesService(IDeletableEntityRepository<Message> messagesRepositoy)
        {
            this.messagesRepositoy = messagesRepositoy;
        }

        public async Task<Message> Create(string senderId, string content)
        {
            var message = new Message()
            {
                Text = content,
                SenderId = senderId,
            };

            await this.messagesRepositoy.AddAsync(message);
            await this.messagesRepositoy.SaveChangesAsync();

            return message;
        }

        public async Task DeleteOlderMessages()
        {
            var messages = await this.messagesRepositoy
                .All()
                .Where(m => m.CreatedOn.Date != DateTime.Today)
                .ToListAsync();

            foreach (var message in messages)
            {
                this.messagesRepositoy.HardDelete(message);
            }

            await this.messagesRepositoy.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> MessagesFromToday<T>()
        {
            return await this.messagesRepositoy
                .All()
                .Where(m => m.CreatedOn.Date == DateTime.Today)
                .To<T>()
                .ToListAsync();
        }
    }
}
