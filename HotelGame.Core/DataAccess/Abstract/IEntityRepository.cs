using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelGame.Core.DataAccess.Abstract
{
    public interface IEntityRepository<IEntity> where IEntity : class, new()
    {
        //Veri erişim kodlarının imzaları burada bulunur. BU yapı bütün IEntity nesneleri için çalışabilecek düzeyde jenerik olarak tasarlanmıştır.
        //Bulunan bütün fonksiyonlar asenkron olarak çalışırlar.

        //İlgili filtreye ve talebe göre listeleme fonksiyonudur.
        Task<List<IEntity>> GetAllAsync(Expression<Func<IEntity, bool>> predicate = null, params Expression<Func<IEntity, object>>[] includeProperties);

        //İlgili filtreye ve talebe göre bir adet varlık getirme fonksiyonudur.
        Task<IEntity> GetAsync(Expression<Func<IEntity, bool>> predicate = null, params Expression<Func<IEntity, object>>[] includeProperties);

        //İlgili id'ye göre listeleme fonksiyonudur. Yalnızca id üzerinden sorgu yapılabilir.
        Task<IEntity> FindAsync(object id);

        //Varlık ekleme fonksiyonudur.
        Task<IEntity> AddAsync(IEntity entity);

        //Varlık güncelleme fonksiyonudur.
        Task<IEntity> UpdateAsync(IEntity entity);

        //Varlık silme fonsiyonudur.
        Task<IEntity> DeleteAsync(IEntity entity);

        //Ekleme, silme ve güncelleme fonksiyonlarından sonra işlemin kayıt edilmesi gereklidir. Kayıt fonksiyonudur.
        Task<int> SaveAsync();



        List<IEntity> GetAll();

    }
}
