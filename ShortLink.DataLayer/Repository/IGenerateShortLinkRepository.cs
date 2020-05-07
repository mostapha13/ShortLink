using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ShortLink.DataLayer.Entites;

namespace ShortLink.DataLayer.Repository
{
   public interface IGenerateShortLinkRepository
   {
        #region CreateShortLink
        Task<int> CreateShortLink(string title, string link, string siteName);
        #endregion

        #region GetLink
        Task<GenerateLink> GetLink(string shortKey);
        #endregion

        #region GetShortLink
        Task<string> GetShortLink(string siteName, string link);
        #endregion

        #region Save
        Task Save(); 
        #endregion

    }
}
