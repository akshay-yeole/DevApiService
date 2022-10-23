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

        public void CreateYoutubeChannelInfo(YoutubeChannel youtubeChannel)
        {
            context.YoutubeChannels.Add(youtubeChannel);
            context.SaveChanges();
        }

        public void DeleteYoutubeChannelInfo(YoutubeChannel youtubeChannel)
        {
            if (youtubeChannel == null)
            {
                throw new ArgumentNullException(nameof(youtubeChannel));
            }
            context.YoutubeChannels.Remove(youtubeChannel);
        }

        public IEnumerable<YoutubeChannel> GetAllChannels()
        {
            return context.YoutubeChannels;
        }

        public YoutubeChannel GetYoutubeChannelInfoById(int Id)
        {
            return context.YoutubeChannels.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateYoutubeChannelInfo(int Id, YoutubeChannel youtubeChannel)
        {
            var isyoutubeChannel = GetYoutubeChannelInfoById(Id);
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
