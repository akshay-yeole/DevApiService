using DeveloperApiService.Data.Contracts;
using DeveloperApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DeveloperApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeChannelsController : ControllerBase
    {
        private readonly IYoutubeChannelRepo repo;

        public YoutubeChannelsController(IYoutubeChannelRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]   
        public ActionResult<IEnumerable<YoutubeChannel>> GetAllChannels()
        {
            try
            {
                var allChannels = repo.GetAllChannels();
                return Ok(allChannels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<YoutubeChannel> CreateYoutubeChannelInfo(YoutubeChannel youtubeChannel)
        {
            try
            {
                repo.CreateYoutubeChannelInfo(youtubeChannel);
                return Ok(youtubeChannel);
                //return CreatedAtRoute(nameof(GetLinkInfoById), new { Id = linkInfo.Id }, linkInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{Id}", Name = "GetYoutubeChannelInfoById")]
        public ActionResult<IEnumerable<LinkInfo>> GetYoutubeChannelInfoById(int Id)
        {
            try
            {
                var ChannelInfo = repo.GetYoutubeChannelInfoById(Id);
                if (ChannelInfo == null)
                {
                    return NotFound();
                }
                return Ok(ChannelInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<YoutubeChannel> UpdateYoutubeChannelInfo(int Id, YoutubeChannel youtubeChannel)
        {
            try
            {
                repo.UpdateYoutubeChannelInfo(Id, youtubeChannel);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteYoutubeChannel(int Id)
        {
            try
            {
                var YoutubeChannelInfo = repo.GetYoutubeChannelInfoById(Id);

                if (YoutubeChannelInfo == null)
                {
                    return NotFound();
                }
                repo.DeleteYoutubeChannelInfo(YoutubeChannelInfo);
                repo.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
