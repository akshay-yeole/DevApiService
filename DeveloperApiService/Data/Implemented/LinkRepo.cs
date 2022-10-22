using DeveloperApiService.Data.Contracts;
using DeveloperApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperApiService.Data.Implemented
{
    public class LinkRepo : ILinkRepo
    {
        private readonly OwnApiContext context;

        public LinkRepo(OwnApiContext context)
        {
            this.context = context;
        }

        public void CreateLinkInfo(LinkInfo linkInfo)
        {
            context.LinkInfos.Add(linkInfo);
            context.SaveChanges();
        }

        public void DeleteLinkInfo(LinkInfo linkInfo)
        {
            if (linkInfo == null)
            {
                throw new ArgumentNullException(nameof(linkInfo));
            }
            context.LinkInfos.Remove(linkInfo);
        }

        public IEnumerable<LinkInfo> GetAllLinks()
        {
            return context.LinkInfos;
        }

        public LinkInfo GetLinkInfoById(int Id)
        {
            return context.LinkInfos.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateLinkInfo(int Id, LinkInfo linkInfo)
        {
            var islinkInfo = GetLinkInfoById(Id);
            if (islinkInfo == null)
            {
                throw new ArgumentNullException(nameof(linkInfo));
            }

            islinkInfo.Name = linkInfo.Name;    
            islinkInfo.Description = linkInfo.Description;
            islinkInfo.LinkUrl=linkInfo.LinkUrl;
        
            SaveChanges();
        }
    }
}
