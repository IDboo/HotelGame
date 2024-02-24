using HotelGame.Core.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Core.DataAccess.Concrete
{
    public class BaseEntityRepository<IEntity> : IEntityRepository<IEntity> where IEntity : class, new()
    {
        #region Injection

        //Veri tabanına bir sorgu gönderilecekse ilgili veri tabanına bağlanılması gereklidir. Bunun için veri tabanının bir nesnesi burada oluşturulur ve bu nesne üzerinden ilgili işlemler yapılabilir.

        protected readonly DbContext _context;
        public BaseEntityRepository(DbContext context)
        {
            _context = context;
        }
        #endregion



        #region AddAsync
        //Veri ekleme fonksiyonudur.
        public async Task<IEntity> AddAsync(IEntity entity)
        {
            await _context.Set<IEntity>().AddAsync(entity);
            return entity;
        }
        #endregion

        #region DeleteAsync
        //Veri silme fonksiyonudur.
        public async Task<IEntity> DeleteAsync(IEntity entity)
        {
            await Task.Run(() => { _context.Set<IEntity>().Remove(entity); });
            return entity;
        }
        #endregion

        #region FindAsync
        //Id üzerinden veri getirme fonksiyonudur.
        public async Task<IEntity> FindAsync(object id)
        {
            return await _context.Set<IEntity>().FindAsync();
        }
        #endregion

        #region GetAllAsync
        //İstenilen filtre üzerinden verileri listeleme fonksiyonudur.
        public async Task<List<IEntity>> GetAllAsync(Expression<Func<IEntity, bool>> predicate = null, params Expression<Func<IEntity, object>>[] includeProperties)
        {
            IQueryable<IEntity> query = _context.Set<IEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }
        #endregion

        #region GetAsync
        //İstenilen filtre üzerinden veri getirme fonksiyonudur.
        public async Task<IEntity> GetAsync(Expression<Func<IEntity, bool>> predicate = null, params Expression<Func<IEntity, object>>[] includeProperties)
        {
            IQueryable<IEntity> query = _context.Set<IEntity>();
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync();
        }
        #endregion

        #region SaveAsync
        //Ekleme silme ve güncelleme fonksiyonlarından sonra tetiklenecek kayıt fonksiyonudur.
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        #endregion

        #region UpdateAsync
        //Veri güncelleme fonksiyonudur.
        public async Task<IEntity> UpdateAsync(IEntity entity)
        {
            await Task.Run(() => { _context.Set<IEntity>().Update(entity); });
            return entity;
        }
        #endregion

        public List<IEntity> GetAll()
        {
            return _context.Set<IEntity>().AsNoTracking().ToList();
        }

    }
}
