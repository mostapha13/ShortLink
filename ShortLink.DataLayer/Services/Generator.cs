using System;
using System.Collections.Generic;
using System.Text;

namespace ShortLink.DataLayer.Services
{
    

        public static class Generator
        {

        #region GenerateLink
        public static string GenerateLink()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        } 
        #endregion

    }


    
}
