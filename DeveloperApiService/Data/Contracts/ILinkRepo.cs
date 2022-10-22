using DeveloperApiService.Models;
using System.Collections.Generic;

namespace DeveloperApiService.Data.Contracts
{
    public interface ILinkRepo
    {
        IEnumerable<LinkInfo> GetAllLinks();
        void CreateLinkInfo(LinkInfo linkInfo);
        LinkInfo GetLinkInfoById(int Id);
        void UpdateLinkInfo(int Id, LinkInfo linkInfo); 
        void DeleteLinkInfo(LinkInfo linkInfo);
        void SaveChanges();
    }
}
