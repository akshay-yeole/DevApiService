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
        public ActionResult<IEnumerable<YoutubeChannel>> GetAll()
        {
            try
            {
                var obj = repo.GetAll();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<YoutubeChannel> CreateYoutubeChannelInfo(YoutubeChannel obj)
        {
            try
            {
                repo.Create(obj);
                return CreatedAtRoute(nameof(GetById), new { Id = obj.Id }, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{Id}", Name = "GetById")]
        public ActionResult<LinkInfo> GetById(int Id)
        {
            try
            {
                var obj = repo.GetById(Id);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<YoutubeChannel> Update(int Id, YoutubeChannel obj)
        {
            try
            {
                repo.Update(Id, obj);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            try
            {
                var obj = repo.GetById(Id);

                if (obj == null)
                {
                    return NotFound();
                }
                repo.Delete(obj);
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
