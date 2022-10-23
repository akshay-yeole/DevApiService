using DeveloperApiService.Models;
using System.Collections.Generic;

namespace DeveloperApiService.Data.Contracts
{
    public interface ICommander
    {
        IEnumerable<CommandDetail> GetAll();
        void Create(CommandDetail obj);
        CommandDetail GetById(int Id);
        void Update(int Id, CommandDetail obj);
        void Delete(CommandDetail obj);
        void SaveChanges();
    }
}
