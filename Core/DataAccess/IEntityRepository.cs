using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic Constraint  - Generic kısıt
    // class = referans tip demek oluyor
    // IEntity = Ientity olabilir veya Ientity implemente eden bir nesne olabilir 
    // new() = newe'lenebilir bir şey olmalı

    public interface IEntityRepository<Tip> where Tip: class, IEntity, new()
    {
        List<Tip> GetAll(Expression<Func<Tip, bool>> filter = null);
        Tip Get(Expression<Func<Tip, bool>> filter);
        void Add(Tip entity);
        void Update(Tip entity);
        void Delete(Tip entity);

        List<Tip> GetAllByCategory(int categoryId);
    }
}
