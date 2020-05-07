using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ShortLink.DataLayer.Context;
using ShortLink.DataLayer.Entites;
using ShortLink.DataLayer.Services;
using ShortLink.DataLayer.Enum;

namespace ShortLink.DataLayer.Repository
{
    public class GenerateShortLinkRepository : IGenerateShortLinkRepository
    {
        private ShortLinkContext _context;

        #region Constructor

        public GenerateShortLinkRepository(ShortLinkContext context)
        {
            _context = context;
        } 

        #endregion



        #region CreateShortLink

        public async Task<int> CreateShortLink(string title, string link,string siteName)
        {
             
                try
                {
                  

                    GenerateLink shortLink = new GenerateLink()
                    {
                        Link = link.Trim(),
                        Title = title.Trim(),
                        ShortLink = Generator.GenerateLink(),
                        SiteName = siteName.Trim(),
                        CreateDate = DateTime.Now
                    };

                   await _context.GenerateLinks.AddAsync(shortLink);
                  await Save();
                  return (int)Status.success;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return (int)Status.faild;
                }
         


        }

        #endregion


        #region GetLink
        public async Task<GenerateLink> GetLink(string shortKey)
        {
            return await _context.GenerateLinks.SingleOrDefaultAsync(g => g.ShortLink == shortKey.Trim());
        }
        #endregion

        #region GetShortLink
        public async Task<string> GetShortLink(string siteName, string link)
        {

            var myLink = await _context.GenerateLinks.Where(g => g.Link == link && g.SiteName == siteName)
                .Select(g => g.ShortLink).SingleOrDefaultAsync();

            return myLink;
        }

        #endregion




        #region Save
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        } 
        #endregion
    }
}
