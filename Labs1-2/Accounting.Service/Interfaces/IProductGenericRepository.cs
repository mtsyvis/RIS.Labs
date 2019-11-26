using System;
using System.Collections.Generic;

namespace Accounting.Service.Interfaces
{
    public interface IProductGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetProduct(Predicate<T> predicate);

        void Add(T product);

        void Delete(T product);

        void Update(List<T> products);

        void Save();
    }
}
