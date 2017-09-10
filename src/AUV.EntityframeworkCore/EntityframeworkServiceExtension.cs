using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AUV.EntityframeworkCore
{
    using Data;
    public static class AUVEntityframeworkCoreExtension
    {
        public static IServiceCollection AddAUVEntityframeworkCore<TContext>(this IServiceCollection collection, Action<DbContextOptionsBuilder> optionsAction)
            where TContext : DbContext
        =>
            collection.AddScoped(typeof(Data.IIdentityRepository<>), typeof(EntityframeworkIdentityRepository<>))
                .AddScoped(typeof(Data.IUniqueIdentifierRepository<>), typeof(EntityframeworkUniqueIdentifierRepository<>))
                .AddScoped(typeof(Data.IRepository<,>), typeof(EntityframeworkRepository<,>))
            .AddScoped<IUnitOfWork>(provider => new EntityframeworkDbContext(provider.GetRequiredService<TContext>()))
            .AddDbContext<TContext>(optionsAction);        
    }
}
