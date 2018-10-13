using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TallerApis.Api.Models
{
    public class PublicacionesContext : DbContext
    {
        public PublicacionesContext() : base("PublicacionConnection")
        {

        }
        public DbSet<Publicacion> publicaciones { get; set; }
    }
}