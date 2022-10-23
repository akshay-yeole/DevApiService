using DeveloperApiService.Models;
using System.Collections.Generic;

namespace DeveloperApiService.Data.Contracts
{
    public interface IYoutubeChannelRepo
    {
        IEnumerable<YoutubeChannel> GetAllChannels();
        void CreateYoutubeChannelInfo(YoutubeChannel youtubeChannel);
        YoutubeChannel GetYoutubeChannelInfoById(int Id);
        void UpdateYoutubeChannelInfo(int Id, YoutubeChannel youtubeChannel);
        void DeleteYoutubeChannelInfo(YoutubeChannel youtubeChannel);
        void SaveChanges();
    }
}
