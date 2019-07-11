using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpDemo.Authorization.Roles;
using AbpDemo.Authorization.Users;
using AbpDemo.MultiTenancy;

namespace AbpDemo.EntityFrameworkCore
{
    public class AbpDemoDbContext : AbpZeroDbContext<Tenant, Role, User, AbpDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpDemoDbContext(DbContextOptions<AbpDemoDbContext> options)
            : base(options)
        {
        }
    }
}
