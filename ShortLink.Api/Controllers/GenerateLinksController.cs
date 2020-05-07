using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortLink.DataLayer.Context;
using ShortLink.DataLayer.Entites;
using ShortLink.DataLayer.Repository;

namespace ShortLink.Api.Controllers
{ 
    public class GenerateLinksController : BaseController
    {
        private readonly IGenerateShortLinkRepository _context;

        #region Constructor
        public GenerateLinksController(IGenerateShortLinkRepository context)
        {
            _context = context;
        } 
        #endregion


        #region Get
        // GET: api/GenerateLinks/shortLink
        [HttpGet("{shortLink}")]
        public async Task<ActionResult<GenerateLink>> GetGenerateLink(string shortLink)
        {
            var generateLink = await _context.GetLink(shortLink);

            if (generateLink == null)
            {
                return NotFound();
            }

            var generate = generateLink.SiteName + generateLink.Link;
            return Redirect(generate);
        }

        #endregion

        #region Post
        // POST: api/GenerateLinks

        [HttpPost]
        public async Task<ActionResult<GenerateLink>> PostGenerateLink(GenerateLink linkGenerate)
        {

            if (string.IsNullOrEmpty(linkGenerate.Title) || string.IsNullOrEmpty(linkGenerate.Link) || string.IsNullOrEmpty(linkGenerate.SiteName))
            {
                return BadRequest("لطفا اطلاعات را وارد نمایید");
            }

            var result = await _context.CreateShortLink(linkGenerate.Title, linkGenerate.Link, linkGenerate.SiteName);

            if (result == 1)
            {
                return Ok(_context.GetShortLink(linkGenerate.SiteName, linkGenerate.Link));
                //   return new ObjectResult(_context.GetLink(siteName,link);
            }
            else
            {
                return BadRequest("خطا");
            }



        }

        #endregion


    
    }
}
