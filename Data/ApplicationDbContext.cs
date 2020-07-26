using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prototipos_Huertos_Autosustentables.Models;

namespace Prototipos_Huertos_Autosustentables.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Clima> Climas { get; set; }
        public virtual DbSet<Cultivo> Cultivos { get; set; }
        public virtual DbSet<DetalleCultivosUsuario> DetalleCultivosUsuarios { get; set; }
        public virtual DbSet<Region> Regiones { get; set; }
        public virtual DbSet<TipoCultivo> TipoCultivos { get; set; }
    }
}
