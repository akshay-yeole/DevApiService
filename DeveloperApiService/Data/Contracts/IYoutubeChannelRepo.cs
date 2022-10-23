using DeveloperApiService.Models;
using System.Collections.Generic;

namespace DeveloperApiService.Data.Contracts
{
    public interface IYoutubeChannelRepo
    {
        IEnumerable<YoutubeChannel> GetAll();
        void Create(YoutubeChannel obj);
        YoutubeChannel GetById(int Id);
        void Update(int Id, YoutubeChannel obj);
        void Delete(YoutubeChannel obj);
        void SaveChanges();
    }
}
