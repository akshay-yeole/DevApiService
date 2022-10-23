using DeveloperApiService.Data.Contracts;
using DeveloperApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperApiService.Data.Implemented
{
    public class Commander : ICommander
    {
        private readonly OwnApiContext context;

        public Commander(OwnApiContext context)
        {
            this.context = context;
        }
        public void Create(CommandDetail obj)
        {
            context.commandDetails.Add(obj);
            context.SaveChanges();
        }

        public void Delete(CommandDetail obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            context.commandDetails.Remove(obj);
        }

        public IEnumerable<CommandDetail> GetAll()
        {
            return context.commandDetails;
        }

        public CommandDetail GetById(int Id)
        {
            return context.commandDetails.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(int Id, CommandDetail obj)
        {
            var isCommandDetail = GetById(Id);
            if (isCommandDetail == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            isCommandDetail.HowTo = obj.HowTo;
            isCommandDetail.Line = obj.Line;
            isCommandDetail.Technology = obj.Technology;

            SaveChanges();
        }
    }
}
