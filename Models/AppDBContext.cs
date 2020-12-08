using Microsoft.EntityFrameworkCore;

namespace SPCoreApi.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
             : base(options)
        {

        }
        public DbSet<MemberProfile> MemberProfiles { get; set; }
    }
}