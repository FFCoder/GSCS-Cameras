using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSCS_Cameras_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<CameraModel> Models { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
