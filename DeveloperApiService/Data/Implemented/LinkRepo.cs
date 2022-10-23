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

        public void Create(LinkInfo linkInfo)
        {
            context.LinkInfos.Add(linkInfo);
            context.SaveChanges();
        }

        public void Delete(LinkInfo linkInfo)
        {
            if (linkInfo == null)
            {
                throw new ArgumentNullException(nameof(linkInfo));
            }
            context.LinkInfos.Remove(linkInfo);
        }

        public IEnumerable<LinkInfo> GetAll()
        {
            return context.LinkInfos;
        }

        public LinkInfo GetById(int Id)
        {
            return context.LinkInfos.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(int Id, LinkInfo linkInfo)
        {
            var islinkInfo = GetById(Id);
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
