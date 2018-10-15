using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TallerApis.Api.Models
{
    public class MiSocialContext : DbContext
    {
        public MiSocialContext() : base("PublicacionConnection")
        {
        }
        public DbSet<Publicaciones> Publicaciones { get; set; }
    }
}