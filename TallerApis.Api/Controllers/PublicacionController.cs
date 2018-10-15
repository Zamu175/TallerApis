using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerApis.Api.Models;

namespace TallerApis.Api.Controllers
{
    public class PublicacionController : ApiController
    {
        [HttpGet]
        public IEnumerable<Publicaciones> Get()
        {
            using (var context = new MiSocialContext())
            {
                return context.Publicaciones.ToList();
            }
        }

        [HttpGet]
        public Publicaciones Get(int id)
        {
            using (var context = new MiSocialContext())
            {
                return context.Publicaciones.FirstOrDefault(x => x.Id == id);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Publicaciones publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var context = new MiSocialContext())
            {
                context.Publicaciones.Add(publicacion);
                context.SaveChanges();

                return Ok(publicacion);
            }
        }

        [HttpPut]
        public Publicaciones Put(Publicaciones publicacion)
        {
            using (var context = new MiSocialContext())
            {
                var publicAct = context.Publicaciones.FirstOrDefault(x => x.Id == publicacion.Id);

                publicAct.Usuario = publicacion.Usuario;
                publicAct.Descripcion = publicacion.Descripcion;
                publicAct.FechaPublicacion  = publicacion.FechaPublicacion;
                publicAct.MeGusta = publicacion.MeGusta;
                publicAct.MeDisgusta = publicacion.MeDisgusta;
                publicAct.VecesCompartido = publicacion.VecesCompartido;
                publicAct.EsPrivada = publicacion.EsPrivada;

                context.SaveChanges();

                return publicacion;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new MiSocialContext())
            {
                var publiDel = context.Publicaciones.FirstOrDefault(x => x.Id == id);

                context.Publicaciones.Remove(publiDel);
                context.SaveChanges();

                return true;
            }
        }

    }
}
