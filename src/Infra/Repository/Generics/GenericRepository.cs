using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Domain.Interfaces.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using sfm.Infra.Configuration;

namespace Infra.Repository.Generics
{
    public class GenericsRepository
    {
        public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
        {
            private readonly DbContextOptions<ECommerceContext> _OptionsBuilder;

            public GenericRepository() { _OptionsBuilder = new DbContextOptions<ECommerceContext>(); }

            public async Task Add(T Object)
            {
                using var db = new ECommerceContext(_OptionsBuilder);
                await db.Set<T>().AddAsync(Object);
                await db.SaveChangesAsync();
            }

            public async Task Update(T Object)
            {
                using var db = new ECommerceContext(_OptionsBuilder);
                db.Set<T>().Update(Object);
                await db.SaveChangesAsync();
            }

            public async Task Delete(T Object)
            {
                using var db = new ECommerceContext(_OptionsBuilder);
                db.Set<T>().Remove(Object);
                await db.SaveChangesAsync();
            }

            public async Task<T> GetEntityById(Guid Id)
            {
                using var db = new ECommerceContext(_OptionsBuilder);
                return await db.Set<T>().FindAsync(Id);
            }

            public async Task<List<T>> List()
            {
                using var db = new ECommerceContext(_OptionsBuilder);
                return await db.Set<T>().AsNoTracking().ToListAsync();
            }

            // Flag: Has Dispose already been called?
            bool disposed = false;

            // Instantiate a SafeHandle instance.
            SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

            // Public implementation of Dispose pattern callable by consumers.
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            // Protected implementation of Dispose pattern.
            protected virtual void Dispose(bool disposing)
            {
                if (disposed) return;
                // Free any other managed objects here.
                if (disposing) handle.Dispose();
                disposed = true;
            }

            ~GenericRepository()
            {
                Dispose(false);
            }
        }
    }
}
