using DeveloperApiService.Data.Contracts;
using DeveloperApiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperApiService.Data.Implemented
{
    public class YoutubeChannelRepo : IYoutubeChannelRepo
    {
        private readonly OwnApiContext context;

        public YoutubeChannelRepo(OwnApiContext context)
        {
            this.context = context;
        }

        public void Create(YoutubeChannel youtubeChannel)
        {
            context.YoutubeChannels.Add(youtubeChannel);
            context.SaveChanges();
        }

        public void Delete(YoutubeChannel youtubeChannel)
        {
            if (youtubeChannel == null)
            {
                throw new ArgumentNullException(nameof(youtubeChannel));
            }
            context.YoutubeChannels.Remove(youtubeChannel);
        }

        public IEnumerable<YoutubeChannel> GetAll()
        {
            return context.YoutubeChannels;
        }

        public YoutubeChannel GetById(int Id)
        {
            return context.YoutubeChannels.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(int Id, YoutubeChannel youtubeChannel)
        {
            var isyoutubeChannel = GetById(Id);
            if (isyoutubeChannel == null)
            {
                throw new ArgumentNullException(nameof(youtubeChannel));
            }

            isyoutubeChannel.Name = youtubeChannel.Name;
            isyoutubeChannel.Technologies = youtubeChannel.Technologies;

            SaveChanges();
        }
    }
}
