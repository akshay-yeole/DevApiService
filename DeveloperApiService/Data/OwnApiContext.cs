using DeveloperApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperApiService.Data
{
    public class OwnApiContext : DbContext
    {
        public OwnApiContext(DbContextOptions<OwnApiContext> options) : base(options)
        {

        }
        public DbSet<LinkInfo> LinkInfos { get; set; }
        public DbSet<YoutubeChannel> YoutubeChannels { get; set; }
    }
}
