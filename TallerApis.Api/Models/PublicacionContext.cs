using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TallerAís.Dominio;

namespace TallerApis.Api.Models
{
    public class PublicacionContext : DbContext
    {
        public PublicacionContext() : base("PublicacionConnection")
        {

        }

        public DbSet<Publicacion> Publicaciones { get; set; }
    }
}