using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AUV.EntityframeworkCore
{
    public class EntityframeworkDbContext:DisposableHandler,Data.IUnitOfWork,IDisposable
    {
        private readonly ThreadLocal<DbContext> localContext;
        public EntityframeworkDbContext(DbContext context)
        {
            localContext = new ThreadLocal<DbContext>(() => context);
        }

        public Task CompleteAsync() => localContext.Value.SaveChangesAsync();
        

        protected override void DisposeHandler() => localContext.Value.Dispose();
    }
}
