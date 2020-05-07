using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShortLink.DataLayer.Entites;

namespace ShortLink.DataLayer.Context
{
   public class ShortLinkContext:DbContext
    {
        #region Constructor

        public ShortLinkContext(DbContextOptions<ShortLinkContext> options) : base(options)
        {

        }

        #endregion

        public DbSet<GenerateLink> GenerateLinks { get; set; }



        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        } 
        #endregion
    }
}
