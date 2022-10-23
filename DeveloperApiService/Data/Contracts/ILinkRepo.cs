using DeveloperApiService.Models;
using System.Collections.Generic;

namespace DeveloperApiService.Data.Contracts
{
    public interface ILinkRepo
    {
        IEnumerable<LinkInfo> GetAll();
        void Create(LinkInfo linkInfo);
        LinkInfo GetById(int Id);
        void Update(int Id, LinkInfo linkInfo); 
        void Delete(LinkInfo linkInfo);
        void SaveChanges();
    }
}
